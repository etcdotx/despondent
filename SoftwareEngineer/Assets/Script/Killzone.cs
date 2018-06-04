using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour {
    GameManager game;
    private void Start()
    {
        game = FindObjectOfType<GameManager>();
    }
    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            game.death();
            Destroy(collision.gameObject);
        }

    }
}
