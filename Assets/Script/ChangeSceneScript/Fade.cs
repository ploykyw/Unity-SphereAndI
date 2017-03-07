using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

	public int index;
	//public int sceneNum;
	//fade from alpha 0 to 1
	public void FadeMe(){
		StartCoroutine (DoFade());
	}

	//fade from alpha 1 to 0
	public void FadeIn(int index){
		StartCoroutine (DoFade2 (index));
		//StartCoroutine (Start ());
	}

	IEnumerator DoFade(){
		CanvasGroup canvasGroup = GetComponent<CanvasGroup> ();
		while(canvasGroup.alpha > 0)
		{
			canvasGroup.alpha -= Time.deltaTime /2.3f;
			yield return null;
		}
		canvasGroup.interactable = false;

		yield return null;
	}


	IEnumerator DoFade2(int index){
		int time;

		CanvasGroup canvasGroup = GetComponent<CanvasGroup> ();
		while(canvasGroup.alpha < 1)
		{
			canvasGroup.alpha += Time.deltaTime /1.5f;
			yield return null;
		}

	//	Debug.Log (""+canvasGroup.alpha);

		canvasGroup.interactable = false;

		yield return null;
		Application.LoadLevel(index);

	}		

}
