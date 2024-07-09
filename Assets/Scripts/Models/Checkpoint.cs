
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint: MonoBehaviour
{
    private bool arrived;

    void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning("Collision entered");
        if(other.tag == "Player" && !this.arrived)
        {
            other.transform.position = transform.position;
            this.arrived = true;
            other.attachedRigidbody.useGravity = false;

        }
        
    }
  
    public bool getArrived()
    {
        return this.arrived;
    }

    public void setArrived(bool arrived)
    {
        this.arrived = arrived; 
    }

}
