using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static GameObject DuplicateObject(GameObject obj)
    {
        GameObject duplicate = Instantiate<GameObject>(obj);
        duplicate.transform.SetParent(obj.transform.parent);
        duplicate.transform.position = obj.transform.position;
        return duplicate;
    }
}
