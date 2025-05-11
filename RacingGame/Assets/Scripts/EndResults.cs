using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndResults : MonoBehaviour
{
    PlayerCheckpointSorter playerCheckpointSorter;
    [SerializeField] Canvas InGameUI;
    [SerializeField] Canvas EndResultsUI;
    [SerializeField] float moneyMultiplier;
    TMP_Text endResultsText;
    public int positionFinished;
    public float moneyEarned;
    bool ended;
    float bestLapTime;

    // Start is called before the first frame update
    void Start()
    {
        endResultsText = GetComponent<TMP_Text>();
        endResultsText.text = "";
        playerCheckpointSorter = GameObject.FindWithTag("PlayerCheckpointSorter").GetComponent<PlayerCheckpointSorter>();
        InGameUI.enabled = true;
        EndResultsUI.enabled = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerCheckpointSorter.currentLap == playerCheckpointSorter.maxLaps + 1 && ended == false)
        {
            ended = true;
            positionFinished = playerCheckpointSorter.currentPosition;
            moneyEarned = (playerCheckpointSorter.carEnemy.Length + 2 - positionFinished) * moneyMultiplier;
            InGameUI.enabled = false;
            EndResultsUI.enabled = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            for(int i = 0; i < playerCheckpointSorter.lapTimes.Length; i++)
            {
                if(playerCheckpointSorter.lapTimes[i] > 0)
                {
                    if(bestLapTime == 0 || playerCheckpointSorter.lapTimes[i] < bestLapTime)
                    {
                        bestLapTime = playerCheckpointSorter.lapTimes[i];
                    }
                }
            }
            endResultsText.text = "Your Lap Times:\n"
            + "---------------------\n";
            for(int i = 0; i < playerCheckpointSorter.lapTimes.Length; i++)
            {
                if(playerCheckpointSorter.lapTimes[i] > 0)
                {
                    endResultsText.text += "Lap " + (i + 1) + ": " + playerCheckpointSorter.lapTimes[i].ToString("F2") + "s\n";
                }
            }
            endResultsText.text += "---------------------\n"
            + "Your Best Lap: " + bestLapTime.ToString("F2") + "s\n"
            + "---------------------\n"
            + "Your Position: " + positionFinished + "\n"
            + "Money Earned: " + moneyEarned.ToString("F2") + "\n"
            + "---------------------\n";
        
            PlayerStats.Money += moneyEarned;
        }
    }
}
