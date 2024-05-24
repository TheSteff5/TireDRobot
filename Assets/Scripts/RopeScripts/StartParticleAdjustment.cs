using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class StartParticleAdjustment : MonoBehaviour
{
    public GameObject Handle;
    public ObiRope rope;

    private int firstParticle;
    public float distance = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        firstParticle = rope.elements[4].particle1;

        Debug.Log("Particle: " + rope.solver.positions[firstParticle] + "Handle: " + Handle.transform.position);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //rope.solver.positions[firstParticle] = Handle.transform.position + Handle.transform.forward * distance;

    }
}
