using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<MyObject> inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new List<MyObject>();
        StartCoroutine(Log());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Log()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Debug.Log(inventory.Count);
        }
    }

    public void AddToInventory(MyObject obj)
    {
        inventory.Add(obj);
    }
}
