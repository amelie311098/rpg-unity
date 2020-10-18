using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [System.Serializable]
    struct Sentence
    {
        public string sentence;
        public List<string> choices;
    }

    [SerializeField] List<Sentence> sentences;

    private int sentence_id = -1;

    public void ResetDialogue()
    {
        sentence_id = -1;
    }

    public string GetSentence()
    {
        return sentences[sentence_id].sentence;
    }

    public List<string> GetChoices()
    {
        return sentences[sentence_id].choices;
    }

    public void SetNext()
    {
        ++sentence_id;
    }

    public bool IsEnd()
    {
        return sentence_id >= sentences.Count;
    }
}
