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

    public int ACTIONS_INDEX = 6;

    public Dictionary<string, KeyCode> actions;

    public void Start()
    {
        // add actions commands keys
        actions = new Dictionary<string, KeyCode>();
        actions.Add("pause menu", KeyCode.Escape);
        actions.Add("talk", KeyCode.F);
        actions.Add("take object", KeyCode.G);
        actions.Add("choose up response", KeyCode.UpArrow);
        actions.Add("choose down response", KeyCode.DownArrow);

        // setup hint display
        hints.text = $"Press {actions["pause menu"]} for pause menu";
    }
}
