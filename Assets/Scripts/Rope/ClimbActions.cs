using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class ClimbActions : MonoBehaviour
{
    public void OnEntered(SelectEnterEventArgs args)
    {
        Debug.Log("Entered");
    }
}
