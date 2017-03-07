using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscFade : MonoBehaviour {

	public int index;

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.LoadLevel (index);
		}
	}
}
