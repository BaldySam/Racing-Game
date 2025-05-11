using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCam : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float height = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y + height, target.position.z);
        transform.rotation = Quaternion.Euler(90f, target.eulerAngles.y, 0f);
    }
}
