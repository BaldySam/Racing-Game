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
        if (currentCameraIndex >= cameras.Length)
        {
            currentCameraIndex = previousCameraIndex;
        }

        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].SetActive(i == currentCameraIndex);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            previousCameraIndex = currentCameraIndex;
            currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;
        }

        for (int i = 0; i < cameras.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                previousCameraIndex = currentCameraIndex;
                currentCameraIndex = i;
            }
        }
    }
}
