using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoueManager : MonoBehaviour {
    private Queue<Sprite> sentences;
    public Image dialogouetext;
    public Animator animator;
    public List<Sprite> listi;
    // Use this for initialization
    void Awake()
    {
        sentences = new Queue<Sprite>();
    }

    private void Update()
    {
        if (Input.touchCount == 1) {
            DisplayNextSentence();
        }
    }

    public void StartDialogoue() {
      
        sentences.Clear();
        foreach(Sprite sentence in listi) {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if(sentences.Count == 0)
        {
            Application.LoadLevel(2);
        }

        Sprite sentence = sentences.Dequeue();
        dialogouetext.sprite = sentence;
    }






}
