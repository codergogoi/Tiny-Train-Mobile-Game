using UnityEngine;
using System.Collections;

public class _CamAction : _BaseClass {
			
	private Ray ray;
	private RaycastHit hit;
	private int tryme;
	
	
	//public AudioClip bgmusic;
	
	// Use this for initialization
	void Start () {
		tryme = PlayerPrefs.GetInt("try");
	
	}
	


	
	// Update is called once per frame
	void Update () {
		
				if(Input.GetMouseButtonDown(0)){
				
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					
				
						if(Physics.Raycast(ray, out	 hit, 500)){
						
							
								if(hit.collider.tag=="_go_retry"){ 
									tryme+=1;
									PlayerPrefs.SetInt("try",tryme);
									_GameOverMenu.isGE1 = true;
									score = 0;
									
									StartCoroutine(waitlevels(0.9f));
								}
				
				
								if(hit.collider.tag=="_go_exit"){ 
									
								 	_GameOverMenu.isGE2 = true;
									StartCoroutine(MainMenuOpen(0.9f));
								
								}
				
						
						
				}
			
				
			
			}
		
		
		
		
	
		
	}
	
	
	IEnumerator waitlevels(float levelTm){
		
		yield return new WaitForSeconds(levelTm);
		
		Application.LoadLevel("GamePlay");
	}
	
	IEnumerator MainMenuOpen(float levelTm){
		
		yield return new WaitForSeconds(levelTm);
		
		Application.LoadLevel("MainMenu");
	}
	

}
