using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//list of all possible game states
public enum GameState
{
	NotStarted,
	Playing,
	Completed,
	Failed
}

//requires an audiosource 
[RequireComponent(typeof(AudioSource))]

public class GameManager : MonoBehaviour {

	public AudioClip StartSound;
	public AudioClip FailedSound;

	private GameState currentState = GameState.NotStarted;

	private Brick[] allBricks;
	private Ball[] allBalls;
	private Paddle paddle;

	public float Timer = 0.0f;
	private int minutes;
	private int seconds;
	public string formattedTime;


	// Use this for initialization
	void Start () {
		Time.timeScale = 1;

		//find all bricks in the scene
		allBricks = FindObjectsOfType(typeof(Brick)) as Brick[];

		//find all balls in the scene
		allBalls = FindObjectsOfType(typeof(Ball)) as Ball[];

		paddle = GameObject.FindObjectOfType<Paddle> ();

		print ("Bricks:" + allBricks.Length);
		print ("Balls:" + allBalls.Length);
		print ("paddle:" + paddle);

		SwitchState (GameState.NotStarted);
	}
	
	// Update is called once per frame
	void Update () {
		switch (currentState) {
		default:
		case GameState.NotStarted:
			//check if player taps/clicks
			if (Input.GetMouseButtonDown (0)) {
				SwitchState (GameState.Playing);
			}
			break;
		case GameState.Playing:
			Timer += Time.deltaTime;
			minutes = Mathf.FloorToInt (Timer / 60F);
			seconds = Mathf.FloorToInt (Timer - minutes * 60F);
			formattedTime = string.Format ("{0:0}:{1:00}", minutes, seconds);

			bool allBlocksDestroyed = false;

			//are there no balls left?
			if (FindObjectsOfType (typeof(Ball)) == null) {
				SwitchState (GameState.Failed);
			}
			if (allBlocksDestroyed) {
				SwitchState (GameState.Completed);
			}
			break;
		case GameState.Failed:
			print ("Game FAILED");
			break;
		case GameState.Completed:
			print ("Game WON!");
			bool allBlocksDestroyedFinal = false;
			Ball[] others = FindObjectsOfType (typeof(Ball)) as Ball[];
			foreach (Ball ball in others) {
				Destroy (ball.gameObject);
			}
			break;
		}
	}

	void SwitchState(GameState newState){
		currentState = newState;

		switch (currentState) {
		default:
		case GameState.NotStarted:
			break;
		case GameState.Playing:
			GetComponent<AudioSource> ().PlayOneShot (StartSound);
			break;
		case GameState.Failed:
			GetComponent<AudioSource> ().PlayOneShot (FailedSound);
			break;
			

		}
	}
}
