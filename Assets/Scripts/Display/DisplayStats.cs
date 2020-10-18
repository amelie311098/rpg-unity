using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour
{
    public Text money_display;
    public Money money_manager;

    public void DisplayAllStats()
    {
        DisplayMoney();
    }

    void DisplayMoney()
    {
        money_display.text = $"Money: {money_manager.GetMoneyAmount()}$";
    }
}
