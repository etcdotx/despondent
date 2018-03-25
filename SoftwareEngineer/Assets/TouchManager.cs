using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour {
	private float drag_distance;
	private Vector2 fp;
	private Vector2 lp;

	// Use this for initialization
	void Start () {
		drag_distance = Screen.width * 15 / 100;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 1) {

		}
	}
}
