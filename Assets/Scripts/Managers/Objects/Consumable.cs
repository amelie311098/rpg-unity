using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BonusType
{
    //life,
    //xp,
    //mana,
    money
}

public class Consumable : MyObject
{
    // given bonus
    public BonusType bonus_type;
    public uint bonus_value;

    public override void Start()
    {
        type = ObjectType.consumable;
        base.Start();
    }

    // boit ou mange l'objet
    public override void Use()
    {
        Debug.Log("Consumable use");
        switch (bonus_type)
        {
            //case BonusType.life:
            //    GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Inventory>();
            case BonusType.money:
                Money money_manager = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Money>();
                money_manager.TakeMoney(bonus_value);
                break;
            default:
                break;
        }
    }
}
