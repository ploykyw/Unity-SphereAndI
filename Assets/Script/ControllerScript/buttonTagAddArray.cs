using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonTagAddArray : MonoBehaviour {

	static Animator anim;

	public GameObject commandPanel;
	public Button RunButton;

	GameObject Adam;

	private Button myselfButton;

	public float time;

	private Vector3 target;
	private Vector3 start;

	private bool isRunning;

	public static List<string> myList = new List<string>();

	private Rigidbody rigid;


	void Start(){
		myselfButton = GetComponent<Button> ();
		Adam = GameObject.FindWithTag("Player");
		anim = Adam.GetComponent<Animator> ();
		rigid = Adam.GetComponent<Rigidbody> ();

		isRunning = false;
	}



	public void OnClicked(Button myselfButton){

		int b = Slots.slotsNum;


			switch (myselfButton.tag) {

		case "Forward":
			print ("Forward was clicked");
			if (myList.Count < b) {	
					myList.Add ("forward");
			}
				break;

		case "TurnLeft":
			print ("TurnLeft was clicked");
			if (myList.Count < b) {	
				myList.Add ("turnleft");
			}
				break;

		case "TurnRight":
			print ("TurnLeft was clicked");
			if (myList.Count < b) {	
				myList.Add ("turnright");
			}
				break;

		case "Jump":
			print ("Jump was clicked");
			if (myList.Count < b) {	
				myList.Add ("jump");
			}
				break;

		case "Run":
			
			print ("RUN");
			isRunning = true;

			RunButton.interactable = false;
			//commandPanel.SetActive (false);

				for (int i = 0; i < myList.Count; i++) {

					print (myList [i]);


					if (myList [i] == "forward") {

						StartCoroutine (MoveToPosition (time, time * i));						
						if (ColliderDetect.isTouching = true) {
						
						}
					} 

					if (myList [i] == "turnleft") {
					
						StartCoroutine (ChangeDegreesLeft (time, time * i));

					}
					if (myList [i] == "turnright") {
					
						StartCoroutine (ChangeDegreesRight (time, time * i));

					}
					if (myList [i] == "jump") {

						StartCoroutine (JumpUp (time, time * i));

					}
				}
				myList.Clear ();

				break;

			case "Reset":
				print ("clear array");
				myList.Clear ();
				break;

			}

	
	}


	IEnumerator MoveToPosition(float time,float waitTime){
		yield return new WaitForSeconds (waitTime);

		start = Adam.transform.position;
		target = Adam.transform.position + Adam.transform.forward;


		float elapsedTime = 0;


			while (elapsedTime <= time) {

				Adam.transform.position = Vector3.Lerp (start, target, (elapsedTime / time));
				elapsedTime += Time.deltaTime;	

		
				anim.SetBool ("isWalking", true);

				yield return null;

			}

	}

	IEnumerator ChangeDegreesLeft(float time,float waitTime){

		yield return new WaitForSeconds (waitTime);

		float minAngle ;
		float maxAngle ;

		minAngle = Adam.transform.eulerAngles.y;
		maxAngle = Adam.transform.eulerAngles.y - 90.0f;

		float elapsedTime = 0;

		while (elapsedTime <= time) {
			float angle = Mathf.LerpAngle (minAngle, maxAngle,elapsedTime / time);

			Adam.transform.eulerAngles = new Vector3 (0, angle, 0);
			elapsedTime += Time.deltaTime;	

			yield return null;
		}
	}


	IEnumerator ChangeDegreesRight(float time,float waitTime){

		yield return new WaitForSeconds (waitTime);

		float minAngle;
		float maxAngle;

		minAngle = Adam.transform.eulerAngles.y;
		maxAngle = Adam.transform.eulerAngles.y + 90.0f;

		float elapsedTime = 0;

		while (elapsedTime <= time) {
			float angle = Mathf.LerpAngle (minAngle, maxAngle, elapsedTime / time);

			Adam.transform.eulerAngles = new Vector3 (0, angle, 0);
			elapsedTime += Time.deltaTime;	

			yield return null;
		}
	}


	IEnumerator JumpUp(float time,float waitTime){
		
		yield return new WaitForSeconds (waitTime);

		start = Adam.transform.position;
		target = Adam.transform.position + Adam.transform.forward;


		float elapsedTime = 0;
    	float amplitude = 1.0f; // height factor


		while (elapsedTime <= time) {

        Adam.transform.position = Vector3.Lerp (start, target, (elapsedTime / time));
			var pos = Adam.transform.position;
			pos.y += amplitude * Mathf.Sin((elapsedTime / time) * 3.14159265f);
				
        Adam.transform.position = pos;
        elapsedTime += Time.deltaTime;	

        yield return null;

		}

	}

}
