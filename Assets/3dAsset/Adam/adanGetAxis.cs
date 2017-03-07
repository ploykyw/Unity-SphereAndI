using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adanGetAxis : MonoBehaviour {

	static Animator anim;

	public float speed = 10.0F;
	public float rotationSpeed = 100.0F;



	void Start () {
		anim = GetComponent<Animator> ();

	}

	void Update() {
		float translation = Input.GetAxis("Vertical") * speed;
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;


		if(Input.GetMouseButtonDown(0)){
			
		transform.Translate(0, 0, 1) ;


		}
		
		if (Input.GetMouseButtonDown (1)) {
			transform.Rotate (0, 90, 0);
		}
	}
}
