using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject checkpoint;
    public GameObject player;
    public GameObject gunObject;
    public VRGrapplingHook grapplingHook;
    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
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
            if (grapplingHook != null && gunObject != null)
            {
                grapplingHook.DetachHook();
                gunObject.transform.position = checkpoint.transform.position;
            }
            gameController.ResetState();
            // player.GetComponent<Rigidbody>().isKinematic = true;

            Invoke("setPosition", 0.5f); // 


         


        }

    }

    void setPosition()
    {
        player.transform.position = checkpoint.transform.position;

     
    }

}
