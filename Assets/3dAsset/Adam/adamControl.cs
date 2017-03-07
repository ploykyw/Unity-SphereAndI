using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adamControl : MonoBehaviour {
	

	static Animator anim;

	public float speed = 3f;
	public float rotationSpeed = 100.0f;





	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

		float translation = Input.GetAxis ("Vertical") * speed / 2; 
		float rotation = Input.GetAxis ("Horizontal") * rotationSpeed;

		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;

		transform.Translate (0, 0, translation);
		transform.Rotate (0, rotation, 0);

		if(Input.GetKeyDown(KeyCode.Space)){
			Debug.Log ("pressed a");

			anim.SetTrigger ("isJumping");

			
			//transform.Translate (0.1f, 0, translation);
		}

		if (translation != 0) {
			anim.SetBool ("isWalking",true);
			anim.SetBool ("isIdle", false);
		} else {
			anim.SetBool("isWalking",false);
			anim.SetBool ("isIdle", true);
		}


	}
}
