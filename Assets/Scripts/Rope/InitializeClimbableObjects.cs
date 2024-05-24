using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InitializeClimbableObjects : MonoBehaviour
{
    public ClimbInteractable climbInteractable;
    // Start is called before the first frame update
    void Start()
    {
        // Ensure the Climb Interactable component is referenced
        climbInteractable = GetComponent<ClimbInteractable>();
        // Start a coroutine to wait for and assign colliders
        StartCoroutine(AssignCollidersAfterDelay());
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator AssignCollidersAfterDelay()
    {
        // Adjust the delay based on when the colliders are generated
        yield return new WaitForSeconds(1f); // 1 second delay

        // Find and assign all collider children
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            GameObject childGameObject = child.gameObject;
            climbInteractable.colliders.Insert(i, childGameObject.GetComponent<Collider>());
            // Do something with the child GameObject
            Debug.Log("Child GameObject name: " + childGameObject.name);
        }
    }

}