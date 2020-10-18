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

    public static float ComputeDistance(Transform t1, Transform t2)
    {
        return Vector3.Distance(t1.position, t2.position);
    }

    public static Commands GetCommandConfig()
    {
        return GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Commands>();
    }
}
