using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbableSphere : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.tag == "Player")
        {
            Debug.Log("Its a Player");
            Debug.Log(gameObject.name);
        }

            Debug.Log(other);
    }
}
