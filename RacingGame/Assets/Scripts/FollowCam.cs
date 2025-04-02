using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [Header("Transform to Follow Settings")]
    [SerializeField] private Vector3 posOffset;
    [SerializeField] private Vector2 rotOffset;
    [SerializeField] private float sensitivity = 5.0f;
    [SerializeField] private Vector2 zoomRange;
    [SerializeField] private Transform car;
    private float mouseX;
    private float mouseY;

    [Header("Camera")]
    [SerializeField] private Transform cam;
    [SerializeField] private Transform lookAtTarget;
    [SerializeField] private float smoothing = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TransformToFollowThings();
        CamThings();
    }

    void CamThings()
    {
        cam.position = Vector3.Lerp(cam.position, transform.position, Time.deltaTime * smoothing);
        cam.LookAt(lookAtTarget);
    }

    void TransformToFollowThings()
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
            mouseX += Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
            mouseY -= Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;
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
