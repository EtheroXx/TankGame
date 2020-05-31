using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    int fuel;
    public int maxFuel = 100;
    public int distancePerFuel = 10;

    float distanceTravelled;
    float distanceTillFuelLoss;
    Vector3 lastPosition;

    public Transform Turret;
    LayerMask layerMask;

    public float speed = 12f;
    public float turnSpeed = 180f;


    private Rigidbody rb;
    private float movementInput;
    private float turnInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        lastPosition = transform.position;
        distanceTillFuelLoss = distanceTravelled + distancePerFuel;
        fuel = maxFuel;
    }

    // Enables the players tank
    void OnEnable()
    {
        rb.isKinematic = false;
        movementInput = 0f;
        turnInput = 0f;
    }

    // Disables the players tank
    void OnDisable()
    {
        rb.isKinematic = false;
    }

    // Allows vertical movement
    void Move()
    {
        Vector3 movement = transform.forward * movementInput * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    // Allows turn based movement
    void Turn()
    {
        float turn = turnInput * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        layerMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        MouseAim();

        CheckFuel();
    }

    void FixedUpdate()
    {
        if (fuel > 0)
        {
            Move();
            Turn();
        }
    }

    //Focuses turret to mouse position
    void MouseAim()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitResult = new RaycastHit();

        if (Physics.Raycast(ray, out hitResult, Mathf.Infinity, layerMask))
        {
            Turret.LookAt(hitResult.point);
            Turret.eulerAngles = new Vector3(0, Turret.eulerAngles.y, Turret.eulerAngles.z);
        }

    }

    //Checks and subtracts fuel after tank movement
    void CheckFuel()
        {
            distanceTravelled += Vector3.Distance(transform.position, lastPosition);
            lastPosition = transform.position;

            if (distanceTravelled >= distanceTillFuelLoss)
            {
                distanceTillFuelLoss = distanceTravelled + distancePerFuel;
                fuel--;

                //Debug.Log(distanceTravelled + " : " + fuel);
            }
        }

    //Refuels tank
    public void ReFuel(int fuelAmount = 100)
    {
        fuel = fuelAmount;
        if (fuel > maxFuel)
        {
            fuel = maxFuel;
        }
    }
}
