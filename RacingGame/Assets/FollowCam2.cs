using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class FollowCam2 : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothing = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * smoothing);
        transform.rotation = target.rotation;
    }
}
