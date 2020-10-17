using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Commands : MonoBehaviour
{
    public Text hints;


    public KeyCode UpArrow = KeyCode.I;
    public KeyCode LeftArrow = KeyCode.J;
    public KeyCode RightArrow = KeyCode.L;
    public KeyCode DownArrow = KeyCode.K;

    public KeyCode RotateLeft = KeyCode.A;
    public KeyCode RotateRight = KeyCode.D;

    public Dictionary<string, KeyCode> actions;

    public void Start()
    {
        // add actions commands keys
        actions = new Dictionary<string, KeyCode>();
        actions.Add("talk", KeyCode.F);
        actions.Add("pause menu", KeyCode.Escape);

        // setup hint display
        hints.text = $"Press {actions["pause menu"]} for pause menu";
    }
}
