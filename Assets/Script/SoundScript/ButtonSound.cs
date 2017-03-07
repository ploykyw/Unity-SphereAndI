using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour {

	public AudioSource btnSound;
	public AudioClip audioClip;

	public void PlayClip(){
		btnSound.clip = audioClip;
		btnSound.Play ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
