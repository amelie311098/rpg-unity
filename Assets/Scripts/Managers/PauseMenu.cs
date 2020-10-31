using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    Commands commands_config;

    public GameObject pause_panel;
    public GameObject menu_buttons;
    public GameObject commands;
    public GameObject settings;
    public GameObject change_commands;
    public GameObject inventory;

    public DisplayStats display_stats;

    enum State
    {
        game,
        pause,
        commands,
        settings,
        change_commands,
        inventory,
    }

    private State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.game;
        commands_config = Utils.GetCommandConfig();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(commands_config.actions["pause menu"]))
        {
            switch(state)
            {
                case State.game:
                case State.commands:
                case State.settings:
                    SetPause();
                    break;
                case State.pause:
                    pause_panel.SetActive(false);
                    state = State.game;
                    break;
                case State.change_commands:
                    settings.SetActive(true);
                    change_commands.SetActive(false);
                    state = State.settings;
                    break;
                case State.inventory:
                    inventory.GetComponent<DisplayInventory>().DestroyTmpObjects();
                    SetPause();
                    break;
                default:
                    break;
            }
        }
    }

    public void SetPause()
    {
        pause_panel.SetActive(true);
        menu_buttons.SetActive(true);
        commands.SetActive(false);
        settings.SetActive(false);
        inventory.SetActive(false);
        state = State.pause;

        display_stats.DisplayAllStats();
    }

    public void DisplayCommands()
    {
        menu_buttons.SetActive(false);
        commands.SetActive(true);
        state = State.commands;
    }

    public void GoToSettings()
    {
        menu_buttons.SetActive(false);
        settings.SetActive(true);
        state = State.commands;
    }

    public void GoChangeCommands()
    {
        settings.SetActive(false);
        change_commands.SetActive(true);
        state = State.change_commands;
    }

    public void FromChangeCommands()
    {
        settings.SetActive(true);
        change_commands.SetActive(false);
        state = State.settings;
    }

    public void GoToInventory()
    {
        menu_buttons.SetActive(false);
        inventory.SetActive(true);
        state = State.inventory;
    }
}
