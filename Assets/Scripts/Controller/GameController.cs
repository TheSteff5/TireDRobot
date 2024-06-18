using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameController : MonoBehaviour
{
    public PlayerController player;
    public Checkpoint[] checkpoints;
    private Rigidbody playerRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = player.playerRig.GetComponent<Rigidbody>();
        playerRigidBody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPlayerClimbing()
    {
        player.climbing = true;
        Debug.Log(checkpoints[0].getArrived());
        if (checkpoints[0].getArrived())
        {
            playerRigidBody.useGravity = false;
        }
    }

    public void removePlayerClimbing()
    {
        player.climbing = false;
        if (checkpoints[0].getArrived())
        {
            playerRigidBody.useGravity = true;
        }
        //playerRigidBody.useGravity = false;
    }

}
