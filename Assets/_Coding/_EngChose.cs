using UnityEngine;
using System.Collections;

public class _EngChose : _BaseClass {
	
	public GUITexture S_Eng;
	public GUITexture G_Eng;
	public GUITexture Exit;
	public GUITexture bg;

	
	
	private float width,height;
	public AudioClip clickSound;
	
	
	// Use this for initialization
	void Start () {
		
		width = Screen.width;
		height = Screen.height;
		
		bg.pixelInset = new Rect(0,0,width,height);
		
		
		
		
		if(height == 1136){
			
			if(S_Engine > 0 && G_Engine > 0){
			
				S_Eng.pixelInset = new Rect(width/2f,0,width/3,height/4.5f);
				G_Eng.pixelInset = new Rect(width/6,0,width/3,height/4.5f);
			}
			else if(S_Engine > 0){
				S_Eng.pixelInset = new Rect(width/3f,0,width/3,height/4.5f);
				G_Eng.gameObject.SetActiveRecursively(false);
				
			}else if(G_Engine > 0){
				G_Eng.pixelInset = new Rect(width/3f,0,width/3,height/4.5f);
				S_Eng.gameObject.SetActiveRecursively(false);
			}
			Exit.pixelInset = new Rect(0,0,width/5,height/8);
			
			
		}else {
		
			if(S_Engine > 0 && G_Engine > 0){
			
				S_Eng.pixelInset = new Rect(width/2f,0,width/3,height/4f);
				G_Eng.pixelInset = new Rect(width/6,0,width/3,height/4f);
			}
			else if(S_Engine > 0){
				S_Eng.pixelInset = new Rect(width/3f,0,width/3,height/4f);
				G_Eng.gameObject.SetActiveRecursively(false);
				
			}else if(G_Engine > 0){
				G_Eng.pixelInset = new Rect(width/3f,0,width/3,height/4f);
				S_Eng.gameObject.SetActiveRecursively(false);
			}
			
			
			Exit.pixelInset = new Rect(0,0,width/5,height/7);
		}
	
	}
	
	
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetMouseButtonDown(0)){
			
			
			Vector3 pos = Input.mousePosition;
			
			if(S_Eng.HitTest(pos)){
				
				if(S_Engine > 0){
					audio.PlayOneShot(clickSound);
					E_Index = 1;
					isS_Engine = true;
					StartCoroutine(waitlevels(1.2f));
				}
			}
			
			if(G_Eng.HitTest(pos)){
				
				if(G_Engine > 0){
					audio.PlayOneShot(clickSound);
					E_Index = 2;
					isG_Engine = true;
					StartCoroutine(waitlevels(1.2f));
				}
			}
			
			if(Exit.HitTest(pos)){
				audio.PlayOneShot(clickSound);
				isS_Engine = false;
				isG_Engine = false;
				E_Index = 0;
				StartCoroutine(waitlevels(1.2f));
			}
		
			
		}
		
		
	}
	
	
	IEnumerator waitlevels(float levelTm){
		
		yield return new WaitForSeconds(levelTm);
		
		Application.LoadLevel("GamePlay");
		Destroy(gameObject);
	}
	
}
