using UnityEngine;
using System.Collections;

public class LevelComplete : _BaseClass  {
	
	
	public GameObject GameScore;
	
	public static float Tcounter;
	private float Counter;
	private float cScore;
	public static bool isCount;
	public AudioClip scoreSound;
	public AudioClip BonusSound;
	public GameObject CoinsCounter;
	
	private float SoundTime;
	
	public GameObject BGScene;
	//public Material bgM;
	
	public static bool isAlpha;
	private float alphaVal;
	private int BonusGold;
	
	// Use this for initialization
	void Start () {
	
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//if(isAlpha){
			
			//alphaVal += Time.deltaTime/2;
			//print(alphaVal);
			//bgM.color  = new Color(128.0f,128.0f,128.0f,alphaVal);
			//BGScene.renderer.sharedMaterial.color = new Color(255.0f,255.0f,255.0f,alphaVal);
			
		//	BGScene.renderer.material.color
			
			
		//}
	
		
		if(isCount){
			
			
			Counter += Time.deltaTime * (Tcounter/2);
			
			if(Counter > Tcounter){
	
				audio.pitch = 1.0f;
				audio.PlayOneShot(BonusSound);
				GameScore.GetComponent<TextMesh>().text = ""+ tempgold;
				CoinsCounter.transform.localScale = new Vector3(0.07f,0.1f,0.2f);
				StartCoroutine(WaitForNormalSizeFont(0.2f));
				isCount = false;
				
				
				
			}else{
				SoundTime += Time.deltaTime;
				
				if(SoundTime > 0.05f){
					
					audio.PlayOneShot(scoreSound);
					if(audio.pitch < 2.7f)
						audio.pitch += 0.1f;
					SoundTime = 0;
				}
				
				cScore = (int)Counter;
				
				GameScore.GetComponent<TextMesh>().text = ""+ cScore;
				
				
			
			}
			
		}
		
		
	}
	
	IEnumerator WaitForNormalSizeFont(float NFTime){
		
		
		yield return new WaitForSeconds(NFTime);
		
		CoinsCounter.transform.localScale = new Vector3(0.048f,0.09f,0.15f);
	}
	
	
}
