using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour {

	private Ball ball;

	IEnumerator Pause(){
		print ("Before waiting 2 seconds");
		yield return new WaitForSeconds (2);

		//find the ball and reset the game
		Ball ball =  GameObject.FindObjectOfType<Ball>();
		ball.gameStarted = false;

		//reload Level
		Application.LoadLevel(Application.loadedLevel);

		print ("After 2 seconds");

	}

	void OnTriggerEnter2D(Collider2D trigger){
		print ("Loss Triggered");
		//wait before restarting level

		StartCoroutine (Pause());
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
