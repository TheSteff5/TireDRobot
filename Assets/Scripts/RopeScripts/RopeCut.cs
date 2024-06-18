using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCut : MonoBehaviour
{

    public ObiSolver solver;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ObiRope>() != null)
        {
            ObiRope rope = other.GetComponent<ObiRope>();
            FindClosestParticle(rope);
        } else
        {
            Debug.Log("GameObject is not Rope");
        }
    }

    private void FindClosestParticle(ObiRope rope)
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
            cut = true;
        }

        if (cut)
        {
            rope.RebuildConstraintsFromElements();
        }
    }
}
