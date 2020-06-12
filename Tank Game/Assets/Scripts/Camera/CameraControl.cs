using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float dampTime = 0.2f;
    private Vector3 moveVelocity;

    public Transform target;
    private Vector3 desiredPosition;

    public float zoomSpeed = 10;

    void Update()
    {
        //Scroll Function (For Debugging)
        /*float zoom = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.orthographicSize += -zoom * zoomSpeed;*/
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Move();
    }

    private void Move()
    {
        desiredPosition = target.position;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition,
            ref moveVelocity, dampTime);
    }
}


