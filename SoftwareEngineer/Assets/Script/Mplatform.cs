using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mplatform : MonoBehaviour {
    public GameObject platform;
    public float ms;
    public Transform current;
    public Transform[] points;
    public int pointselect;

    // Use this for initialization
    void Start()
    {
        current = points[pointselect];
        platform.transform.position = new Vector2(points[pointselect - 1].position.x, points[pointselect - 1].position.y);
    }

    // Update is called once per frame
    void Update()
    {
        platform.transform.position = Vector2.MoveTowards(platform.transform.position, current.position, ms * Time.deltaTime);

        if (platform.transform.position.x == current.position.x && platform.transform.position.y == current.position.y)
        {
            pointselect++;

            if (pointselect == points.Length)
            {
                pointselect = 0;
            }

            current = points[pointselect];
        }
    }
}
