using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject hint_object;

    public void SetHintActive()
    {
        hint_object.SetActive(!hint_object.activeSelf);
    }
}
