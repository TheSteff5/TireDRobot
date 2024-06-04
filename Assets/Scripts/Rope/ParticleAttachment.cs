using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAttachment : MonoBehaviour
{


    public ObiRope rope;
    public ObiSolver solver;
    public GameObject attachedGameObjectPrefab;
    private GameObject[] attachedGameObjects;
    void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        attachedGameObjects = new GameObject[solver.allocParticleCount];
        for (int i = 0; i < solver.allocParticleCount; i++)
        {
            // Get the predicted position of the particle
            Vector3 particlePosition = solver.renderablePositions[i];

            // Instantiate the attached GameObject at the particle's position
            GameObject attachedGameObject = Instantiate(attachedGameObjectPrefab, particlePosition, Quaternion.identity);
            attachedGameObject.name = "GameObject_" + i;
            // Parent the attached GameObject to this GameObject for organization
            attachedGameObject.transform.SetParent(transform);

            // Store reference to the attached GameObject in the array
            attachedGameObjects[i] = attachedGameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < attachedGameObjects.Length; i++)
        {
            // Get the predicted position of the particle from the solver
            Vector3 particlePosition = solver.renderablePositions[i];

            // Update the position of the attached GameObject to match the particle's position
            attachedGameObjects[i].transform.position = particlePosition;
        }
    }
}
