using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Rendering;

public class SphereController : MonoBehaviour
{
    public MeshRenderer renderer;
    public MaterialHelperBase materialBase;
    // Start is called before the first frame update
    void Start()
    {
        renderer.material = new Material(renderer.material);
        materialBase.rendererTarget = renderer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
