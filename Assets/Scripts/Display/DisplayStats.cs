using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour
{
    public Text money_display;
    Money money_manager;

    void Awake()
    {
        money_manager = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Money>();
    }

    public void DisplayAllStats()
    {
        DisplayMoney();
    }

    void DisplayMoney()
    {
        money_display.text = $"Money: {money_manager.GetMoneyAmount()}$";
    }
}
