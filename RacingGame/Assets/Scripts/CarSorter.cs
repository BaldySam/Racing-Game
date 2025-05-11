using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSorter : MonoBehaviour
{
    CarControl carControl;
    float baseTorque = 300f;
    float torqueMultiplier = 100f;
    float baseBrakeTorque = 150f;
    float brakeTorqueMultiplier = 50f;
    float baseMaxSpeed = 40f;
    float maxSpeedMultiplier = 10f;
    float baseGrip = 10f;
    float gripMultiplier = 3;
    private WheelCollider[] wheels;
    // Start is called before the first frame update
    void Start()
    {
        carControl = transform.GetComponent<CarControl>();
        wheels = GetComponentsInChildren<WheelCollider>();

        carControl.motorTorque = baseTorque + (torqueMultiplier * PlayerStats.Acceleration.x);
        carControl.brakeTorque = baseBrakeTorque + (brakeTorqueMultiplier * PlayerStats.Braking.x);
        carControl.maxSpeed = baseMaxSpeed + (maxSpeedMultiplier * PlayerStats.TopSpeed.x);

        foreach (WheelCollider wheel in wheels)
        {
            // Access the sideways friction curve (similar to above)
            WheelFrictionCurve sidewaysFrictionCurve = wheel.sidewaysFriction;

            // Set the extremum slip for the sideways friction
            sidewaysFrictionCurve.extremumSlip = (baseGrip + (PlayerStats.Grip.x * gripMultiplier)) / 2; // Example value: adjust as needed
            sidewaysFrictionCurve.extremumValue = baseGrip + (PlayerStats.Grip.x * gripMultiplier); // Example value: adjust as needed

            // Update the wheel collider with the modified curve
            wheel.sidewaysFriction = sidewaysFrictionCurve;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
