using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveSword : MonoBehaviour
{
    public GameObject rightHand;
    public InputActionReference secondaryButtonReference;

    private Rigidbody rb;

    private void Awake()
    {
        secondaryButtonReference.action.Enable();
        secondaryButtonReference.action.performed += Move;
    }

    private void Move(InputAction.CallbackContext context)
    {

        rb = GetComponent<Rigidbody>();

        transform.position = rightHand.transform.position;
        rb.isKinematic = true;
    }
}
