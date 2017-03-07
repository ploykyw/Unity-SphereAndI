using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

    public float moveSpeed;
    public float turnSpeed;
    private float distance = 1.0f;
    private Vector3 newPosition;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        {
            if (Input.GetKey(KeyCode.UpArrow))
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.DownArrow))
                transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftArrow))
                transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.RightArrow))
                transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);



            Vector3 newPos = transform.position;
            

            //เดินหน้า
            if (Input.GetKeyDown(KeyCode.U))
            {
                newPos += transform.forward.normalized * distance;
                // transform.Translate(new Vector3 (0, 0, 1));
            }
            transform.position = newPos;


        }

        
    }

   
}
