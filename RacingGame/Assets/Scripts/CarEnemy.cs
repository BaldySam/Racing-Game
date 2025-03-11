using UnityEngine;

public class CarEnemy : MonoBehaviour
{
    [Header("References")]
    private GameObject player;
    private CarControl carControl;

    [Header("Inputs")]
    private float hInput;
    private float vInput;

    [Header("Rubber Banding")]
    [SerializeField] private float teleportOffset;
    [SerializeField] private float playerDistanceOffset;
    public Terrain terrainCarIsIn;
    public Terrain[] terrains;
    private float distanceToPlayer;

    [Header("Obstacle Avoidance")]
    [SerializeField] private Vector3 coneOffset;
    [SerializeField] private Transform centrePoint;
    [SerializeField] private Transform centreRearPoint;
    [SerializeField] private float coneAngle; 
    [SerializeField] private float coneDistance; 
    [SerializeField] private Vector2 coneConstraints;
    private float time;

    [Header("Damage")]
    public float damageMultiplier;

    [Header("Steering")]
    private float AngleToPlayer;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        terrains = Terrain.activeTerrains;
        carControl = GetComponent<CarControl>();
        vInput = 1;
    }

    // Update is called once per frame
    void Update()
    {
        RubberBanding();
        ConeOfVisionAvoidance();
        carControl.hInput = hInput;
        carControl.vInput = vInput;
    }

    void RubberBanding()
    {
        distanceToPlayer = Vector3.Distance(new Vector3(player.transform.position.x, 0, player.transform.position.z), new Vector3(transform.position.x, 0, transform.position.z));

        if(distanceToPlayer > playerDistanceOffset)
        {
            TeleportToPlayer();
        }
    }

    void SteerInDirectionOfPlayer()
    {
        AngleToPlayer = Mathf.DeltaAngle(transform.localRotation.eulerAngles.y, Quaternion.LookRotation(player.transform.position - transform.position).eulerAngles.y) / 10;

        hInput = Mathf.Clamp(AngleToPlayer, -1, 1);
    }

    void TeleportToPlayer()
    {
        for(int i = 0; i < terrains.Length; i++)
        {
            Debug.Log(i);
            if(transform.position.x >= terrains[i].transform.position.x && transform.position.x <= terrains[i].transform.position.x + terrains[i].terrainData.size.x && transform.position.z >= terrains[i].transform.position.z && transform.position.z <= terrains[i].transform.position.z + terrains[i].terrainData.size.z)
            {
                terrainCarIsIn = terrains[i];
                break;
            }
        }

        transform.position = new Vector3(player.transform.position.x - player.transform.forward.x * teleportOffset, terrainCarIsIn.SampleHeight(transform.position) + terrainCarIsIn.transform.position.y + 2, player.transform.position.z - player.transform.forward.z * teleportOffset);
    }

    void ConeOfVisionAvoidance()
    {

        float dynamicConeDistance = coneDistance * carControl.forwardSpeed;
        dynamicConeDistance = Mathf.Clamp(dynamicConeDistance, coneConstraints.x, coneConstraints.y);

        Vector3 boxCenter = centrePoint.position + centrePoint.forward * (dynamicConeDistance / 2) + coneOffset;
        Collider[] hitColliders = Physics.OverlapBox(boxCenter, new Vector3(dynamicConeDistance / 2, 1, dynamicConeDistance / 2), centrePoint.rotation, ~LayerMask.GetMask("IgnoreObstacleAvoidance"));

        if(hitColliders.Length != 0)
        {
            Transform target = hitColliders[0].transform;
            Debug.Log(target);
            Debug.DrawLine(target.transform.position, target.transform.position + new Vector3 (1, 1, 1));
            float angleToObstacle = Mathf.DeltaAngle(transform.localRotation.eulerAngles.y, Quaternion.LookRotation(target.transform.position - centreRearPoint.position).eulerAngles.y);

            if (Mathf.Abs(angleToObstacle) < coneAngle / 2)
            {
                if(angleToObstacle > 0)
                {
                    angleToObstacle = (coneAngle / 2) - angleToObstacle;
                }
                else
                {
                    angleToObstacle = -(coneAngle / 2) - angleToObstacle;
                }

                Debug.Log(angleToObstacle);
                hInput = Mathf.Clamp(-angleToObstacle, -1, 1);

                if(carControl.forwardSpeed < 0.5f)
                {
                    vInput = -1;
                    hInput = -hInput;
                }
                else
                {
                    vInput = 1;
                }
            }
        }
        else
        {
            vInput = 1;
            SteerInDirectionOfPlayer();
        }

        if (carControl.forwardSpeed < 0.5f && carControl.forwardSpeed > -0.5f)
        {
            time += Time.deltaTime;
            if(time > 1)
            {
                vInput = -1;
                hInput = -hInput;
                time = 0;
                Invoke("StopReversing", 1f);
            }
        }
        else
        {
            time = 0;
        }

    }

    void StopReversing()
    {
        vInput = 1;
    }
}
