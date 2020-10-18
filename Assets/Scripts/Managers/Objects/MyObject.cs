using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{ // None ?
    consumable,
    equipment,
    quest,
    other
}

public abstract class MyObject : MonoBehaviour
{
    public string name;
    public ObjectType type;
    public string description;
    public Sprite sprite;


    GameObject player;
    Commands commands_config;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        commands_config = Utils.GetCommandConfig();
        if (player is null)
            Debug.Log("Player not found");
        if (commands_config is null)
            Debug.Log("Command config not found");
    }

    public void Update()
    {
        // si Player proche de l'objet au sol => add hint pour prendre l'objet
        // si objet pris => ajoute à l'inventaire

        // if player is near the object and press the proper button
        if (Input.GetKeyDown(commands_config.actions["take object"])
            && Utils.ComputeDistance(transform, player.transform) < 3)
        {
            // take the object and put it in inventory
            player.GetComponentInChildren<Inventory>().AddToInventory(this);
            // remove from scene
            Destroy(this.gameObject);
        }
    }
}