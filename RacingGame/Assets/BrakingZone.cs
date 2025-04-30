using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakingZone : MonoBehaviour
{
    float brakingForcePercent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyRacer"))
        {
            other.GetComponent<CarEnemy>().brakeTorque = other.GetComponent<CarEnemy>().brakeTorque  * brakingForcePercent;
        }

    }
}
