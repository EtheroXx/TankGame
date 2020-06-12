using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public Rigidbody shellPrefab;
    public Transform cannonTransform;
    public float launchForce = 30f;

    void Fire()
    {
        Rigidbody shellInstance = Instantiate(shellPrefab, cannonTransform.position, cannonTransform.rotation);
        shellInstance.velocity = launchForce * cannonTransform.forward;
    }

    void Update()
    {
        if (GameManager.isPaused)
        {
            return;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            Fire();
        }
    }
}
