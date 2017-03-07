using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

	public float delayTime;
	public string SceneToChangeTo = "1_Index";
	public SceneFader sceneFader;



	IEnumerator Start(){
		yield return new WaitForSeconds (delayTime);
		//print (Time.deltaTime);
		sceneFader.FadeTo (SceneToChangeTo);
	}

}
