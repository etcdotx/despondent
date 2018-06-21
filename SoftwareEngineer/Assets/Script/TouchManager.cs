using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    private float drag_distance;
    private Vector2 fp;
    private Vector2 lp;
    public Vector2 jump;
    public float movespeed;
    public float jumpforce;
    private float stopspeed = 0;
    public bool ground;
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    public float maxwidht;
    private Animator anim;
    private bool walking;
    private bool walkingl;
    public GameManager game;
    public AudioSource walk;
    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        game = FindObjectOfType<GameManager>();
        drag_distance = Screen.width * 10 / 100;
    }

    // Update is called once per frame
    void Update()
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
                if (Mathf.Abs(lp.x - fp.x) > drag_distance || Mathf.Abs(lp.y - fp.y) > drag_distance)
                {

                    //drag
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {
                        //swip horizontal
                        if (lp.x > fp.x)
                        {
                            walking = true;
                            walkingl = false;
                            Debug.Log("Right");
                        }
                        else
                        {
                            walking = false;
                            walkingl = true;
                            Debug.Log("Left");
                        }
                    }
                    else if (lp.y > fp.y)
                    {
                        if (ground)
                        {
                            rb.velocity = new Vector3(0f, jumpforce, 0f);
                            Debug.Log("Vertical");
                        }
                    }
                }
                else
                {
                    //tap
                    Debug.Log("Tap");

                    stop();
                }

            }


        }
        if (walking || walkingl)
        {
            if (walking && !walkingl)
            {
                transform.Translate(movespeed * Time.deltaTime, 0, 0);
                sp.flipX = true;
                anim.SetBool("Walking", true);

            }
            else if (walkingl && !walking)
            {
                anim.SetBool("Walking", true);
                transform.Translate(-movespeed * Time.deltaTime, 0, 0);
                sp.flipX = false;

            }

            if (ground && walk.isPlaying == false)
            {
                walk.Play();
                Debug.Log("a");
            }
            else if(!ground && walk.isPlaying == true){
                walk.Stop();
            }
    
        }
    }


    public void stop()
    {
        walking = false;
        walkingl = false;
        anim.SetBool("Walking", false);
        if(walk.isPlaying == true) walk.Stop();
        transform.Translate(stopspeed, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "Mplat")
        {
            ground = true;
        }
        if (collision.gameObject.tag == "boundary")
        {
            Debug.Log("Hit");
            stop();
        }
        if (collision.gameObject.tag == "Mplat") {
          transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "Mplat")
        {
            ground = false;
        }
        if (collision.gameObject.tag == "Mplat")
        {
            transform.parent = null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "checkpoint")
        {

            game.Win();
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "killzone") {
            game.death();
            Destroy(this.gameObject);
        }
    }
}
