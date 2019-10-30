using UnityEngine;
using System.Collections;

public class _Hud : _BaseClass {
	
	public GameObject CScores;
	public GameObject TextCoins;

	public GUITexture Pause;
	
	private int TempScore;
	
	public GameObject PauseMenu;
	public static bool bPause;
	
	private float width,height;
	public GameObject HealthIcon;
	public Texture2D[] img;
	
	public GameObject Road1;
	public GameObject Road2;
	public GameObject Road3;
	public GameObject Road4;
	
	private int rand;
	
	private float buyTime;
	private bool BuyBool;

	//public GameObject CBManager;
	
	void Start () {
		
		
		if(PlayerPrefs.GetInt("HelpIndex") > 0){
			
			rand = Random.Range(1,5);
			
			switch(rand){
				
			case 1:
				Road1.SetActiveRecursively(true);
				break;
			case 2:
				Road2.SetActiveRecursively(true);
				break;
			case 3:
				Road3.SetActiveRecursively(true);
				break;
			case 4:
				Road4.SetActiveRecursively(true);
				break;
			default:
				Road1.SetActiveRecursively(true);
				break;
			
			}
		
			
			
		}else{
			
			Road1.SetActiveRecursively(true);
		}
		
		
		if(Health < 3){
				
			Health = 3;
			
		}
		Time.timeScale = 1;
		
		if(isMusic){
			
			audio.Play();
		}else{
			
			audio.Stop();
		}
		
		width = Screen.width;
		height = Screen.height;
		
		if(height == 1136){
			
			Pause.pixelInset = new  Rect(0,0,width/3,height/8);
			
		}else{
			
		
			Pause.pixelInset = new  Rect(0,0,width/4,height/8);
		}
		
		
		 CScores.GetComponent<TextMesh>().text = "0";
		 TextCoins.GetComponent<TextMesh>().text = "0";
		
		isOver = false;
		TempScore = 0;
		score =0;
		
		StartCoroutine(WaitForPauseFree(2.0f));
		
		
	}
	
	IEnumerator WaitForPauseFree(float stime){
		
		yield return new WaitForSeconds(stime);
		
		bPause = true;
		
	}
	
	void Update () {
		
	
		
		if(!bPause){
			
			audio.volume = 0.15f;
		}else{
			
			audio.volume = 0.7f;
		}
	
		if(Input.GetMouseButtonDown(0)){
			
			Vector3 touchPos = Input.mousePosition;
	
			if(Pause.HitTest(touchPos) && bPause &&!isOver){
				bPause = false;
				Instantiate(PauseMenu);	
				//CBManager.SetActive(true);
				Time.timeScale = 0.5f;
			}
		}
		
		
	
	    CScores.GetComponent<TextMesh>().text = ""+ score;
		
		if(is4XCoin)
			TextCoins.GetComponent<TextMesh>().text = "4x "+tempgold;
		else if(is2XCoin)
			TextCoins.GetComponent<TextMesh>().text = "2x "+tempgold;
		else
			TextCoins.GetComponent<TextMesh>().text = ""+tempgold;
				
	
		
		switch(Health){
		
			case 0 :
				HealthIcon.renderer.sharedMaterial.mainTexture = img[0];
				break;
			case 1:
				HealthIcon.renderer.sharedMaterial.mainTexture = img[1];
				break;
			case 2:
				HealthIcon.renderer.sharedMaterial.mainTexture = img[2];
				break;
			case 3:
				HealthIcon.renderer.sharedMaterial.mainTexture = img[3];
				break;
		default :
				HealthIcon.renderer.sharedMaterial.mainTexture = img[3];
			break;
			
			
	
		}
		
		if(isMegaHealth){
			
			HealthIcon.renderer.sharedMaterial.mainTexture = img[4];
			
		}			
	}
	
	
	
	
	
}
