using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherObject : MyObject
{
    public override void Start()
    {
        type = ObjectType.other;
        base.Start();
    }
}
