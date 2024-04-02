using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShootController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnTransform;
    public XRGrabInteractable interactable; 


    // Start is called before the first frame update
    void Start()
    {
        interactable.activated.AddListener(e =>
        {
            Instantiate(bulletPrefab, bulletSpawnTransform.position, bulletSpawnTransform.rotation);
        });
    }

}
