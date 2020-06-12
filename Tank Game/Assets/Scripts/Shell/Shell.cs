using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public float maxLifeTime = 2.0f;
    public int damage = 10;

    public ParticleSystem explosionParticles;

    void Start()
    {
        Destroy(gameObject, maxLifeTime);
    }

    void OnCollisionEnter(Collision other)
    {
        Rigidbody targetRigidbody = other.gameObject.GetComponent<Rigidbody>();
        if (targetRigidbody != null)
        {
            targetRigidbody.AddExplosionForce(damage, transform.position, 5);
        }

        Health targetHealth = other.gameObject.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage);
        }

        explosionParticles.transform.parent = null;
        explosionParticles.Play();
        Destroy(explosionParticles.gameObject, explosionParticles.duration);
        Destroy(gameObject);
    }
}
