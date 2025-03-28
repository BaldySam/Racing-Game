using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] private Vector3 normalOffset;
    private Vector3 offset;
    [SerializeField] private float zoomSpeed = 2.0f;
    [SerializeField] private Vector2 zoomRange = new Vector2(1.0f, 10.0f);
    private float scroll;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.parent);
        Look();
        ZoomInOnScroll();
        transform.localPosition = offset;
    }

    void Look()
    {
        if(Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            offset = Quaternion.AngleAxis(mouseX, Vector3.up) * offset;
            offset = Quaternion.AngleAxis(mouseY, Vector3.right) * offset;
        }
        else if(Input.GetMouseButtonUp(1))
        {
            offset = normalOffset;
        }

    }

    void ZoomInOnScroll()
    {
        // Zoom in on scroll
        scroll += Input.GetAxis("Mouse ScrollWheel");
        Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
        scroll = Mathf.Clamp(scroll, zoomRange.x, zoomRange.y);
        float zoomAmount = scroll * zoomSpeed;
        float newOffsetMagnitude = offset.magnitude - zoomAmount;
        offset = offset.normalized * newOffsetMagnitude;
    }
}
