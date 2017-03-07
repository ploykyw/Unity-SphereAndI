using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	static Animator anim;
	GameObject Adam;

	public AudioSource winSound;
	//public AudioClip audioClip;

	public AudioSource gameOverSound;
	//public AudioClip audioClip1;

	public static bool GameIsOver;
	public GameObject gameOverUI;

	private GameObject controlPanel;
	public GameObject completeLevelUI;

	public GameObject sphere;

	public static bool isTouching;
	public static bool canWalk;
	public static bool isTouchingSphere;
	public static bool isTouchingFloor;


	void Start ()
	{
		GameIsOver = false;
		controlPanel = GameObject.FindWithTag ("controlPanel");

		isTouching = false;
		canWalk = true;
		isTouchingSphere = false;
		isTouchingFloor = false;

		Adam = GameObject.FindWithTag("Player");
		anim = Adam.GetComponent<Animator> ();
	}

	// Update is called once per frame
	void OnTriggerEnter(Collider other){
		
		if (other.GetComponent<Collider> ().tag == "Floor") {
			Debug.Log ("HIT THE FLOOR");
			EndGame ();

			isTouchingFloor = true;

			controlPanel.SetActive (false);

		}
           
		if (other.GetComponent<Collider> ().tag == "Sphere") {
			Debug.Log ("FOUND SPHERE WIN LEVEL");

			isTouchingSphere = true;

			//btnSound.clip = audioClip;
			//btnSound.Play ();

			anim.SetBool ("isWalking",false);
			//Destroy (other.gameObject);


				Destroy (other.gameObject);
				WinLevel ();
				

			controlPanel.SetActive (false);
		}

		if (other.GetComponent<Collider> ().tag == "wall") {
			Debug.Log ("wall ja");

			isTouching = true;

		
		}


		if (other.GetComponent<Collider> ().tag == "jumpPoint") {
			Debug.Log ("only jump");

			canWalk = false;

		}

		//
	}		

	void OnTriggerExit (Collider other){
		if (other.GetComponent<Collider> ().tag == "wall") {
			Debug.Log ("exit colider");

			isTouching = false;
			Debug.Log (isTouching);

		}

		if (other.GetComponent<Collider> ().tag == "floor") {
			Debug.Log ("exit floor");
		

		}

		if (other.GetComponent<Collider> ().tag == "jumpPoint") {
			Debug.Log ("exit jump jump");

			canWalk = true;


		}

	}


	void EndGame ()
	{

		gameOverSound.Play ();
		
		GameIsOver = true;
		gameOverUI.SetActive(true);
	}

	public void WinLevel ()
	{
		

		GameIsOver = true;
		completeLevelUI.SetActive(true);


			winSound.Play ();

	}
		

}
