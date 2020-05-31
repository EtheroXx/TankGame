using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExerciseVariables : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string greetings = "Hello User: ";
        int playerNumber = 0;
        string displayGreeting = greetings + playerNumber;
        Debug.Log(displayGreeting);

        displayGreeting = greetings + playerNumber;
        Debug.Log(displayGreeting);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
