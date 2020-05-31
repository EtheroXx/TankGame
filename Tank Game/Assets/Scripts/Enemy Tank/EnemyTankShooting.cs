using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankShooting : MonoBehaviour
{
    public Rigidbody shellPrefab;
    public Transform cannonTransform;
    public float launchForce = 30f;

    private bool canShoot;

    float shootDelay = 1f;
    float shootTimer;

    void Update()
    {
        shootTimer -= Time.deltaTime;
        if (canShoot == true)
        {
            if (shootTimer <= 0)
            {
                shootTimer = shootDelay;
                Fire();
            }
        }
    }

    void Fire()
    {
        Rigidbody shellInstance = Instantiate(shellPrefab, cannonTransform.position, cannonTransform.rotation);
        shellInstance.velocity = launchForce * cannonTransform.forward;
    }

    void OnEnable()
    {
        canShoot = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canShoot = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canShoot = false;
        }
    }
}
