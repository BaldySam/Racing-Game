using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarMarketCarStats : MonoBehaviour
{
    [SerializeField] private MoveAlong moveAlong;
    [SerializeField] private CarValues[] carValues;
    [SerializeField] private TMP_Text statsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveAlong.selectedMove == -1)
        {
            statsText.text = "";
        }
        else
        {
            statsText.text = "Model: " + carValues[moveAlong.selectedMove].carName + "\n" +
                "Braking: " + carValues[moveAlong.selectedMove].braking[0] + "/" + carValues[moveAlong.selectedMove].braking[1] + "\n" +
                "Grip: " + carValues[moveAlong.selectedMove].grip[0] + "/" + carValues[moveAlong.selectedMove].grip[1] + "\n" +
                "Acceleration: " + carValues[moveAlong.selectedMove].acceleration[0] + "/" + carValues[moveAlong.selectedMove].acceleration[1] + "\n" +
                "Top Speed: " + carValues[moveAlong.selectedMove].topSpeed[0] + "/" + carValues[moveAlong.selectedMove].topSpeed[1] + "\n" +
                "Health: " + carValues[moveAlong.selectedMove].health[0] + "/" + carValues[moveAlong.selectedMove].health[1] + "\n" +
                "Damage: " + carValues[moveAlong.selectedMove].damage[0] + "/" + carValues[moveAlong.selectedMove].damage[1] + "\n" +
                "Price: $" + carValues[moveAlong.selectedMove].price;
        }
    }

    public void OnPurchase()
    {
        if (carValues[moveAlong.selectedMove].price <= PlayerStats.Money)
        {
            PlayerStats.Money -= carValues[moveAlong.selectedMove].price;
            PlayerStats.Car = moveAlong.selectedMove;
            PlayerStats.Grip = carValues[moveAlong.selectedMove].grip;
            PlayerStats.Acceleration = carValues[moveAlong.selectedMove].acceleration;
            PlayerStats.TopSpeed = carValues[moveAlong.selectedMove].topSpeed;
            PlayerStats.Braking = carValues[moveAlong.selectedMove].braking;
            PlayerStats.Health = carValues[moveAlong.selectedMove].health;
            PlayerStats.Damage = carValues[moveAlong.selectedMove].damage;
        }
        else
        {
            Debug.Log("Not enough money to purchase this car.");
        }
    }
}

[System.Serializable]
public class CarValues
{
    [SerializeField] public string carName;
    [SerializeField] public Vector2 braking;
    [SerializeField] public Vector2 grip;
    [SerializeField] public Vector2 acceleration;
    [SerializeField] public Vector2 topSpeed;
    [SerializeField] public Vector2 health;
    [SerializeField] public Vector2 damage;
    [SerializeField] public int price;
}

