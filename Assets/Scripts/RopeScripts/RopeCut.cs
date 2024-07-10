using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObiRopeCut
{
    public bool cut;
    public ObiRope rope;
}
public class RopeCut : MonoBehaviour
{
    public GameObject spawn;
    public GameObject player;
    public ObiSolver solver;
    public ObiRope[] ropes;
    public GameObject text;

    private ObiRopeCut[] obiRopeCuts;

    void Awake()
    {
        obiRopeCuts = new ObiRopeCut[ropes.Length];
        for (int i = 0; i < ropes.Length; i++)
        {
            obiRopeCuts[i] = new ObiRopeCut();
            obiRopeCuts[i].cut = false;
            obiRopeCuts[i].rope = ropes[i];
        }
        text.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CutCollider"))
        {



            ObiRope rope = other.GetComponentInParent<ObiRope>();
            for (int i = 0; i < ropes.Length; i++)
            {
                if (obiRopeCuts[i].rope.Equals(rope))
                {

                    FindClosestParticle(rope, obiRopeCuts[i]);
                    // Check if all values in the array are true
                    if (obiRopeCuts.All(value => value.cut))
                    {
                        // Trigger the function
                        OnAllValuesTrue();
                    }
                }
            }



        }
        else
        {
            Debug.Log("GameObject is not Rope");
        }
    }

    private void FindClosestParticle(ObiRope rope, ObiRopeCut ropeCut)
    {
        bool cut = false;
        float minDistance = float.MaxValue;
        int closestParticleIndex = -1;
        Vector3 swordPosition = transform.position;

        for (int i = 0; i < rope.elements.Count; i++)
        {
            Vector3 particlePosition = rope.GetParticlePosition(rope.solverIndices[i]);

            float distance = Vector3.Distance(swordPosition, particlePosition);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestParticleIndex = i;
            }
        }

        if (closestParticleIndex != -1)
        {
            rope.Tear(rope.elements[closestParticleIndex]);
            ropeCut.cut = true;
        }

        if (ropeCut.cut)
        {
            rope.RebuildConstraintsFromElements();
        }
    }

    void OnAllValuesTrue()
    {
        text.SetActive(true);
    }

}
