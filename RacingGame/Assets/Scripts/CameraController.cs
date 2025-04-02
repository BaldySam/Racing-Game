using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera")]
    private Transform cam;

    [Header("Mouse")]
    private float mouseX;
    private float mouseY;

    [Header("First Person Camera")]

    [Header("Camera")]
    [SerializeField] private Transform firstPersonTransform;
    [SerializeField] private Vector2 xClamp;
    [SerializeField] private Vector2 yClamp;

    [Header("Camera Sensitivity")]
    [SerializeField] private float firstPersonSensitivity;

    [Header("Follow Camera")]

    [Header("Offsets")]
    [SerializeField] private Vector3 posOffset;
    [SerializeField] private Vector2 rotOffset;
    
    [Header("Transforms")]
    [SerializeField] private Transform followTransform;
    [SerializeField] private Transform car;

    [Header("Adjustments")]
    [SerializeField] private float followSensitivity;
    [SerializeField] private Vector2 zoomRange;
    [SerializeField] private float smoothing = 5.0f;

    public bool firstPerson = true;
    public bool followCam;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam = transform;

        if(firstPerson)
        {
            cam.position = firstPersonTransform.position;
            cam.rotation = firstPersonTransform.rotation;
        }
        else if(followCam)
        {
            cam.position = followTransform.position;
            cam.rotation = followTransform.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            firstPerson = !firstPerson;
            followCam = !followCam;

            if(firstPerson)
            {
                cam.position = firstPersonTransform.position;
                cam.rotation = firstPersonTransform.rotation;
            }
            else if(followCam)
            {
                cam.position = followTransform.position;
                cam.rotation = followTransform.rotation;
            }
        }

        if(firstPerson)
        {
            FirstPersonCam();
        }
        else if(followCam)
        {
            FollowCam();
        }
    }

    void FirstPersonCam()
    {
        // Sets the cam into the first person transform
        cam.parent = firstPersonTransform;

        // Gets the mouse inputs
        mouseX += Input.GetAxis("Mouse X") * firstPersonSensitivity * Time.deltaTime;
        mouseY -= Input.GetAxis("Mouse Y") * firstPersonSensitivity * Time.deltaTime;

        // Clamps the mouse inputs
        mouseY = Mathf.Clamp(mouseY, yClamp.x, yClamp.y);
        mouseX = Mathf.Clamp(mouseX, xClamp.x, xClamp.y);

        // Rotates the camera depending on the mouse inputs
        cam.localRotation = Quaternion.Euler(mouseY, mouseX, 0);
    }

    void FollowCam()
    {
        // Makes sure the cam does not have a parent
        cam.parent = null;

        // Makes the camera look at the lookAtTarget (with smoothing)
        cam.position = Vector3.Lerp(cam.position, followTransform.GetChild(0).position, Time.deltaTime * smoothing);
        cam.LookAt(followTransform);

        // Adds an offset from the centre rotation point
        followTransform.GetChild(0).localPosition = posOffset;

        if(Input.GetMouseButton(1))
        {
            // Gets the mouse inputs
            mouseX += Input.GetAxis("Mouse X") * Time.deltaTime * followSensitivity;
            mouseY -= Input.GetAxis("Mouse Y") * Time.deltaTime * followSensitivity;
        }
        else
        {
            // Sets the mouse inputs to the offset (ideally towards the target)
            mouseX = rotOffset.x;
            mouseY = rotOffset.y;
        }

        // Zooms in or out when scrolling
        followTransform.rotation = Quaternion.Euler(mouseY + car.eulerAngles.x, mouseX + car.eulerAngles.y, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Calculate the direction from the camera to the collision point
        Vector3 direction = collision.contacts[0].point - cam.position;
    
        // Calculate the distance to move the camera back
        float distance = direction.magnitude;
    
        // Move the camera back along the direction vector
        cam.position -= direction.normalized * distance;
    }
}
