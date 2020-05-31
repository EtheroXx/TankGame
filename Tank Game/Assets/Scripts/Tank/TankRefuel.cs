using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankRefuel : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        TankMovement tankCol = col.transform.GetComponent<TankMovement>();
        if (tankCol != null)
        {
            tankCol.ReFuel();
        }
    }
}
