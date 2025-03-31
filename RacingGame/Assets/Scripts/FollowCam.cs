using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] private Vector3 posOffset;
    [SerializeField] private Vector2 rotOffset;
    [SerializeField] private float smoothing;
    [SerializeField] private Transform car;
    [SerializeField] private Vector2 zoomRange;
    private float mouseX;
    private float mouseY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).localPosition = posOffset;
        transform.LookAt(transform.parent);
        Look();
        transform.rotation = Quaternion.Euler(mouseY + car.eulerAngles.x, mouseX + car.eulerAngles.y, 0);
        ScrollToZoom();
    }

    void Look()
    {
        if(Input.GetMouseButton(1))
        {
            mouseX += Input.GetAxis("Mouse X") * Time.deltaTime * smoothing;
            mouseY -= Input.GetAxis("Mouse Y") * Time.deltaTime * smoothing;
        }
        else
        {
            mouseX = rotOffset.x;
            mouseY = rotOffset.y;
        }
    }

    void ScrollToZoom()
    {
        posOffset.z = Mathf.Clamp(posOffset.z + Input.GetAxis("Mouse ScrollWheel") * 5, zoomRange.x, zoomRange.y);
    }
}
