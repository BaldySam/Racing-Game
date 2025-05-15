using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    PlayerCheckpointSorter playerCheckpointSorter;
    [SerializeField] bool isFinishLine;
    [SerializeField] EndResults endResults;
    // Start is called before the first frame update
    void Start()
    {
        playerCheckpointSorter = GameObject.FindWithTag("PlayerCheckpointSorter").GetComponent<PlayerCheckpointSorter>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(gameObject == playerCheckpointSorter.checkpoints[playerCheckpointSorter.currentCheckpoint])
            {
                playerCheckpointSorter.currentCheckpoint ++;
                gameObject.GetComponent<MeshRenderer>().enabled = false;
            }

        }
        else if(other.CompareTag("EnemyRacer"))
        {
            if(gameObject == playerCheckpointSorter.checkpoints[other.transform.parent.GetComponent<CarEnemy>().currentCheckpoint])
            {
                if(isFinishLine)
                {
                    endResults.AIFinished = true;
                }
                other.transform.parent.GetComponent<CarEnemy>().currentCheckpoint ++;
            }
        }
    }
}
