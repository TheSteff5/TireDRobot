using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToHand : MonoBehaviour
{

    public GameObject rightHand;
    public GameObject rope;

    private Rigidbody rb;

    public void move()
    {

        rb = GetComponent<Rigidbody>();

        transform.position = rightHand.transform.position;
        rb.isKinematic = true;

        VRGrapplingHook hook = rope.GetComponent<VRGrapplingHook>();

        hook.DetachHook();
    }
}
