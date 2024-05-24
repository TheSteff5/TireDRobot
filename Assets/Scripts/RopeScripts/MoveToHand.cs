using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToHand : MonoBehaviour
{

    public GameObject rightHand;

    private Rigidbody rb;

    public void move()
    {
        Debug.Log("Position before: " + transform.position);

        rb = GetComponent<Rigidbody>();

        transform.position = rightHand.transform.position;
        rb.isKinematic = true;


        Debug.Log("Position changed to: " + transform.position);
        Debug.Log("HandPosition: " + rightHand.transform.position);

    }
}
