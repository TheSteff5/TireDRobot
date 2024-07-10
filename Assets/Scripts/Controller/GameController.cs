using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameController : MonoBehaviour
{
    public PlayerController player;
    public Checkpoint[] checkpoints;
    private Rigidbody playerRigidBody;

    public ActionBasedContinuousMoveProvider move;
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
      
        playerRigidBody.useGravity = false;

        //move.gravityApplicationMode = ContinuousMoveProviderBase.GravityApplicationMode.AttemptingMove;
       
    }

    public void removePlayerClimbing()
    {
        
        Debug.Log("stopped climbing");
        player.climbing = false;
     
            Debug.Log("use gravity");
            playerRigidBody.useGravity = true;
        
        //playerRigidBody.useGravity = false;
        //move.gravityApplicationMode = ContinuousMoveProviderBase.GravityApplicationMode.Immediately;
    }

    public void ResetState()
    {
       foreach(MoveableTarget target in targets)
        {
            target.stopMoving = false;
        }
    }
}
