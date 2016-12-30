using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Paddle paddle;
	public bool gameStarted = false;
	private Vector3 paddleVector;


	// Use this for initialization
	void Start () {
		//set the balls position to the paddles position
		paddleVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameStarted) {
			this.transform.position = paddle.transform.position + paddleVector;
			if (Input.GetMouseButtonDown (0)) {
				print ("Mouse Clicked!");
				gameStarted = true;
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (2f, 10f);
			}
		}
	}
}