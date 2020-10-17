using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Commands commands_config;

    public GameObject pause_panel;
    public GameObject menu_buttons;
    public GameObject commands;
    public GameObject settings;

    enum State
    {
        game,
        pause,
        commands,
        settings,
    }

    private State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.game;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(commands_config.actions["pause menu"]))
        {
            switch(state)
            {
                case State.game:
                    pause_panel.SetActive(true);
                    menu_buttons.SetActive(true);
                    state = State.pause;
                    break;
                case State.pause:
                    pause_panel.SetActive(false);
                    state = State.game;
                    break;
                case State.commands:
                case State.settings:
                    menu_buttons.SetActive(true);
                    commands.SetActive(false);
                    settings.SetActive(false);
                    state = State.pause;
                    break;
                default:
                    break;
            }
        }
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
}
