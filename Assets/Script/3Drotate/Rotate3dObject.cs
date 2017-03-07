using UnityEngine;
using System.Collections;

public class Rotate3dObject : MonoBehaviour {

	public float speed = 10f;

	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, speed * Time.deltaTime, 0);
	}

	public void AdjustSpeed(float newSpeed){
		speed = newSpeed;
	}
}
