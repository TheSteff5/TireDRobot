using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class Bullet : MonoBehaviour
{

    public Rigidbody body;
    public float firepower = 2; 

    // Start is called before the first frame update
    void Start()
    {
        var force = transform.forward * firepower;
        body.AddForce(force, ForceMode.Impulse);
    }
}
