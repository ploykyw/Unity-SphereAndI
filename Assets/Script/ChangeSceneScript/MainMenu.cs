using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string levelToLoad = "2_mainMenu";

	public SceneFader sceneFader;

	public void Play ()
	{
		
		sceneFader.FadeTo(levelToLoad);
	}

	public void ClearMyList(){
		buttonTagAddArray.myList.Clear ();
	}

	public void Quit ()
	{
		Debug.Log("Exciting...");
		Application.Quit();
	}

}
