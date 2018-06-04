using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private GameManager game;

    private void Start()
    {
        game = FindObjectOfType<GameManager>();
    }
}
