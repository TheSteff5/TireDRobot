using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject checkpoint;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning("Collision entered");
        Debug.LogWarning(other);
        if (other.tag == "MainCamera")
        {
            Debug.LogWarning("PLAYER ENTERED");
            player.GetComponent<Rigidbody>().useGravity = false;
           // player.GetComponent<Rigidbody>().isKinematic = true;
            player.transform.position = checkpoint.transform.position;
        }

    }

}
