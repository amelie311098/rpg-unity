using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCommands : MonoBehaviour
{
    public Commands commands_config;

    public GameObject displacement_template;
    public GameObject action_template;

    private List<GameObject> setup_config = null;

    private List<KeyCode> avalaible_keys = null;

    public void Enable()
    {
        if (avalaible_keys is null)
        {
            SetupAvalaibleKeys();
        }
        else
        {
            foreach (GameObject e in setup_config)
            {
                Destroy(e);
            }

            displacement_template.SetActive(true);
            action_template.SetActive(true);
        }

        // set tous les text + dropdown objects
        setup_config = new List<GameObject>();

        setup_config.Add(NewOption(displacement_template, "Up Arrow", commands_config.UpArrow));
        setup_config.Add(NewOption(displacement_template, "Down Arrow", commands_config.DownArrow));
        setup_config.Add(NewOption(displacement_template, "Left Arrow", commands_config.LeftArrow));
        setup_config.Add(NewOption(displacement_template, "Right Arrow", commands_config.RightArrow));
        setup_config.Add(NewOption(displacement_template, "Left Rotation", commands_config.RotateLeft));
        setup_config.Add(NewOption(displacement_template, "Right Rotation", commands_config.RotateRight));

        foreach (string key in commands_config.actions.Keys)
        {
            setup_config.Add(NewOption(action_template, key, commands_config.actions[key]));
        }

        // set space between commands
        for (int i = 0; i < commands_config.ACTIONS_INDEX; ++i)
        {
            setup_config[i].GetComponent<RectTransform>().anchoredPosition -= new Vector2(0, i * 50); // TODO: in function of the height of the prefab
        }
        for (int i = commands_config.ACTIONS_INDEX; i < setup_config.Count; ++i)
        {
            setup_config[i].GetComponent<RectTransform>().anchoredPosition -= new Vector2(0, (i - 6) * 50); // TODO: in function of the height of the prefab
        }

        // remove prefabs
        displacement_template.SetActive(false);
        action_template.SetActive(false);
    }

    void SetupAvalaibleKeys()
    {
        avalaible_keys = new List<KeyCode>();

        avalaible_keys.Add(KeyCode.Backspace); // 8
        avalaible_keys.Add(KeyCode.Tab); // 9
        avalaible_keys.Add(KeyCode.Return); // 13
        avalaible_keys.Add(KeyCode.Escape); // 27
        avalaible_keys.Add(KeyCode.Space); // 32

        for (KeyCode k = KeyCode.A; k < KeyCode.Z; ++k)
        {
            avalaible_keys.Add(k);
        }
        for (KeyCode k = KeyCode.UpArrow; k < KeyCode.RightArrow; ++k)
        {
            avalaible_keys.Add(k);
        }
        for (KeyCode k = KeyCode.Keypad0; k < KeyCode.KeypadEquals; ++k)
        {
            avalaible_keys.Add(k);
        }
        for (KeyCode k = KeyCode.RightShift; k < KeyCode.LeftAlt; ++k)
        {
            avalaible_keys.Add(k);
        }

        avalaible_keys.Add(KeyCode.Delete); // 127
        avalaible_keys.Add(KeyCode.End); // 279
        avalaible_keys.Add(KeyCode.Home); // 278
        avalaible_keys.Add(KeyCode.Insert); // 277
        avalaible_keys.Add(KeyCode.LeftWindows); // 311
        avalaible_keys.Add(KeyCode.CapsLock); // 301

        for (KeyCode k = KeyCode.F1; k < KeyCode.F15; ++k)
        {
            avalaible_keys.Add(k);
        }
    }

    GameObject NewOption(GameObject command_object, string command_name, KeyCode used)
    {
        GameObject duplicate = Utils.DuplicateObject(command_object);

        Text text = duplicate.GetComponent<Text>();
        text.text = command_name;

        Dropdown list = duplicate.GetComponentInChildren<Dropdown>();
        list.ClearOptions();

        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();

        foreach (KeyCode key in avalaible_keys)
        {
            if (key == used) // set the used key in first position of the list
                options.Insert(0, new Dropdown.OptionData(key.ToString()));
            else
                options.Add(new Dropdown.OptionData(key.ToString()));
        }

        list.AddOptions(options);

        return duplicate;
    }

    KeyCode GetKeyFromOption(GameObject option)
    {
        Dropdown d = option.GetComponentInChildren<Dropdown>();
        return (KeyCode)System.Enum.Parse(typeof(KeyCode), d.options[d.value].text);
    }

    public void ValidateConfig()
    {
        commands_config.UpArrow = GetKeyFromOption(setup_config[0]);
        commands_config.DownArrow = GetKeyFromOption(setup_config[1]);
        commands_config.LeftArrow = GetKeyFromOption(setup_config[2]);
        commands_config.RightArrow = GetKeyFromOption(setup_config[3]);
        commands_config.RotateLeft = GetKeyFromOption(setup_config[4]);
        commands_config.RotateRight = GetKeyFromOption(setup_config[5]);

        for (int option_index = commands_config.ACTIONS_INDEX; option_index < setup_config.Count; ++option_index)
        {
            string key = setup_config[option_index].GetComponent<Text>().text;
            commands_config.actions[key] = GetKeyFromOption(setup_config[option_index]);
        }

        DestroyTmpObjects();
    }

    void DestroyTmpObjects()
    {
        foreach (GameObject e in setup_config)
        {
            Destroy(e);
        }
        setup_config.Clear();
    }
}