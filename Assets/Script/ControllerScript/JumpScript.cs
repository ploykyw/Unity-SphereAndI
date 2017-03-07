using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpScript : MonoBehaviour {

	static Animator anim;

	GameObject Adam;
	private Button myselfButton;

	public float time;

	private Vector3 target;
	private Vector3 start;

	List<string> myList = new List<string>();


	private Rigidbody rigid;

	public int speed;

	// Use this for initialization
	void Start () {
		Adam = GameObject.FindWithTag("Player");
		anim = Adam.GetComponent<Animator> ();
		rigid = Adam.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(Input.GetKeyDown(KeyCode.Space)){
			rigid.velocity = new Vector3 (0,1,0);
		}

	}

}
