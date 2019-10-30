using UnityEngine;
using System.Collections;

public class _GameOverMenu : _Obj_BaseClass {
	
	
	public GameObject retry;
	public GameObject exit;
	public static bool isGO;
	public static bool isGE1;
	public static bool isGE2;
	public Light DS;
	
	public GameObject LastScore;
	public GameObject ObjectiveFinder;
	
	// star rank
	public GameObject Star1;
	public GameObject Star2;
	public GameObject Star3;
	public Texture2D[] starImg;
	
	//public AudioClip sound;
	private int RandAd;
	
	public RevMobSampleAppCSharp RvManager;

	// Use this for initialization
	void Start () {
	
	
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(isGO){
			
			isGO = false;
			
			ObjectiveFinder.SetActiveRecursively(true);
			StartCoroutine(RetryMenu_O(0.02f));
			StartCoroutine( ExitMenu_O(0.2f));
			DS.light.enabled = false;
			StartCoroutine(CounterStart(1.5f));
			StarRank();
			LastScore.GetComponent<TextMesh>().text = ""+ score;
			
			if(PlayerPrefs.GetInt("HighScore") < score){
			
				PlayerPrefs.SetInt("HighScore", score);
			}
			PlayerPrefs.SetInt("Health", Health);
			tempgold += Random.Range(0,tempgold/10);
			gold += tempgold;
		}
		
		if(isGE1){
			isGE1 = false;
			isGE2 = false;
			StartCoroutine(RetryMenu_E(0.02f));
			StartCoroutine(ExitMenu_E(0.2f));
		}else if(isGE2){
			isGE1 = false;
			isGE2 = false;
			StartCoroutine(RetryMenu_E(0.2f));
			StartCoroutine(ExitMenu_E(0.02f));
		}
	
	}
	
	IEnumerator CounterStart(float CntTime){
		
		
		yield return new WaitForSeconds(CntTime);
		
		if(tempgold > 0){
			gold += tempgold;
			LevelComplete.Tcounter = tempgold;
			LevelComplete.isCount = true;
			LevelComplete.isAlpha = true;
		}
	}
	
	
	
	void StarRank(){
		
		
		switch(star){
			
		case 1:
			Star1.renderer.material.mainTexture = starImg[1];
			Star2.renderer.material.mainTexture = starImg[0];
			Star3.renderer.material.mainTexture = starImg[0];
			break;
		case 2:
			Star1.renderer.material.mainTexture = starImg[1];
			Star2.renderer.material.mainTexture = starImg[1];
			Star3.renderer.material.mainTexture = starImg[0];
			break;
		case 3:
			Star1.renderer.material.mainTexture = starImg[1];
			Star2.renderer.material.mainTexture = starImg[1];
			Star3.renderer.material.mainTexture = starImg[1];
			break;
		default :
			Star1.renderer.material.mainTexture = starImg[0];
			Star2.renderer.material.mainTexture = starImg[0];
			Star3.renderer.material.mainTexture = starImg[0];
			
			break;
			
			
		}
		
		
	}
	
	
	
	IEnumerator RetryMenu_O(float rtime_o){
		
		yield return new WaitForSeconds(rtime_o);
		
		retry.animation.CrossFade("_GO_Retry_O", 0.2f);
		
		
					
	}
	
	IEnumerator RetryMenu_E(float rtime_e){
		
		yield return new WaitForSeconds(rtime_e);
		
		retry.animation.CrossFade("_GO_Retry_E", 0.2f);
		DS.light.enabled = true;
		tempgold = 0;
		ObjectiveFinder.SetActiveRecursively(false);
		
					
	}
	
	IEnumerator ExitMenu_O(float etime_o){
		
		yield return new WaitForSeconds(etime_o);
		
		exit.animation.CrossFade("_GO_Exit_O", 0.2f);
		//exit.audio.PlayOneShot(sound);

		StartCoroutine(WaitForShowRandoeAd(1.5f));
		
	}
	
	
	
	IEnumerator WaitForShowRandoeAd(float tm){

		yield return new WaitForSeconds(tm);

		RvManager.CallFullScreenAd();

		
		
	}
	
	
	IEnumerator ExitMenu_E(float etime_e){
		
		yield return new WaitForSeconds(etime_e);
		
		exit.animation.CrossFade("_GO_Exit_E", 0.2f);
		//exit.audio.PlayOneShot(sound);
		tempgold = 0;
		ObjectiveFinder.SetActiveRecursively(false);
		
					
	}
	
}
