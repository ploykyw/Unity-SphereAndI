using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour {

	public List<Image> slots = new List<Image>();
	private List<string> imgname = new List<string> ();
	public static int slotsNum; 
	public int imageNum;


	public void Start(){
		slotsNum = slots.Count;
		print (slotsNum);

		for(int i = 0 ; i < slotsNum;i++){
			slots [i].enabled = false;
		}

	}

	public void OnClick(string imageName){
		
		int a = buttonTagAddArray.myList.Count;

		if(imgname.Count < a){
		imgname.Add (imageName);
		}

		for(int i = 0; i < a ; i ++){

			slots [i].enabled = true;
			slots [i].sprite = Resources.Load<Sprite> ("button/"+imgname [i]) as Sprite;

		}

		imageNum = imgname.Count;
		print (imageNum);
	}

}
