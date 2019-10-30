using UnityEngine;
using System.Collections;

public class _LoadingWait : _BaseClass {
	
	public GUITexture BG;
	
	private float width,height;
	// Use this for initialization
	void Start () {
		
		width = Screen.width;
		height = Screen.height;
		/*
		//Temp settings for testing purpose disable on submit time
		PlayerPrefs.SetInt("HelpIndex", 0);
		
		PlayerPrefs.SetInt("M_Health",0);
		PlayerPrefs.SetInt("COIN2X", 0);
		PlayerPrefs.SetInt("COIN4X", 0);
		PlayerPrefs.SetInt("S_ENG", 0);
		PlayerPrefs.SetInt("G_ENG", 0);
		PlayerPrefs.SetInt("obj1",0);
		PlayerPrefs.SetInt("obj2",0);
		PlayerPrefs.SetInt("obj3",0);
		PlayerPrefs.SetInt("obj4",0);
		PlayerPrefs.SetInt("obj5",0);
		PlayerPrefs.SetInt("obj6",0);
		PlayerPrefs.SetInt("obj7",0);
		PlayerPrefs.SetInt("obj8",0);
		PlayerPrefs.SetInt("obj9",0);
		PlayerPrefs.SetInt("obj10",0);
		
		*/
		


		
		BG.pixelInset = new Rect(0,0,width,height);
		StartCoroutine(WaitForLoading());
	}


	IEnumerator WaitForLoading(){


		yield return new WaitForSeconds(1.0f);
		Application.LoadLevel("GamePlay");
	}
	// Update is called once per frame
	void Update () {
	
	}
}
