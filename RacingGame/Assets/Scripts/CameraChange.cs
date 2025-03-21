using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    [SerializeField] private GameObject[] cameras;
    private int currentCameraIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentCameraIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if(i == currentCameraIndex)
            {
                cameras[i].SetActive(true);
            }
            else
            {
                cameras[i].SetActive(false);
            }
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            currentCameraIndex++;
            if(currentCameraIndex >= cameras.Length)
            {
                currentCameraIndex = 0;
            }
        }
    }
}
