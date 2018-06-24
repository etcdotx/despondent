using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoueManager : MonoBehaviour {
    private Queue<Sprite> sentences;
    private Queue<string> sentencess;
    public Image dialogouetext;
    public Text dialoguetexts;
    public Animator animator;
    public GameObject ball;
    public List<Sprite> listi;
    public Dialogoue dialogoue;
    private Vector2 fp;
    private Vector2 lp;
    private float drag_distance;
    public int level;


    // Use this for initialization
    void Awake()
    {
        sentences = new Queue<Sprite>();
        sentencess = new Queue<string>();
        drag_distance = Screen.width * 10 / 100;
    }

    private void  Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                lp = touch.position;
                if (Mathf.Abs(lp.x - fp.x) > drag_distance || Mathf.Abs(lp.y - fp.y) > drag_distance) {

                }
                else {
                    DisplayNextSentence();
                }
            }
        }
    }

    public void StartDialogoue() {
      
        sentences.Clear();
        sentencess.Clear();

        foreach(Sprite sentence in listi) {
            sentences.Enqueue(sentence);
        }

        sentencess.Clear();
        foreach (string dialog in dialogoue.sentences) {
            sentencess.Enqueue(dialog);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if(sentences.Count == 0)
        {
            Application.LoadLevel(level);
        }

        if (sentences.Count == 1 && animator != null)
        {
            ball.SetActive(true);
            animator.SetBool("Float", true);
        }

        Sprite sentence = sentences.Dequeue();
        string dialog = sentencess.Dequeue();
        dialogouetext.sprite = sentence;
        dialoguetexts.text = dialog;
    }






}
