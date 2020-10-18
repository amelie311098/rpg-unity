using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MyObject
{
    // given bonus

    void Start()
    {
        type = ObjectType.consumable;
        base.Start();
    }

    // boit ou mange l'objet
}
