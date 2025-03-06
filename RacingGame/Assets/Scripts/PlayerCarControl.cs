using UnityEngine;

public class PlayerCarControl : MonoBehaviour
{
    [SerializeField] private Transform steeringWheel;
    CarControl carControl;
    float hInput;
    float vInput;

    // Start is called before the first frame update
    void Start()
    {
        carControl = GetComponent<CarControl>();
    }

    // Update is called once per frame
    void Update()
    {
        WheelRotate();
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        carControl.vInput = vInput;
        carControl.hInput = hInput;
    }

    void WheelRotate()
    {
        steeringWheel.localEulerAngles = new Vector3(steeringWheel.localEulerAngles.x, Quaternion.Slerp(steeringWheel.localRotation, Quaternion.Euler(0, hInput * 90, 0), Time.deltaTime * 5).eulerAngles.y, steeringWheel.localEulerAngles.z);
    }
}
