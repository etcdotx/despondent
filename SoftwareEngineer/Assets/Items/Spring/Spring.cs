using UnityEngine;
using System;
using System.Collections;

public class Spring : MonoBehaviour {

	public LayerMask playerLayerMask;
	public Transform rayCastStart;
	public Transform rayCastEnd;
	public float springForce ;

	private Animator animator;
	private float rayCastDistance;
	private GameObject player;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();

		if (rayCastStart != null && rayCastEnd != null) {
			rayCastDistance = rayCastEnd.position.x - rayCastStart.position.x;
		}
	}
	
	// Update is called once per frame
	void Update () {
		/*if (hit.collider != null && !animator.GetBool("Pressing"))
		{
			animator.SetBool("Pressing", true);
			animator.SetBool("Releasing", false);
			player = hit.collider.gameObject;
		}
		else if (hit.collider != null && animator.GetBool("Pressing") && JumpInputActive) {
			player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, springForce));
		}
		else if (hit.collider == null) {
			animator.SetBool("Pressing", false);
			animator.SetBool("Releasing", true);
		}*/
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, springForce),ForceMode2D.Impulse);
        }
    }
}