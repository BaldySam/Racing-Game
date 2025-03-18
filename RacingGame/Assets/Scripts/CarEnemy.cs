using System;
using UnityEngine;
using UnityEngine.AI;

public class CarEnemy : MonoBehaviour
{
    public float motorTorque = 2000;
    public float brakeTorque = 2000;
    public float maxSpeed = 20;
    public float centreOfGravityOffset = -1f;
    public float currentMotorTorque;
    public float decelerationMultiplier;
    public float currentBrakeTorque;
    public float forwardSpeed;


    [SerializeField] private float brakeMultiplier;

    private WheelControl[] wheels;
    private Rigidbody rigidBody;
    [Header("References")]
    private GameObject player;
    private CarControl carControl;

    [Header("Inputs")]
    private float hInput;
    private float vInput;

    [Header("Obstacle Avoidance")]
    [SerializeField] private GameObject agentObject;
    [SerializeField] private float maxCornerDistance;
    private NavMeshAgent agent;
    public Vector3 targetPos;
    public float time;

    [Header("Damage")]
    public float damageMultiplier;
    public bool reversing;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        carControl = GetComponent<CarControl>();
        agent = agentObject.GetComponent<NavMeshAgent>();

        rigidBody = GetComponent<Rigidbody>();
        rigidBody.centerOfMass += Vector3.up * centreOfGravityOffset;
        wheels = GetComponentsInChildren<WheelControl>();
        // agent.isStopped = true;
        currentBrakeTorque = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.nextPosition.x != transform.position.x || agent.nextPosition.z != transform.position.z)
        {
            agentObject.transform.position = transform.position;
        }

        forwardSpeed = Vector3.Dot(transform.forward, rigidBody.velocity);
        // if(Mathf.Abs(forwardSpeed) < 0.5f || reversing)
        // {
        //     time += Time.deltaTime;
        //     if(time > 1)
        //     {
        //         reversing = true;
        //         currentMotorTorque = -motorTorque;
        //         currentBrakeTorque = 0;
        //         hInput = -hInput;
        //         if(time > 3)
        //         {
        //             reversing = false;
        //             time = 0;
        //             currentMotorTorque = motorTorque;
        //         }
        //     }
        //     else
        //     {
        //         if(Mathf.Abs(hInput) > 5)
        //         {
        //             currentBrakeTorque = Mathf.Abs(hInput) * brakeMultiplier * Mathf.Abs(forwardSpeed);
        //         }
        //         else if(Mathf.Abs(hInput) > 30)
        //         {
        //             currentMotorTorque = motorTorque / 2;
        //             currentBrakeTorque = Mathf.Abs(hInput) * brakeMultiplier * 2 * Mathf.Abs(forwardSpeed);
        //         }
        //         else if(Mathf.Abs(hInput) > 40)
        //         {
        //             currentMotorTorque = motorTorque / 5;
        //             currentBrakeTorque = Mathf.Abs(hInput) * brakeMultiplier * 4 * Mathf.Abs(forwardSpeed);
        //         }
        //         else
        //         {
        //             currentMotorTorque = motorTorque;
        //             currentBrakeTorque = 0;
        //         }
        //     }
        // }
        // else
        // {
        //     time = 0;
        //     if(Mathf.Abs(hInput) > 5)
        //     {
        //         currentBrakeTorque = Mathf.Abs(hInput) * brakeMultiplier * Mathf.Abs(forwardSpeed);
        //     }
        //     else if(Mathf.Abs(hInput) > 30)
        //     {
        //         currentMotorTorque = motorTorque / 2;
        //         currentBrakeTorque = Mathf.Abs(hInput) * brakeMultiplier * 2 * Mathf.Abs(forwardSpeed);
        //     }
        //     else if(Mathf.Abs(hInput) > 40)
        //     {
        //         currentMotorTorque = motorTorque / 5;
        //         currentBrakeTorque = Mathf.Abs(hInput) * brakeMultiplier * 4 * Mathf.Abs(forwardSpeed);
        //     }
        //     else
        //     {
        //         currentMotorTorque = motorTorque;
        //     }
        // }
        DriveCar();
    }

    void FixedUpdate()
    {
        agent.SetDestination(player.transform.position);
        if(agent.path.corners.Length > 2)
        {
            float distanceToFirstCorner = Vector3.Distance(transform.position, agent.path.corners[1]);
            Debug.Log(distanceToFirstCorner);
            if(distanceToFirstCorner < maxCornerDistance)
            {
                targetPos = agent.path.corners[2];
            }
            else
            {
                targetPos = agent.path.corners[1];
            }
        }
        else
        {
            targetPos = agent.path.corners[1];
        }

        hInput = Mathf.DeltaAngle(transform.localRotation.eulerAngles.y, Quaternion.LookRotation(targetPos - transform.position).eulerAngles.y);
    }

    void DriveCar()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.steerable)
            {
                wheel.WheelCollider.steerAngle = Mathf.Clamp(hInput, -45, 45);
            }
        
            if (wheel.motorized)
            {
                wheel.WheelCollider.motorTorque = currentMotorTorque;
            }

            wheel.WheelCollider.brakeTorque = currentBrakeTorque;
        }
    }
}
