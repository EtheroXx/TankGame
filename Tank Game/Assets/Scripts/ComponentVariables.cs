using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentVariables : MonoBehaviour
{

    Renderer Mesh;

    // Start is called before the first frame update
    void Start()
    {
        Mesh = GetComponent<Renderer>();
        Mesh.material.color = Color.red;

        Debug.Log(transform);
        Debug.Log("Position: " + transform.position);
        Debug.Log("Rotation: " + transform.rotation);
        Debug.Log("Scale: " + transform.localScale);
        Debug.Log("x Position: " + transform.position.x);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
