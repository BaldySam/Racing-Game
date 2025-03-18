using UnityEngine;
 
public class FreeLookCamera : MonoBehaviour
{
    [Header("Mouse")]
    private float mouseX;
    private float mouseY;
 
    [Header("Camera Sensitivity")]
    [SerializeField] private float lookSensitivity = 100f;
    [SerializeField] private float smoothness = 10f;
 
    [Header("Movement")]
    
    [Header("Bindings")]
    [SerializeField] private KeyCode sprintKey = KeyCode.LeftControl;
    [SerializeField] private KeyCode slowKey = KeyCode.LeftAlt;
    [SerializeField] private KeyCode upKey = KeyCode.Space;
    [SerializeField] private KeyCode downKey = KeyCode.LeftShift;

    [Header("Values")]
    [SerializeField] private float movementSensitivity = 15f;
    [SerializeField] private float sprintMultiplier = 2f;
    [SerializeField] private float slowMultiplier = 0.5f;
    [SerializeField] private float upDownSensitivity = 10f;
 
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
 
    // Update is called once per frame
    void Update()
    {
        RotateCam();
        MoveCam();
    }
 
    void MoveCam()
    {
        float movementMultiplier = Input.GetKey(sprintKey) ? sprintMultiplier : Input.GetKey(slowKey) ? slowMultiplier : 1;
        float moveUp = Input.GetKey(downKey) ? -1 : Input.GetKey(upKey) ? 1 : 0;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
 
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical) * movementSensitivity * movementMultiplier;
        transform.Translate(movement * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y + (moveUp * upDownSensitivity * Time.deltaTime), transform.position.z);
    }
 
    void RotateCam()
    {
        mouseX += Input.GetAxis("Mouse X") * lookSensitivity * Time.deltaTime;
        mouseY -= Input.GetAxis("Mouse Y") * lookSensitivity * Time.deltaTime;
        Quaternion targetRotation = Quaternion.Euler(mouseY, mouseX, 0);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * smoothness);
    }
}