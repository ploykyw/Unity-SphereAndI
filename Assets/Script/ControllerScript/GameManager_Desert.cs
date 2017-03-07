using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Desert : MonoBehaviour {
	static Animator anim;
	GameObject Adam;

	public AudioSource winSound;
	public AudioSource gameOverSound;

	public static bool GameIsOver;
	public GameObject gameOverUI;

	private GameObject controlPanel;
	public GameObject completeLevelUI;

	public GameObject sphere;

	public static bool isTouching1;
	//public static bool canWalk1;
	public static bool isTouchingSphere1;
	public static bool isTouchingFloor1;


	void Start ()
	{
		GameIsOver = false;
		controlPanel = GameObject.FindWithTag ("controlPanel");

		isTouching1 = false;
		//canWalk = true;
		isTouchingSphere1 = false;
		isTouchingFloor1 = false;

		Adam = GameObject.FindWithTag("Player");
		anim = Adam.GetComponent<Animator> ();
	}

	// Update is called once per frame
	void OnTriggerEnter(Collider other){

		if (other.GetComponent<Collider> ().tag == "Floor") {
			Debug.Log ("HIT THE FLOOR");
			EndGame ();

			isTouchingFloor1 = true;
			controlPanel.SetActive (false);
		}

		if (other.GetComponent<Collider> ().tag == "Sphere") {
			Debug.Log ("FOUND SPHERE WIN LEVEL");

			isTouchingSphere1 = true;

			anim.SetBool ("isWalking",false);
			//Destroy (other.gameObject);

			if(GameHandler2.isCorrectLoop == true){
				Destroy (other.gameObject);
				WinLevel ();
				Debug.Log ("isCorrect Answer");
			}

			if(GameHandler3.isCorrectLoop2 == true){
				Destroy (other.gameObject);
				WinLevel ();
				Debug.Log ("isCorrect Answer");
			}

			controlPanel.SetActive (false);
		}

		if (other.GetComponent<Collider> ().tag == "wall") {
			Debug.Log ("wall ja");

			isTouching1 = true;


		}



		if (other.GetComponent<Collider> ().tag == "jumpPoint") {
			Debug.Log ("only jump");

			//canWalk = false;

		}

		//
	}		

	void OnTriggerExit (Collider other){
		if (other.GetComponent<Collider> ().tag == "wall") {
			Debug.Log ("exit colider");

			isTouching1 = false;
			Debug.Log (isTouching1);

		}

		if (other.GetComponent<Collider> ().tag == "jumpPoint") {
			Debug.Log ("exit jump jump");

			//canWalk = true;


		}

	}


	void EndGame ()
	{
		GameIsOver = true;
		gameOverUI.SetActive(true);

		gameOverSound.Play ();
	}

	public void WinLevel ()
	{
		GameIsOver = true;
		completeLevelUI.SetActive(true);

		winSound.Play ();
	}


}
