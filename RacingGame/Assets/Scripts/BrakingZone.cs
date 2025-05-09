using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakingZone : MonoBehaviour
{
    [SerializeField] float brakingForcePercent;
    bool inBrakingZone;
    Collider aiRacer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inBrakingZone)
        {
            aiRacer.GetComponent<CarEnemy>().brakeTorque = aiRacer.GetComponent<CarEnemy>().brakeTorque  * brakingForcePercent;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyRacer"))
        {
            inBrakingZone = true;
            aiRacer = other;
        }
        else
        {
            inBrakingZone = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EnemyRacer"))
        {
            inBrakingZone = false;
        }
    }
}
