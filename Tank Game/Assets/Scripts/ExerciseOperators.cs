using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExerciseOperators : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float myVariable = 5;
        Debug.Log("Value of variables before: " + myVariable);

        myVariable %= 3;
        Debug.Log("The remainder is: " + myVariable);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
