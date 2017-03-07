using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour {

	public Text afterExecuteCmd;
	private string afterExcuteCmdString;

	public int GameEpisode; // forest = 1 , sea = 2 , desert = 3
	public SceneFader sceneFader;

	public AudioSource BGM;


	public int gameMission;
	public Animator Anim1;

	private bool isRunning;

	public Button btnMain;
	public Button btnProc;

	public Button btnStart;
	public Button clearCommandBtn;


	private string type; //either main or proc

	private List<int> mainSteps; // keeps track of the steps the user entered for main
	private List<int> procSteps; // keeps track of the steps the user entered for proc

	private List<string> mainStepsString;
	private List<string> procStepsString;

	public int maxMain = 8; // maximum steps allowed in main
	public int maxProc = 12; // maximum steps allowed in proc

	private Dictionary<int, Sprite> iconDict;

	public Sprite spForward;
	public Sprite spLeft;
	public Sprite spRight;
	public Sprite spJump;
	public Sprite spP1;

	public Sprite spBlank;

	public bool isExecute;

	//my code

	public Rigidbody rb;

	private Vector3 target;
	private Vector3 start;

	public float time;

	GameObject Adam;

	private Button myselfButton;
	public List<Image> slots = new List<Image>();

	private IEnumerator co;
	private IEnumerator s;
	//private bool isTouchingWall;

	public static List<string> myList = new List<string>();


	void Start(){
		BGM.Play ();

		myselfButton = GetComponent<Button> ();

		Adam = GameObject.FindWithTag("Player");
		rb = Adam.GetComponent<Rigidbody> ();	
		Anim1 = Adam.GetComponent<Animator> ();

		mainSteps = new List<int> ();
		procSteps = new List<int> ();

		mainStepsString = new List<string> ();

		iconDict = new Dictionary<int, Sprite> () {
			{ 0, spForward },
			{ 1, spLeft },
			{ 2, spRight },
			{ 3, spJump },
			{ 4, spP1 }
		};

		isExecute = false;
	}

	public void Update(){
		for (int i = 0; i < mainSteps.Count; i++) {
			Image img = (Image)GameObject.Find (string.Format("img_m{0:00}", i+1)).GetComponent<Image>();
			img.sprite = iconDict[mainSteps[i]];
		}
		for (int i = 0; i < procSteps.Count; i++) {
			Image img = (Image)GameObject.Find (string.Format("img_p{0:00}", i+1)).GetComponent<Image>();
			img.sprite = iconDict[procSteps[i]];
		}

		if(GameManager.isTouchingSphere == true){
			BGM.volume = 0.2f;
		}

		if(GameManager.isTouchingFloor == true){
			BGM.volume = 0.2f;
		}


	}

	public void SetTypeToMain()
	{
	//	Color pink = new Color(2.5f,1f,0.5f);

		type = "main";
		print ("main fucn");
		btnMain.image.color = Color.yellow;
		btnProc.image.color = Color.grey;
	}

	public void SetTypeToProc()
	{
		
		type = "proc";
		print ("func");
		btnMain.image.color = Color.grey;
		btnProc.image.color = Color.yellow;

	}



	public bool TypeSelected()
	{
		if (type != null)
			return true;
		else
			return false;
	}

	public void AddToStepList(int index)
	{

		if(GameEpisode == 1){
			{
				if (mainSteps.Count < maxMain)
					mainSteps.Add (index);
				if(index == 0){

				}
				if(index == 1){
					
				}
				if(index == 3){
					
				}
			}	

		}


		if(GameEpisode == 2){
			if (!TypeSelected ()) {
				Debug.Log ("Type Not Selected Yet");
				return;
			}

			if (type == "main") {
				if (mainSteps.Count < maxMain)
					mainSteps.Add (index);
			}
			else
			{
				if (index == 4) {
					Debug.Log ("Recursion is blocked, out of scope!");
					return;
				}
				if(procSteps.Count < maxProc)
					procSteps.Add (index);
			}
		}
	}



	public void ResetCommandUI(){
		mainSteps.Clear();
		procSteps.Clear();

		if(gameMission == 1){
		// reset steps UI
			for (int i = 0; i < maxMain; i++) {
				Image img = (Image)GameObject.Find (string.Format("img_m{0:00}", i+1)).GetComponent<Image>();
				img.sprite = spBlank;
			}


		}

		if(gameMission == 2){
			// reset steps UI
			for (int i = 0; i < maxMain; i++) {
				Image img = (Image)GameObject.Find (string.Format("img_m{0:00}", i+1)).GetComponent<Image>();
				img.sprite = spBlank;
			}

			for (int i = 0; i < maxProc; i++) {
				Image img = (Image)GameObject.Find (string.Format("img_p{0:00}", i+1)).GetComponent<Image>();
				img.sprite = spBlank;
			}
		}
	}

	public void Run()
	{
		
		isRunning = true;
		btnStart.interactable = false;

		clearCommandBtn.interactable = false;

		StartCoroutine(ExecuteSteps());

		if(gameMission == 1){
		StartCoroutine(ShowAfterExecuteCommand ());
		}
	}

	IEnumerator ExecuteSteps()
	{
		if(gameMission == 1){
		foreach (int action in mainSteps) {
			
//			Debug.Log (GameManager.isTouching);
			Anim1.SetBool ("isWalking", true);
				
			if (action == 0) { // move forward
				mainStepsString.Add("ADAM.FORWARD();");
				if(GameManager.isTouching == false){
					
					StartCoroutine (MoveToPosition (time));
				}
					
				if(GameManager.isTouching == true){
					Debug.Log ("Argggg Stop");
					Anim1.SetBool ("isWalking", false);
					break;
				}

				if(GameManager.canWalk == false){
					Anim1.SetBool ("isWalking", false);
					break;
				}
				yield return new WaitForSeconds (1f);
			} else if (action == 1) { // turn left
				StartCoroutine(ChangeDegreesLeft(time));
				mainStepsString.Add("ADAM.TURNLEFT();");

				yield return new WaitForSeconds (1f);
			} else if (action == 2) { // turn right
				mainStepsString.Add("ADAM.TURNRIGHT();");
				StartCoroutine (ChangeDegreesRight (time));

				yield return new WaitForSeconds (1f);
			} else if (action == 3) { // jump
					mainStepsString.Add("ADAM.JUMP();");
				StartCoroutine (JumpingUp (time));
				yield return new WaitForSeconds (1f);
			} else if (action == 4) { // run P1
				
				foreach (int act in procSteps) {
					if (act == 0) { // move forward
						if(GameManager.isTouching == false){
							StartCoroutine (MoveToPosition (time));
						}
						if(GameManager.isTouching == true){
							Debug.Log ("Argggg Stop");
							Anim1.SetBool ("isWalking", false);
							break;
						}
					} else if (act == 1) { // turn left
						StartCoroutine(ChangeDegreesLeft(time));
					} else if (act == 2) { // turn right
						StartCoroutine (ChangeDegreesRight (time));
					} else if (act == 3) { // toggle light
						StartCoroutine (JumpingUp (time));
					} else if(act == 4){
						
					}

					yield return new WaitForSeconds (1f); // pause for 1 second bewtween each step

				}
					
			}
		}
		}

		if(gameMission == 2){
			foreach (int action in mainSteps) {

				//			Debug.Log (GameManager.isTouching);
				Anim1.SetBool ("isWalking", true);

				if (action == 0) { // move forward
					//mainStepsString.Add("ADAM.FORWARD();");
					if(GameManager.isTouching == false){

						StartCoroutine (MoveToPosition (time));
					}

					if(GameManager.isTouching == true){
						Debug.Log ("Argggg Stop");
						Anim1.SetBool ("isWalking", false);
						break;
					}

					if(GameManager.canWalk == false){
						Anim1.SetBool ("isWalking", false);
						break;
					}
					yield return new WaitForSeconds (1f);
				} else if (action == 1) { // turn left
					StartCoroutine(ChangeDegreesLeft(time));
					//mainStepsString.Add("ADAM.TURNLEFT();");

					yield return new WaitForSeconds (1f);
				} else if (action == 2) { // turn right
					//mainStepsString.Add("ADAM.TURNRIGHT();");
					StartCoroutine (ChangeDegreesRight (time));

					yield return new WaitForSeconds (1f);
				} else if (action == 3) { // jump
					StartCoroutine (JumpingUp (time));
					yield return new WaitForSeconds (1f);
				} else if (action == 4) { // run P1

					foreach (int act in procSteps) {
						if (act == 0) { // move forward
							if(GameManager.isTouching == false){
								StartCoroutine (MoveToPosition (time));
							}
							if(GameManager.isTouching == true){
								Debug.Log ("Argggg Stop");
								Anim1.SetBool ("isWalking", false);
								break;
							}
						} else if (act == 1) { // turn left
							StartCoroutine(ChangeDegreesLeft(time));
						} else if (act == 2) { // turn right
							StartCoroutine (ChangeDegreesRight (time));
						} else if (act == 3) { // toggle light
							StartCoroutine (JumpingUp (time));
						} else if(act == 4){

						}

						yield return new WaitForSeconds (1f); // pause for 1 second bewtween each step

					}

				}
			}
		}
		Anim1.SetBool ("isWalking",false);
	}
		


	IEnumerator MoveToPosition(float time){


			start = Adam.transform.position;
			target = Adam.transform.position + Adam.transform.forward;


			float elapsedTime = 0;

			while (elapsedTime <= time) {

				Adam.transform.position = Vector3.Lerp (start, target, (elapsedTime / time));
				elapsedTime += Time.deltaTime;	


				yield return null;

				}
		
	}

	IEnumerator ChangeDegreesLeft(float time){

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

	IEnumerator ChangeDegreesRight(float time){

		float minAngle ;
		float maxAngle ;

		minAngle = Adam.transform.eulerAngles.y;
		maxAngle = Adam.transform.eulerAngles.y + 90.0f;

		float elapsedTime = 0;

		while (elapsedTime <= time) {
			float angle = Mathf.LerpAngle (minAngle, maxAngle,elapsedTime / time);

			Adam.transform.eulerAngles = new Vector3 (0, angle, 0);
			elapsedTime += Time.deltaTime;	

			yield return null;
		}
	}

	IEnumerator JumpingUp(float time){


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

	public void ClearAllCommand(){
		procSteps.Clear ();
		mainSteps.Clear ();
	}

	IEnumerator ShowAfterExecuteCommand(){

		for(int i = 0 ; i < mainStepsString.Count ; i ++){

			afterExcuteCmdString += mainStepsString [i] + "\n";
			Debug.Log (afterExcuteCmdString);
			yield return new WaitForSeconds (1f);

		}
		afterExecuteCmd.text = afterExcuteCmdString;
							
	}
}
