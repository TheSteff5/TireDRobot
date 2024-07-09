using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveToHand : MonoBehaviour
{

    public GameObject rightHand;
    public GameObject rope;
    public InputActionReference primaryButtonReference;

    private Rigidbody rb;

    private void Awake()
    {
        primaryButtonReference.action.Enable();
        primaryButtonReference.action.performed += Move;
    }

    private void Move(InputAction.CallbackContext context)
    {

        rb = GetComponent<Rigidbody>();

        transform.position = rightHand.transform.position;
        rb.isKinematic = true;

        VRGrapplingHook hook = rope.GetComponent<VRGrapplingHook>();

        hook.DetachHook();
    }
}
