using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class DialogManager : MonoBehaviour
{
    Queue<string> sentences;

    public TMP_Text nameText;
    public TMP_Text dialogText;

    [SerializeField] GameObject dialogCanvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog)
    {
        nameText.text = dialog.name;

        sentences.Clear();

        foreach(string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
    }

    void EndDialog()
    {
        dialogCanvas.SetActive(false);
    }
}
