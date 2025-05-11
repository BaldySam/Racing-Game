using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartingScript : MonoBehaviour
{
    public bool started;
    public bool startTimer;
    GameObject[] airacers;
    TMP_Text startText;
    float timer;
    CarControl player;
    // Start is called before the first frame update
    void Start()
    {
        startText = gameObject.GetComponent<TMP_Text>();
        airacers = GameObject.FindGameObjectsWithTag("AIRacerTag");
        for (int i = 0; i < airacers.Length; i++)
        {
            airacers[i].transform.GetChild(1).GetComponent<CarEnemy>().enabled = false;
        }
        
        player = GameObject.FindObjectOfType<CarControl>();
        player.enabled = false;
        startTimer = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(started == false)
        {
            startText.text = "Press Space to Start";
            if(Input.GetKeyDown(KeyCode.Space))
            {
                started = true;
            }
        }
        else
        {
            timer = timer + Time.deltaTime;
            if(timer < 1)
            {
                startText.text = "3";
            }
            else if(timer < 2)
            {
                startText.text = "2";
            }
            else if(timer < 3)
            {
                startText.text = "1";
            }
            else if(timer < 4)
            {
                startText.text = "GO!";
                for (int i = 0; i < airacers.Length; i++)
                {
                    airacers[i].transform.GetChild(1).GetComponent<CarEnemy>().enabled = true;
                }
                player.enabled = true;
                startTimer = true;

            }
            else if(timer < 5)
            {
                startText.text = "";
            }

        }
    }
}
