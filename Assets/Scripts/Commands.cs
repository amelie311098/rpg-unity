using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commands : MonoBehaviour
{
    public KeyCode UpArrow = KeyCode.I;
    public KeyCode LeftArrow = KeyCode.J;
    public KeyCode RightArrow = KeyCode.L;
    public KeyCode DownArrow = KeyCode.K;

    public KeyCode RotateLeft = KeyCode.A;
    public KeyCode RotateRight = KeyCode.D;

    public Dictionary<string, KeyCode> actions;

    public void Start()
    {
        actions = new Dictionary<string, KeyCode>();
        actions.Add("talk", KeyCode.F);
        actions.Add("pause menu", KeyCode.Escape);
    }
}
