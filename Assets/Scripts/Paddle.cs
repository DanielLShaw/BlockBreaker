using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print ("Paddle initialised");
	}
	
	// Update is called once per frame
	void Update () {

		//set variable for current position
		Vector3 paddlePos = new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z);

		//get mouse position
		float mousePos = (Input.mousePosition.x / Screen.width * 16);

		//set new mouse position

		paddlePos.x = Mathf.Clamp (mousePos, 0f, 16f);

		//change paddle position to match
		this.transform.position=paddlePos;

	}
}
