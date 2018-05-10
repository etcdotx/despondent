using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoueTrigger : MonoBehaviour {

    public Dialogoue dialogoue;

    private void Start()
    {
        TriggerDialoue();
    }


    public void TriggerDialoue() {
    
        FindObjectOfType<DialogoueManager>().StartDialogoue();
    }
}
