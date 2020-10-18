using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MyObject
{
    // stats

    public override void Start()
    {
        type = ObjectType.equipment;
        base.Start();
    }
}
