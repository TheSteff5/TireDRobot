using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbableSphere : MonoBehaviour
{

    private bool objectCollided = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (objectCollided)
        {
            Debug.Log("player is inside");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
    
       if(other.tag == "Player")
        {
            Debug.Log("entered true");
            objectCollided = true;
        }
   
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("disabled true");
            objectCollided = false;
        }
    }
}
