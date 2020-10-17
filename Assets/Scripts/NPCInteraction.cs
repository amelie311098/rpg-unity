using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    public GameObject player;
    public GameObject text_box;
    public GameObject npc_name;
    public GameObject npc_text;

    public string name;
    public List<string> dialogues;

    private int line_index;

    void Start()
    {
        SetDialogue(false);
        line_index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (ComputeDistance() < 3)
            {
                if (line_index == 0)
                {
                    npc_name.GetComponent<Text>().text = name;
                    SetDialogueLine();
                    SetDialogue(true);
                }
                else if (line_index < dialogues.Count)
                {
                    SetDialogueLine();
                }
                else // end of dialogue
                {
                    SetDialogue(false);
                    line_index = 0;
                }
            }
            else
            {
                // set end of dialogue
                SetDialogue(false);
                line_index = 0;
            }
        }
    }

    float ComputeDistance()
    {
        return Vector3.Distance(player.GetComponent<Transform>().position, transform.position);
    }

    void SetDialogue(bool show)
    {
        text_box.SetActive(show);
        npc_name.SetActive(show);
        npc_text.SetActive(show);
    }

    void SetDialogueLine()
    {
        npc_text.GetComponent<Text>().text = dialogues[line_index++];
    }
}
