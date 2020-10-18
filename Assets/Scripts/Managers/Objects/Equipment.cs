using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MyObject
{
    // stats

    void Start()
    {
        type = ObjectType.equipment;
        base.Start();
    }
}
