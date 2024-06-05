using Obi;
using Oculus.Interaction.Editor.Generated;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGrapplingHook : MonoBehaviour
{
    public ObiSolver solver;
    public Material material;
    public ObiCollider character;
    public ObiRopeSection section;
    public Transform bowAttachment;
    public Transform revolver;
    public event Action OnInitializationComplete;
    public event Action detachedHook;

    private ObiRope rope;
    private ObiRopeBlueprint blueprint;
    private ObiRopeExtrudedRenderer ropeRenderer;

    [Range(0, 1)]
    public float hookResolution = 0.5f;
    public float hookExtendRetractSpeed = 2;
    public float hookShootSpeed = 2;
    public int particlePoolSize = 100;

    private ObiRopeCursor cursor;

    private RaycastHit hookAttachment;
    private Vector3 hitPoint;

    private bool obiRopeCreated = false;
    public GameObject attachedGameObjectPrefab;
    private GameObject[] attachedGameObjects;

    void Awake()
    {

        // Create both the rope and the solver:	
        rope = gameObject.AddComponent<ObiRope>();
        ropeRenderer = gameObject.AddComponent<ObiRopeExtrudedRenderer>();
        ropeRenderer.section = section;
        ropeRenderer.uvScale = new Vector2(1, 4);
        ropeRenderer.normalizeV = false;
        ropeRenderer.uvAnchor = 1;
        rope.GetComponent<MeshRenderer>().material = material;

        // Setup a blueprint for the rope:
        blueprint = ScriptableObject.CreateInstance<ObiRopeBlueprint>();
        blueprint.resolution = 0.5f;
        blueprint.thickness = 0.02f;
        blueprint.pooledParticles = particlePoolSize;

        // Tweak rope parameters:
        rope.maxBending = 0.001f;
        rope.stretchCompliance = 0;

        // Add a cursor to be able to change rope length:
        cursor = rope.gameObject.AddComponent<ObiRopeCursor>();
        cursor.cursorMu = 0;
        cursor.direction = true;
    }

    public void ButtonTriggered()
    {
        if (!rope.isLoaded)
        {
            LaunchHook();
        } else
        {
            DetachHook();
        }
    }

    private void OnDestroy()
    {
        DestroyImmediate(blueprint);
    }

    /**
	 * Raycast against the scene to see if we can attach the hook to something.
	 */
    private void LaunchHook()
    {
        Debug.Log("Hook launced!");

        // Get a ray from the character to the mouse:
        Ray ray = new Ray(bowAttachment.position, bowAttachment.forward);

        // Raycast to see what we hit:
        if (Physics.Raycast(ray, out hookAttachment))
        {
            // We actually hit something, so attach the hook!
            StartCoroutine(AttachHook());
        }

    }

    private IEnumerator AttachHook()
    {
        yield return null;

        // Clear any existing pin constraints:
        var pinConstraints = rope.GetConstraintsByType(Oni.ConstraintType.Pin) as ObiConstraints<ObiPinConstraintsBatch>;
        pinConstraints.Clear();

        // Get the hook point in local coordinates of the rope transform
        Vector3 localHit = rope.transform.InverseTransformPoint(hookAttachment.point);

        // Initialize the rope path
        int filter = ObiUtils.MakeFilter(ObiUtils.CollideWithEverything, 0);
        blueprint.path.Clear();
        Vector3 startPoint = bowAttachment.position; // Start point based on the gun attachment
        blueprint.path.AddControlPoint(startPoint, Vector3.zero, Vector3.zero, Vector3.up, 0.1f, 0.1f, 1, filter, Color.white, "Hook start");
        blueprint.path.AddControlPoint(localHit.normalized * 0.5f, Vector3.zero, Vector3.zero, Vector3.up, 0.1f, 0.1f, 1, filter, Color.white, "Hook end");
        blueprint.path.FlushEvents();

        // Generate the particle representation of the rope
        yield return blueprint.Generate();

        // Assign the blueprint to start the simulation
        rope.ropeBlueprint = blueprint;

        // Enable rope rendering
        rope.GetComponent<MeshRenderer>().enabled = true;

        // Zero out masses to allow manual position override while extending the rope
        for (int i = 0; i < rope.activeParticleCount; ++i)
            solver.invMasses[rope.solverIndices[i]] = 0;

        // Extending the rope to reach the hit point
        float currentLength = 0;
        while (true)
        {
            Vector3 origin = solver.transform.InverseTransformPoint(rope.transform.position);
            Vector3 direction = hookAttachment.point - origin;
            float distance = direction.magnitude;
            direction.Normalize();

            currentLength += hookShootSpeed * Time.deltaTime;
            if (currentLength >= distance)
            {
                cursor.ChangeLength(distance - 1.5f);
                break;
            }

            cursor.ChangeLength(Mathf.Min(distance, currentLength));

            float length = 0;
            for (int i = 0; i < rope.elements.Count; ++i)
            {
                solver.positions[rope.elements[i].particle1] = origin + direction * length;
                solver.positions[rope.elements[i].particle2] = origin + direction * (length + rope.elements[i].restLength);
                length += rope.elements[i].restLength;
            }
            yield return null;


        }

     

        // Restore masses for simulation to take over
        for (int i = 0; i < rope.activeParticleCount; ++i)
            solver.invMasses[rope.solverIndices[i]] = 1; // 1/0.1 = 10

        // Pin both ends of the rope (this enables two-way interaction between character and rope):
        var batch = new ObiPinConstraintsBatch();
        batch.AddConstraint(rope.elements[0].particle1, character, transform.localPosition, Quaternion.identity, 0, 0, float.PositiveInfinity);
        batch.AddConstraint(rope.elements[rope.elements.Count - 1].particle2, hookAttachment.collider.GetComponent<ObiColliderBase>(),
                                                          hookAttachment.collider.transform.InverseTransformPoint(hookAttachment.point), Quaternion.identity, 0, 0, float.PositiveInfinity);
        batch.activeConstraintCount = 2;
        pinConstraints.AddBatch(batch);

        rope.SetConstraintsDirty(Oni.ConstraintType.Pin);



        OnInitializationComplete?.Invoke();

    }

    private void DetachHook()
    {
        // Set the rope blueprint to null (automatically removes the previous blueprint from the solver, if any).
        rope.ropeBlueprint = null;
        rope.GetComponent<MeshRenderer>().enabled = false;
        detachedHook?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {



    }
}
