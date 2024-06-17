using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public GameObject player;
    public GameObject checkpoint1; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCheckpoint1()
    {
        this.player.transform.position = this.checkpoint1.transform.position;
    }
}
