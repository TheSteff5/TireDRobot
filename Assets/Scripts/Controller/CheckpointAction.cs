using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckpointAction : MonoBehaviour
{
    public PlayerController player;
    public GameObject checkpoint;
    public ClimbInteractable climbingController; 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCheckpoint()
    {
        if (climbingController != null && player != null)
        {
            climbingController.enabled = false;
            player.playerRig.transform.position = this.checkpoint.transform.position;
            climbingController.enabled = true;
        }
    }
}
