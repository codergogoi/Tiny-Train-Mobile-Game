using UnityEngine;
using System.Collections;

public class _pauseMenu : _BaseClass {
	
	
	public GUITexture bg;
	public GUITexture replay;
	public GUITexture close;
	public GUITexture Numbers;
	
	public Texture2D[] img;
	
	private float width,height;
	
	private bool isReady;
	private float ReadyTime;
	private int ReadyIndex;
	
 
	// Use this for initialization
	void Start () {
		
 
		isReady = false;
		width = Screen.width;
		height = Screen.height;
				
		bg.pixelInset = new Rect(0,0,width,height);
		close.pixelInset = new Rect(0,0,width/6,height/8);
		replay.pixelInset = new Rect(0,0,width/6,height/8);
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
		
		if(isReady){
			
			ReadyTime += Time.deltaTime;
			
			if(ReadyTime > 0.5){
				
				ReadyIndex++;
				ReadyTime = 0;			
			}
			
			switch(ReadyIndex){
				
			
			case 1:
				Numbers.texture = img[0];
				break;
			case 2:
				Numbers.texture = img[1];
				break;
			case 3:
				Numbers.texture = img[2];
				break;
			case 4:
				isReady = false;
				Time.timeScale = 1;
				_Hud.bPause = true;
				Destroy(gameObject);
				break;
			
				
			}
			
		}
		
		
		
		
		if(Input.GetMouseButtonDown(0)){
			
			
			Vector3 pos = Input.mousePosition;
			
			if(replay.HitTest(pos)){
				Time.timeScale = 0.5f;
				Numbers.gameObject.SetActiveRecursively(true);
				isReady = true;
				replay.gameObject.SetActiveRecursively(false);
				close.gameObject.SetActiveRecursively(false);

				 
				
			}else if(close.HitTest(pos)){
				
				if(PlayerPrefs.GetInt("HighScore") < score){
			
					PlayerPrefs.SetInt("HighScore", score);
				}
				PlayerPrefs.SetInt("Health", Health);
				gold += tempgold;
				
				StartCoroutine(WaitForReload(0.5f));

				 
				
				
			}
			
			
		}
		
	}
	
	
	IEnumerator WaitForReload(float rtime){
				
		yield return new WaitForSeconds(rtime);
		
		Application.LoadLevel("MainMenu");

		PlayerPrefs.SetInt("S_ENG", S_Engine);
		PlayerPrefs.SetInt("G_ENG", G_Engine);
		
	}
}
