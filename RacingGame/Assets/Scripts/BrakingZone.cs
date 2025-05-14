using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakingZone : MonoBehaviour
{
    [SerializeField] float brakingForcePercent;
    GameObject brakingObject;
    bool isBrakingZone;
    // Start is called before the first frame update

    void Update()
    {
        if(isBrakingZone)
        {
            if(brakingObject.name == "Exterior + Collider")
            {
                brakingObject.transform.parent.GetComponent<CarEnemy>().currentBrakeTorque = brakingObject.transform.parent.GetComponent<CarEnemy>().brakeTorque  * brakingForcePercent; 
                brakingObject.transform.parent.GetComponent<CarEnemy>().currentMotorTorque = 0;
            }
            else
            {
                brakingObject.transform.GetComponent<CarEnemy>().currentBrakeTorque = brakingObject.transform.GetComponent<CarEnemy>().brakeTorque  * brakingForcePercent;
                brakingObject.transform.GetComponent<CarEnemy>().currentMotorTorque = 0; 
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("EnemyRacer"))
        {
            brakingObject = other.gameObject;
            isBrakingZone = true;
        }
        else
        {
            brakingObject = null;
            isBrakingZone = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        brakingObject = null;
        isBrakingZone = false;
    }
}

