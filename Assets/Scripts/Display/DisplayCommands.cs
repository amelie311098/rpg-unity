using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCommands : MonoBehaviour
{
    Commands commands_config;
    public Text displacement_commands;
    public Text rotation_commands;
    public Text action_commands;

    void Awake()
    {
        commands_config = Utils.GetCommandConfig();
    }

    public void Display()
    {
        string d_cmd = commands_config.UpArrow.ToString()
            + "\n" + commands_config.LeftArrow.ToString()
            + "   " + commands_config.DownArrow.ToString()
            + "   " + commands_config.RightArrow.ToString();
        displacement_commands.text = d_cmd;

        string r_cmd = commands_config.RotateLeft.ToString()
            + "     " + commands_config.RotateRight.ToString();
        rotation_commands.text = r_cmd;

        string actions = "";
        foreach (string key in commands_config.actions.Keys)
        {
            actions += $"{commands_config.actions[key]}: {key}\n";
        }
        action_commands.text = actions;
    }
}