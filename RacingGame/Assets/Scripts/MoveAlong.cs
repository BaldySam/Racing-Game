using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlong : MonoBehaviour
{
    [SerializeField] private float amountOfMoves;
    int targetMove = -1;
    public int selectedMove;
    int targetMovement = -32;
    // Start is called before the first frame update
    void Start()
    {
        ToTarget();
    }

    // Update is called once per frame
    void Update()
    {
        targetMove = PlayerStats.Car;
        selectedMove = targetMovement / 32;
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetMovement, Time.deltaTime), transform.position.y, transform.position.z);
    }

    public void OnNext()
    {
        if (targetMovement < amountOfMoves * 32)
        {
            targetMovement = targetMovement + 32;
        }
    }
    public void OnPrevious()
    {
        if (targetMovement > 0)
        {
            targetMovement = targetMovement - 32;
        }
    }

    public void ToTarget()
    {
        targetMovement = targetMove * 32;
    }
}
