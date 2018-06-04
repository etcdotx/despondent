using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    private TouchManager touch;
    public GameObject portald;
    public bool insideportal;
    private Teleport target;
    public Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
        insideportal = false;
        touch = FindObjectOfType<TouchManager>();
        target = portald.GetComponent<Teleport>();
    }

    private void Update()
    {
        if (touch != null)
        {
            if (Vector2.Distance(this.transform.position, touch.gameObject.transform.position) < 3)
            {
                anim.SetBool("PlayerIsNear", true);
            }
            else
            {
                anim.SetBool("PlayerIsNear", false);
            }
        }
    }

    IEnumerator teleports(GameObject player) {
        yield return new WaitForSeconds(0.2f);
        player.transform.position = new Vector2(portald.transform.position.x, portald.transform.position.y);
        touch.stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!insideportal) {
            if (collision.gameObject.tag == "Player") {
                StartCoroutine(teleports(collision.gameObject));
                target.insideportal = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       insideportal = false;
    }
}
