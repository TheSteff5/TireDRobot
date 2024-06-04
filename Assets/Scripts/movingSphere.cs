using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class movingSphere : MonoBehaviour
{

    float currentX;
    float newX = 0;
  
    // Start is called before the first frame update
    void Start()
    {
        currentX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(Time.time * 0.2f) * 5 + 0, transform.position.y, transform.position.z);
        /*
        newX = currentX + (Mathf.Sin(Time.deltaTime * 3f + 10))*50;
        transform.position = new Vector3(newX, 0, 0);*/
    }
}
