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
        //StartCoroutine(Log());
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

    public List<MyObject> GetSubListObjects(uint max_size)
    {
        return inventory.GetRange(0, (int)Mathf.Min(inventory.Count, max_size));
    }

    public List<MyObject> SearchByName(string name)
    {
        List<MyObject> objects = new List<MyObject>();
        foreach (MyObject obj in inventory)
        {
            if (obj.objname == name)
                objects.Add(obj);
        }
        return objects;
    }

    public bool UseObject(MyObject obj)
    {
        obj.Use();
        Debug.Log(obj is Consumable);
        if (obj is Consumable)
        {
            inventory.Remove(obj);
            return true;
        }
        return false;
    }

    public void RemoveObject(MyObject obj)
    {
        inventory.Remove(obj);
    }
}
