
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using System.Net;
using Unity.VisualScripting;

public class InteractableEventDemo: MonoBehaviour
{

    public Rigidbody player;
    public GameObject sphere;
    public Transform startPoint;
    public Transform endPoint;
    private bool selected = false;
    private bool startedClimbing = false;
    public float speed = 0.1f;
    private bool movingForward = true;
    private float journeyLength;
    float distance = 0;
    private float startTime;

    public Transform playerPos; 


    void Start()
    {
        playerPos = gameObject.GetComponent<Transform>();

        startTime = Time.time;
        player.useGravity = false;
        journeyLength = Vector3.Distance(startPoint.position, endPoint.position);
    }

    void Update()
    {
        // Calculate the distance traveled since the start
        float distCovered = (Time.time - startTime) * speed;

        // Calculate the fraction of the journey completed
        float fracJourney = distCovered / journeyLength;

        // Move the sphere along the path using Lerp
        sphere.transform.position = Vector3.Lerp(startPoint.position, endPoint.position, fracJourney);

        // If the journey is completed, reverse direction
        if (fracJourney >= 1.0f)
        {
            ReverseDirection();
        }

            

            distance = Mathf.Abs(playerPos.transform.position.z - sphere.transform.position.z);

        // Calculate the direction of movement
        // Calculate the position where the player should be on the rope
        Vector3 playerPosition = new Vector3(playerPos.transform.position.x, playerPos.transform.position.y, sphere.transform.position.z);

        // Move the player to the calculated position
        playerPos.transform.position = playerPosition;

    }

    // This method will be called when the Select Entered event is triggered
    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Your logic here
        player.useGravity = false;
        Debug.Log("Select Entered: " + args.interactableObject);
        startedClimbing = true; 
    }

    public void OnSelectExitd(SelectExitEventArgs args)
    {
        // Your logic here
        player.useGravity = true;
        Debug.Log("Select Entered: " + args.interactableObject);

    }

    void ReverseDirection()
    {
        // Swap start and end points
        Transform temp = startPoint;
        startPoint = endPoint;
        endPoint = temp;

        // Reset start time and recalculate journey length
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPoint.position, endPoint.position);
    }
}
