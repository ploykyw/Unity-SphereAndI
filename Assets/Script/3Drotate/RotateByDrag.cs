using UnityEngine;
using System.Collections;

public class RotateByDrag : MonoBehaviour {

	private float sensitivity;
	private Vector3 mouseReference;
	private Vector3 mouseOffset;
	private Vector3 rotation;
	private bool isRotating;
	
	void Start ()
	{
		sensitivity = 0.4f;
		rotation = Vector3.zero;
	}
	
	void Update()
	{
		if(isRotating)
		{
			// offset
			mouseOffset = (Input.mousePosition - mouseReference);
			
			// apply rotation
			rotation.y = -(mouseOffset.x + mouseOffset.y) * sensitivity;
			
			// rotate
			transform.Rotate(rotation);
			
			// store mouse
			mouseReference = Input.mousePosition;
		}
	}
	
	void OnMouseDown()
	{
		// rotating flag
		isRotating = true;
		
		// store mouse
		mouseReference = Input.mousePosition;
	}
	
	void OnMouseUp()
	{
		// rotating flag
		isRotating = false;
	}
}
