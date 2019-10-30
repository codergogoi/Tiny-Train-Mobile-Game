using UnityEngine;
using System.Collections;

public class _CamActionOptions : _BaseClass {
			
	private Ray ray;
	private RaycastHit hit;
	
	public GUITexture Back;
	
	public GameObject MusicIcon;
	public Texture2D[] musicImg;
	
	private float width,height;
	//public AudioClip bgmusic;
	
	// Use this for initialization
	void Start () {
		
		
		width = Screen.width;
		height = Screen.height;
		
		Back.pixelInset = new Rect(0,0, width/4,height/6);
		
		CheckMusic();
	
	}
	
	
	
	
	void Update () {
		
		 		
				if(Input.GetMouseButtonDown(0)){
			
			
					Vector3 touchPos = Input.mousePosition;
			
					if(Back.HitTest(touchPos)){
				
						_OptionsMenu.isS_Close = true;
						StartCoroutine(waitlevels(0.9f));
				
					}
				
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					
				
						if(Physics.Raycast(ray, out	 hit, 500)){
						
							
								if(hit.collider.tag=="_buy"){ 
																	
									print("Buy somting");
					
									
									
								}
				
								if(hit.collider.tag=="music"){
					
										if(isMusic){
						
											isMusic = false;
											CheckMusic();
										}else{
											
											isMusic = true;
											CheckMusic();
										}
					
								}
				
											
						
				}
			
				
			
			}
	
		
	}
	
	void CheckMusic(){
		
		if(isMusic){
						
			MusicIcon.renderer.sharedMaterial.mainTexture = musicImg[1];
			audio.Play();
		}else{
			MusicIcon.renderer.sharedMaterial.mainTexture = musicImg[0];
			audio.Stop();
		}

	}
	
	
	IEnumerator waitlevels(float levelTm){
		
		yield return new WaitForSeconds(levelTm);
		
		Application.LoadLevel("MainMenu");
	}
	

}
