using UnityEngine;

public class Checkpoint : MonoBehaviour
{
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
            for(int i = 0; i < other.GetComponentInParent<CarEnemy>().checkpoints.Length; i++)
            {
                if(other.GetComponentInParent<CarEnemy>().checkpoints[i] == gameObject)
                {
                    if(other.GetComponentInParent<CarEnemy>().checkpointIndex == i)
                    {
                        if(other.GetComponentInParent<CarEnemy>().checkpointIndex == other.GetComponentInParent<CarEnemy>().checkpoints.Length - 1)
                        {
                            other.GetComponentInParent<CarEnemy>().checkpointIndex = 0;
                        }
                        else
                        {
                            other.GetComponentInParent<CarEnemy>().checkpointIndex++;
                        }
                    }
                }
            }
        }
    }
}
