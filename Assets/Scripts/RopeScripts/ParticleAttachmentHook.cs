using Obi;
using System.Collections;
using UnityEngine;

public class ParticleAttachmentHook : MonoBehaviour
{
    private ObiSolver solver;
    public GameObject attachedGameObjectPrefab;
    public GameObject ropeObject;
    private GameObject[] attachedGameObjects;
    public VRGrapplingHook grapplingHook;
    private bool createdRope = false;
    void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        if (grapplingHook != null)
        {
            // Subscribe to the event
            grapplingHook.OnInitializationComplete += SetAttachedGameObjects;

            // Start the coroutine to stop updating after 5 seconds

            grapplingHook.detachedHook += RemoveAttachedGameObjects;
        }

    }


    void SetAttachedGameObjects()
    {
        solver = grapplingHook.GetComponentInParent<ObiSolver>();
        ObiRope rope = ropeObject.GetComponent<ObiRope>();
        // The initialization is complete, execute your functions
        Debug.Log("Received initialization complete message");
        attachedGameObjects = new GameObject[rope.elements.Count];
        for (int i = 0; i < rope.elements.Count; i++)
        {
            // Get the predicted position of the particle
            Vector3 particlePosition = rope.GetParticlePosition(rope.solverIndices[i]);

            // Instantiate the attached GameObject at the particle's position
            GameObject attachedGameObject = Instantiate(attachedGameObjectPrefab, particlePosition, Quaternion.identity);
            attachedGameObject.name = "GameObject_" + i;
            // Parent the attached GameObject to this GameObject for organization
            attachedGameObject.transform.SetParent(transform);

            // Store reference to the attached GameObject in the array
            attachedGameObjects[i] = attachedGameObject;
        }
        createdRope = true;

    }

    void RemoveAttachedGameObjects()
    {
        createdRope = false;
        attachedGameObjects = null;
        // Loop through each child and destroy it
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (createdRope)
        {
            ObiRope rope = ropeObject.GetComponent<ObiRope>();
            for (int i = 0; i < attachedGameObjects.Length; i++)
            {
                // Get the predicted position of the particle from the solver
                Vector3 particlePosition = rope.GetParticlePosition(rope.solverIndices[i]);

                // Update the position of the attached GameObject to match the particle's position
                attachedGameObjects[i].transform.position = particlePosition;
            }
        }

    }
}
