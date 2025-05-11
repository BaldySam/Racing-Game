using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakingZone : MonoBehaviour
{
    [SerializeField] float brakingForcePercent;
    // Start is called before the first frame update

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("EnemyRacer"))
        {
            other.transform.parent.GetComponent<CarEnemy>().brakeTorque = other.transform.parent.GetComponent<CarEnemy>().brakeTorque  * brakingForcePercent; 
        }
    }
}
