using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyTextUpdater : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money: $" + PlayerStats.Money.ToString("N0");
    }
}
