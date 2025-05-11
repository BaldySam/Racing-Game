using UnityEngine;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;

public class PlayerCheckpointSorter : MonoBehaviour
{
    [SerializeField] int maxLaps;
    [SerializeField] GameObject player;
    public int currentCheckpoint;
    [SerializeField] TMP_Text checkpointText;
    public int maxCheckpoints;
    int currentLap;
    public GameObject[] checkpoints;
    int currentPosition;
    public CarEnemy[] carEnemy;
    public GameObject[] airacers;

    // Start is called before the first frame update
    void Start()
    {
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

        checkpointText.text = "Checkpoint: " + (currentCheckpoint + 1) + "/" + maxCheckpoints + "\nLap: " + currentLap + "\nPosition: " + currentPosition + "/" + (carEnemy.Length + 1);

    }
}
