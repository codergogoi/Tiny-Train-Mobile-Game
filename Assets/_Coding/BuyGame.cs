using UnityEngine;
using System.Collections;

public class BuyGame : _BaseClass {
	
	public GUITexture Cancel;
	public GUITexture BuyButton;
	public GUITexture bg;
	public GUITexture MessageBG;
	
	private float width,height;
	public AudioClip clicksound;
	
	// Use this for initialization
	void Start () {
		
		_Hud.bPause = false;
 		Time.timeScale = 0.5f;
		
		width = Screen.width;
		height = Screen.height;
	
		bg.pixelInset = new Rect(0,0,width,height);
		
		/*	Play.pixelInset = new Rect(0,0,width/4,height/5);
			Credits.pixelInset = new Rect(0,0,width/4, height/5);
			
			Settings.pixelInset = new Rect(0,0,width/7,height/4f);
		}else{
			Play.pixelInset = new Rect(0,0,width/4,height/7);*/
		
		if(width == 1136){
			
			Cancel.pixelInset = new Rect(0,0,width/8,height/7f);
			BuyButton.pixelInset = new Rect(0,0,width/4, height/8);
			MessageBG.pixelInset = new Rect(0,0,width/2,height/3f);
		}else{
			Cancel.pixelInset = new Rect(0,0,width/9,height/8);
			BuyButton.pixelInset = new Rect(0,0,width/4, height/10);
			MessageBG.pixelInset = new Rect(0,0,width/2,height/3f);
		}
		
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(PlayerPrefs.GetInt("FullGame") > 1){
			
				
				Destroy(gameObject,0.3f);
			
			
		}	
		
		
		if(Input.GetMouseButtonDown(0)){
			
			
			Vector3 pos = Input.mousePosition;
			
			
			if(Cancel.HitTest(pos)){
				audio.PlayOneShot(clicksound);
				_Hud.bPause = false;
				Application.LoadLevel("Menu");
				
			}
			
			if(BuyButton.HitTest(pos)){
				
				audio.PlayOneShot(clicksound);
				StoreKitBinding.purchaseProduct( "TTLFULLGAME", 1 );
				BuyButton.gameObject.SetActiveRecursively(false);
				StartCoroutine(WaitForBuy(2.0f));
			}
			
			
		}
		
		
		if(PlayerPrefs.GetInt("FullGame") > 0){
			
			_Hud.bPause = true;
			Time.timeScale = 1;
			Destroy(gameObject);
		}
		
		
	
	}
	
	
	IEnumerator WaitForBuy(float btime){
		
		
		yield return new WaitForSeconds(btime);
		
		PlayerPrefs.SetInt("FullGame", 2);
		
	}
}
