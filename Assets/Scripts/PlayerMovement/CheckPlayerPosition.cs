using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerPosition : MonoBehaviour
{
    public GameObject playerCamera; 
    public GameObject playerPos;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

      
        //Debug.Log("HELLO");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("Player is DEAD!");


            playerPos.GetComponent<Transform>().position = new Vector3(0, 0, 0);

            // Perform additional actions here
        }
    }
}
