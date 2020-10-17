using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Commands commands_config;

    public GameObject pause_panel;
    public GameObject menu_buttons;
    public GameObject commands;

    enum State
    {
        game,
        pause,
        commands,
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
                    menu_buttons.SetActive(true);
                    commands.SetActive(false);
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
}
