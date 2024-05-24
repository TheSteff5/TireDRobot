using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attach : MonoBehaviour
{   
    public Obi.ObiRope obiRope; // Reference to the Obi rope component
    public MeshCollider meshCollider; // Reference to the Mesh Collider component

    void Start()
    {
        if (obiRope != null && meshCollider != null)
        {
            // Assign the extruded mesh to the Mesh Collider
            meshCollider.sharedMesh = obiRope.GetComponent<MeshFilter>().mesh;
            Debug.Log(meshCollider.sharedMesh);
        }
        else
        {
            Debug.LogWarning("Obi rope or Mesh Collider references not set.");
        }
    }

}
