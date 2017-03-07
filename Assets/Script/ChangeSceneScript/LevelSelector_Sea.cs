﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelSelector_Sea : MonoBehaviour {
	
	public SceneFader fader;
	public Button[] levelButtons;

	// Use this for initialization
	void Start () {
		
		int levelReached = PlayerPrefs.GetInt("levelReached_sea", 1);

		for (int i = 0; i < levelButtons.Length; i++)
		{
			if (i + 1 > levelReached)
				levelButtons[i].interactable = false;
		}
	}
	
	public void Select (string levelName)
	{
		fader.FadeTo(levelName);
	}
}