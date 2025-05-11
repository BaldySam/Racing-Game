using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GarageStatSorter : MonoBehaviour
{
    [SerializeField] private TMP_Text gripText;
    [SerializeField] private TMP_Text accelerationText;
    [SerializeField] private TMP_Text topSpeedText;
    [SerializeField] private TMP_Text brakingText;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text damageText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gripText.text = "Cost: " + (Mathf.RoundToInt(PlayerStats.Grip.x) * 10).ToString("N0") + "\n" + PlayerStats.Grip.x.ToString("N0") + " / " + PlayerStats.Grip.y.ToString("N0");
        accelerationText.text = "Cost: " + (Mathf.RoundToInt(PlayerStats.Acceleration.x) * 10).ToString("N0") + "\n" + PlayerStats.Acceleration.x.ToString("N0") + " / " + PlayerStats.Acceleration.y.ToString("N0");
        topSpeedText.text = "Cost: " + (Mathf.RoundToInt(PlayerStats.TopSpeed.x) * 10).ToString("N0") + "\n" + PlayerStats.TopSpeed.x.ToString("N0") + " / " + PlayerStats.TopSpeed.y.ToString("N0");
        brakingText.text = "Cost: " + (Mathf.RoundToInt(PlayerStats.Braking.x) * 10).ToString("N0") + "\n" + PlayerStats.Braking.x.ToString("N0") + " / " + PlayerStats.Braking.y.ToString("N0");
        healthText.text = "Cost: " + (Mathf.RoundToInt(PlayerStats.Health.x) * 10).ToString("N0") + "\n" + PlayerStats.Health.x.ToString("N0") + " / " + PlayerStats.Health.y.ToString("N0");
        damageText.text = "Cost: " + (Mathf.RoundToInt(PlayerStats.Damage.x) * 10).ToString("N0") + "\n" + PlayerStats.Damage.x.ToString("N0") + " / " + PlayerStats.Damage.y.ToString("N0");
    }

    public void OnUpgradeGrip()
    {
        if(PlayerStats.Money >= Mathf.RoundToInt(PlayerStats.Grip.x) * 10 && PlayerStats.Grip.x < PlayerStats.Grip.y)
        {
            PlayerStats.Money -= Mathf.RoundToInt(PlayerStats.Grip.x) * 10;
            PlayerStats.Grip.x += 1;
        }
    }
    public void OnUpgradeAcceleration()
    {
        if(PlayerStats.Money >= Mathf.RoundToInt(PlayerStats.Acceleration.x) * 10 && PlayerStats.Acceleration.x < PlayerStats.Acceleration.y)
        {
            PlayerStats.Money -= Mathf.RoundToInt(PlayerStats.Acceleration.x) * 10;
            PlayerStats.Acceleration.x += 1;
        }
    }
    public void OnUpgradeTopSpeed()
    {
        if(PlayerStats.Money >= Mathf.RoundToInt(PlayerStats.TopSpeed.x) * 10 && PlayerStats.TopSpeed.x < PlayerStats.TopSpeed.y)
        {
            PlayerStats.Money -= Mathf.RoundToInt(PlayerStats.TopSpeed.x) * 10;
            PlayerStats.TopSpeed.x += 1;
        }
    }
    public void OnUpgradeBraking()
    {
        if(PlayerStats.Money >= Mathf.RoundToInt(PlayerStats.Braking.x) * 10 && PlayerStats.Braking.x < PlayerStats.Braking.y)
        {
            PlayerStats.Money -= Mathf.RoundToInt(PlayerStats.Braking.x) * 10;
            PlayerStats.Braking.x += 1;
        }
    }
    public void OnUpgradeHealth()
    {
        if(PlayerStats.Money >= Mathf.RoundToInt(PlayerStats.Health.x) * 10 && PlayerStats.Health.x < PlayerStats.Health.y)
        {
            PlayerStats.Money -= Mathf.RoundToInt(PlayerStats.Health.x) * 10;
            PlayerStats.Health.x += 1;
        }
    }
    public void OnUpgradeDamage()
    {
        if(PlayerStats.Money >= Mathf.RoundToInt(PlayerStats.Damage.x) * 10 && PlayerStats.Damage.x < PlayerStats.Damage.y)
        {
            PlayerStats.Money -= Mathf.RoundToInt(PlayerStats.Damage.x) * 10;
            PlayerStats.Damage.x += 1;
        }
    }
}
