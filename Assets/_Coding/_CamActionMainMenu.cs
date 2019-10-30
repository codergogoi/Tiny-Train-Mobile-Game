using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class _CamActionMainMenu : _BaseClass {
			
	private Ray ray;
	private RaycastHit hit;
	
	private bool isEngEnabled;
	
	public GameObject EngineChoose;
	
	private List<GameCenterLeaderboard> leaderboards;
	private List<GameCenterAchievementMetadata> achievementMetadata;

	
	//public AudioClip bgmusic;
	
	// Use this for initialization
	void Start () {
		
		GameCenterManager.categoriesLoaded += delegate( List<GameCenterLeaderboard> leaderboards )
		{
			this.leaderboards = leaderboards;
		};
		
		GameCenterManager.achievementMetadataLoaded += delegate( List<GameCenterAchievementMetadata> achievementMetadata )
		{
			this.achievementMetadata = achievementMetadata;
		};
		
		GameCenterBinding.authenticateLocalPlayer();
		GameCenterBinding.loadLeaderboardTitles();
		
		string alias = GameCenterBinding.playerAlias();
	
	}
	


	
	// Update is called once per frame
	void Update () {
		
		
				if(Input.GetMouseButtonDown(0)){
				
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					
				
						if(Physics.Raycast(ray, out	 hit, 500)){
				
							
						
							
								if(hit.collider.tag=="_play"){ 
																	
									if(S_Engine > 0 || G_Engine > 0){
										
										_MainMenu.isM_Close = true;
										Instantiate(EngineChoose);
										
									}else{
										
										_MainMenu.isM_Close = true;
										E_Index = 0;
										StartCoroutine(waitlevels(1.2f));
									
									}
								}
				
				
								if(hit.collider.tag=="_options"){ 
									
								 	_MainMenu.isM_Close = true;
									StartCoroutine(WaitForOptions(1.2f));
								
								}
								
								if(hit.collider.tag=="_store"){ 
									
								 	_MainMenu.isM_Close = true;
									StartCoroutine(waitStore(1.2f));
								
								}
								if(hit.collider.tag=="gamecenter"){
					
									if( leaderboards != null && leaderboards.Count > 0 )
										{
											
											GameCenterBinding.reportScore( PlayerPrefs.GetInt("HighScore"), leaderboards[0].leaderboardId);
											
										}
									
									
									
									GameCenterBinding.showLeaderboardWithTimeScope( GameCenterLeaderboardTimeScope.AllTime );
					
								}
								
								if(hit.collider.tag=="_eng_1"){  // ghost engine
										
									isEngEnabled = false;
									_MainMenu.isEngSelected = true;
									E_Index =2;
									isG_Engine = true;
								 	StartCoroutine(waitlevels(1.2f));
								}
								if(hit.collider.tag=="_eng_2"){  // super engine
									isS_Engine = true;
									isEngEnabled = false;
									E_Index = 1;
								 	_MainMenu.isEngSelected = true;
									StartCoroutine(waitlevels(1.2f));
								}
					
						
				}
			
				
			
			}
	
		
	}
	
	IEnumerator WaitForEngExit(float EETime){
		
		yield return new WaitForSeconds(EETime);
		
		isEngEnabled = true;
	}
	
	
	
	IEnumerator waitlevels(float levelTm){
		
		yield return new WaitForSeconds(levelTm);
		
		Application.LoadLevel("Loading");
	}
	
	
	IEnumerator WaitForOptions(float levelTm){
		
		yield return new WaitForSeconds(levelTm);
		
		Application.LoadLevel("Options");
	}
	
	
	
	IEnumerator waitStore(float levelTm){
		
		yield return new WaitForSeconds(levelTm);
		
		Application.LoadLevel("Store");
	}

}
