using UnityEngine;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;

public class PlayerCheckpointSorter : MonoBehaviour
{
    [SerializeField] public int maxLaps;
    [SerializeField] GameObject player;
    public int currentCheckpoint;
    [SerializeField] TMP_Text checkpointText;
    [SerializeField] TMP_Text lapTimeText;
    [SerializeField] StartingScript startingScript;
    public int maxCheckpoints;
    public int currentLap;
    public GameObject[] checkpoints;
    public int currentPosition;
    public CarEnemy[] carEnemy;
    public GameObject[] airacers;
    public float[] lapTimes;
    // Start is called before the first frame update
    void Start()
    {
        lapTimes = new float[maxLaps];
        carEnemy = new CarEnemy[airacers.Length];
        for (int i = 0; i < airacers.Length; i++)
        {
            carEnemy[i] = airacers[i].GetComponentInChildren<CarEnemy>();
        }
        checkpoints = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            checkpoints[i] = transform.GetChild(i).gameObject;
            checkpoints[i].GetComponent<MeshRenderer>().enabled = false;
        }

        maxCheckpoints = checkpoints.Length;
        checkpoints[0].GetComponent<MeshRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentCheckpoint >= maxCheckpoints)
        {
            currentCheckpoint = 0;
            currentLap ++;
        }



        if(Input.GetKey(KeyCode.R))
        {
            ResetPlayer();
        }

        checkpoints[currentCheckpoint].GetComponent<MeshRenderer>().enabled = true;

        currentPosition = carEnemy.Length + 1;
        for(int i = 0; i < carEnemy.Length; i++)
        {
            float carDistanceToNextCheckpoint = Vector3.Distance(airacers[i].transform.position, checkpoints[carEnemy[i].currentCheckpoint].transform.position);
            float playerDistanceToNextCheckpoint = Vector3.Distance(player.transform.position, checkpoints[currentCheckpoint].transform.position);

            if(carDistanceToNextCheckpoint > playerDistanceToNextCheckpoint && carEnemy[i].currentCheckpoint == currentCheckpoint && carEnemy[i].currentLap == currentLap)
            {
                currentPosition --;
            }
            else if(carEnemy[i].currentCheckpoint < currentCheckpoint && carEnemy[i].currentLap == currentLap)
            {
                currentPosition --;
            }
            else if(carEnemy[i].currentLap < currentLap)
            {
                currentPosition --;
            }
        } 

        checkpointText.text = "Checkpoint: " + (currentCheckpoint + 1) + "/" + maxCheckpoints + "\nLap: " + currentLap + "/" + maxLaps + "\nPosition: " + currentPosition + "/" + (carEnemy.Length + 1);

        if(startingScript.startTimer == true)
        {
            lapTimes[currentLap] += Time.deltaTime;
            lapTimeText.text = "Lap Times:\n";
            for(int i = 0; i < lapTimes.Length; i++)
            {
                if(lapTimes[i] > 0)
                {
                    lapTimeText.text += lapTimes[i].ToString("F2") + "s" + "\n";
                }
            }
        }
    }

    public void ResetPlayer()
    {
        player.SetActive(false);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        if(currentCheckpoint == 0)
        {
            player.transform.position = checkpoints[maxCheckpoints - 1].transform.position;
            player.transform.rotation = checkpoints[maxCheckpoints - 1].transform.rotation;
        }
        else
        {
            player.transform.position = checkpoints[currentCheckpoint - 1].transform.position;
            player.transform.rotation = checkpoints[currentCheckpoint - 1].transform.rotation;
        }
        player.SetActive(true);
    }
}
