using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackSeletorManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
        SceneManager.LoadScene(2);
    }

    public void OnTrackThree()
    {
        SceneManager.LoadScene(3);
    }
}
