using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject spawn;
    public PlayerController player;
    public ClimbInteractable climbingController;
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
        if (climbingController != null && player != null)
        {
            climbingController.enabled = false;
            if (other.tag == "MainCamera")
            {
                player.GetComponent<Rigidbody>().useGravity = false;
                player.playerRig.transform.position = spawn.transform.position;
            }
            climbingController.enabled = true;
        }
    }
}
