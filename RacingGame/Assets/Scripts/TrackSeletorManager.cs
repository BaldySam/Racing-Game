using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackSeletorManager : MonoBehaviour
{
    [SerializeField] private TMP_Text errorText;
    // Start is called before the first frame update
    void Start()
    {
        errorText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTrackOne()
    {
        SceneManager.LoadScene(1);
    }

    public void OnTrackTwo()
    {
        if(PlayerStats.TrackOneComplete == true)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            errorText.text = "You must finish first in Track One.";
            StartCoroutine(WaitForSeconds(3));
        }
    }

    public void OnTrackThree()
    {
        if(PlayerStats.TracktwoComplete == true)
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            errorText.text = "You must finish first in Track Two.";
            StartCoroutine(WaitForSeconds(3));
        }
    }

    IEnumerator WaitForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        errorText.text = "";
    }
}
