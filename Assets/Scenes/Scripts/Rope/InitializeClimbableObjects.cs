using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InitializeClimbableObjects : MonoBehaviour
{
    public ClimbInteractable climbInteractable;
    public VRGrapplingHook grapplingHook;
    // Start is called before the first frame update
    void Start()
    {
        if (grapplingHook != null)
        {
            // Subscribe to the event
            grapplingHook.OnInitializationComplete += OnInitializationDone;
        }
   
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnInitializationDone()
    {
        // Ensure the Climb Interactable component is referenced
        climbInteractable = GetComponent<ClimbInteractable>();
        // Start a coroutine to wait for and assign colliders
        StartCoroutine(AssignCollidersAfterDelay());
    }

    private IEnumerator AssignCollidersAfterDelay()
    {
        // Adjust the delay based on when the colliders are generated
        yield return new WaitForSeconds(1f); // 1 second delay

        // Find and assign all collider children
        for (int i = 0; i < climbInteractable.transform.childCount; i++)
        {
            Transform child = climbInteractable.transform.GetChild(i);
            GameObject childGameObject = child.gameObject;
            climbInteractable.colliders.Insert(i, childGameObject.GetComponent<Collider>());
        }
        yield return new WaitForEndOfFrame();
        climbInteractable.interactionManager.UnregisterInteractable(climbInteractable as IXRInteractable);
        yield return new WaitForEndOfFrame();
        climbInteractable.interactionManager.RegisterInteractable(climbInteractable as IXRInteractable);

    }

}
