using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankMovement : MonoBehaviour
{
    public Transform baseLocation;
    public Transform turret;
    private bool follow = false;
    public float closeDistance = 8f;
    private Transform target;
    private NavMeshAgent navAgent;
    private Rigidbody rb;

    void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (follow == false)
        {
            return;
        }

        float distance = (target.position - transform.position).magnitude;

        if (distance > closeDistance)
        {
            navAgent.SetDestination(target.position);
            navAgent.isStopped = false;
        }

        else
        {
            navAgent.isStopped = true;
        }

        if (turret != null)
        {
            turret.LookAt(target.transform);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            follow = true;
        }

        else if (other.tag == "EnemyBase")
        {
            navAgent.isStopped = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            follow = false;
            navAgent.SetDestination(baseLocation.position);
        }
    }
}
