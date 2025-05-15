using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] GameObject[] cars;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            cars[i].transform.position = spawnPoints[i].transform.position;
            cars[i].transform.rotation = spawnPoints[i].transform.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
