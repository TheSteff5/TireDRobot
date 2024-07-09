using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableTarget : MonoBehaviour
{
    public float speed = 1.0f;
    public float amplitude = 1.0f;
    private Vector3 initialPosition;
    private bool stopMoving = false;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (stopMoving) return;

        float x = Mathf.Sin(Time.time * speed) * amplitude;

        transform.position = new Vector3(initialPosition.x + x, initialPosition.y, initialPosition.z);
    }

    // This method is called when the cube enters a trigger collider
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        // Stop the movement when the cube collides with a non-trigger object
        if (!other.isTrigger)
        {
            stopMoving = true;
        }
    }
}
