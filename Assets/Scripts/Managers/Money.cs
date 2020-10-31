using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] uint money_possess;

    public uint GetMoneyAmount()
    {
        return money_possess;
    }

    public bool CanAfford(uint money)
    {
        return money_possess >= money;
    }

    public bool GiveMoney(uint money)
    {
        if (!CanAfford(money))
            return false;

        money_possess -= money;
        return true;
    }

    public void TakeMoney(uint money)
    {
        uint tmp = money_possess + money;
        if (tmp < money_possess)
        {
            money_possess = uint.MaxValue;
        }
        else
        {
            money_possess = tmp;
        }
    }
}
