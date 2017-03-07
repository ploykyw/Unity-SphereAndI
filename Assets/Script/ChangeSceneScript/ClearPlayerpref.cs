using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPlayerpref : MonoBehaviour {
	
	public string menuSceneName = "MainMenu";

	public string nextLevel = "Level02";
	public int levelToUnlock = 2;

	public SceneFader sceneFader;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ClearPlayerPref ()
	{
		PlayerPrefs.DeleteAll ();
		sceneFader.FadeTo(nextLevel);
	}
}
