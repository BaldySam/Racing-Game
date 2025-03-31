using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    [SerializeField] private GameObject[] cameras;
    private int currentCameraIndex;
    private int previousCameraIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentCameraIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentCameraIndex > cameras.Length - 1)
        {
            currentCameraIndex = previousCameraIndex;
        }

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
            previousCameraIndex = currentCameraIndex;
            currentCameraIndex++;
            if(currentCameraIndex >= cameras.Length)
            {
                currentCameraIndex = 0;
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            previousCameraIndex = currentCameraIndex;
            currentCameraIndex = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            previousCameraIndex = currentCameraIndex;
            currentCameraIndex = 1;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            previousCameraIndex = currentCameraIndex;
            currentCameraIndex = 2;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            previousCameraIndex = currentCameraIndex;
            currentCameraIndex = 3;
        }
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            previousCameraIndex = currentCameraIndex;
            currentCameraIndex = 4;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha6))
        {
            previousCameraIndex = currentCameraIndex;
            currentCameraIndex = 5;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha7))
        {
            previousCameraIndex = currentCameraIndex;
            currentCameraIndex = 6;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha8))
        {
            previousCameraIndex = currentCameraIndex;
            currentCameraIndex = 7;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            previousCameraIndex = currentCameraIndex;
            currentCameraIndex = 8;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            previousCameraIndex = currentCameraIndex;
            currentCameraIndex = 8;
        }
    }
}
