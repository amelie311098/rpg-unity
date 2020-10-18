using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    public Commands commands;

    public GameObject player;
    public GameObject text_box;
    public GameObject npc_name;
    public GameObject npc_text;

    public GameObject response_template;

    public string name;
    public List<Dialogue> dialogues;

    private int dialogue_index;
    private List<GameObject> choice_objects;
    private int choice_hover;
    private float default_opacity;

    void Start()
    {
        SetDialogue(false);
        dialogue_index = 0;
        npc_name.GetComponent<Text>().text = name;
        choice_objects = new List<GameObject>();
        default_opacity = response_template.GetComponent<Image>().color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(commands.actions["talk"]))
        {
            Talk();
        }

        if (Input.GetKeyDown(commands.actions["choose up response"]))
        {
            SelectChoice(-1);
        }
        else if (Input.GetKeyDown(commands.actions["choose down response"]))
        {
            SelectChoice(1);
        }
    }

    void Talk()
    {
        // TODO: do something with the selected choice

        if (ComputeDistance() < 3)
        {
            if (dialogues.Count <= dialogue_index)
            {
                // end of dialogue available
                // loop on the last one
                dialogue_index = dialogues.Count - 1;
                dialogues[dialogue_index].ResetDialogue();
            }

            dialogues[dialogue_index].SetNext();
            RemoveOldChoices();

            if (dialogues[dialogue_index].IsEnd()) // end of dialogue
            {
                SetDialogue(false);
                ++dialogue_index;
                return;
            }

            SetDialogue(true);
            SetDialogueLine();
            StartCoroutine(SetChoices());
        }
        else
        {
            // set end of dialogue
            SetDialogue(false);
            dialogues[dialogue_index].ResetDialogue();
            RemoveOldChoices();
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
        npc_text.GetComponent<Text>().text = dialogues[dialogue_index].GetSentence();
    }

    IEnumerator SetChoices()
    {
        List<string> choices = dialogues[dialogue_index].GetChoices();
        if (choices.Count != 0)
        {
            yield return new WaitForSeconds(0.8f);

            int vspace = 0;
            foreach (string choice in choices)
            {
                GameObject choice_object = Utils.DuplicateObject(response_template);
                choice_object.GetComponentInChildren<Text>().text = choice;
                choice_object.GetComponent<RectTransform>().anchoredPosition -= new Vector2(0, vspace);
                choice_object.SetActive(true);
                choice_objects.Add(choice_object);

                vspace += 50;
            }

            // set the first choice as selected
            choice_hover = 0;
            SetHover(true);
        }
    }

    void RemoveOldChoices()
    {
        foreach (GameObject obj in choice_objects)
        {
            Destroy(obj);
        }
        choice_objects.Clear();
    }

    void SelectChoice(int delta)
    {
        if (choice_hover + delta < 0 || choice_hover + delta >= choice_objects.Count) // out of bounds
            return;

        SetHover(false);
        choice_hover += delta;
        SetHover(true);
    }

    void SetHover(bool selected)
    {
        Image img = choice_objects[choice_hover].GetComponent<Image>();
        Color c = img.color;
        c.a = selected ? 1 : default_opacity;
        img.color = c;
    }
}
