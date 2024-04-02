using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;

public class HandAnimator : MonoBehaviour
{
    public Animator animator;
    public InputActionProperty gripAction;
    public InputActionProperty triggerAction;

    // Update is called once per frame
    void Update()
    {
        var gripValue = gripAction.action.ReadValue<float>();
        animator.SetFloat("Grip", gripValue);

        var triggerValue = triggerAction.action.ReadValue<float>();
        animator.SetFloat("Trigger", triggerValue);
    }
}
