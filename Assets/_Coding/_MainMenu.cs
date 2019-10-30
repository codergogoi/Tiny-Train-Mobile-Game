using UnityEngine;
using System.Collections;

public class _MainMenu : _BaseClass {
	
	
	public AudioClip sound;
	
	public GameObject Play;
	public GameObject Options;
	public GameObject Store;
	public GameObject bar;
	public GameObject TopBar;
	
	public bool isM_Open;
	public static bool isM_Close;
	private int HelpCheck;
	public GameObject ScoreText;
	private bool isEng1,isEng2;
	public static bool isEngSelected;
	// Use this for initialization
	void Start () {
		
		Time.timeScale = 1;
		
		
		if(isMusic){
				audio.Play();
			
		}else{
			
				audio.Stop();
			
		}
		
		ScoreText.GetComponent<TextMesh>().text = ""+PlayerPrefs.GetInt("HighScore");
		HelpCheck = PlayerPrefs.GetInt("HelpIndex");
		Health = PlayerPrefs.GetInt("Health");
		PlayerPrefs.SetInt("Gold",gold);
		StartCoroutine(SMenu(0.3f));
		
			S_Engine = PlayerPrefs.GetInt("S_ENG");
			G_Engine = PlayerPrefs.GetInt("G_ENG");
		
		if(HelpCheck > 1){
			
			isHelp = false;
			
		}else{
			
			isHelp = true;
		}
		
		if(PlayerPrefs.GetInt("COIN2X") > 0){
			
			is2XCoin = true;
		}
		
		if(PlayerPrefs.GetInt("COIN4X") > 0){
			
			is4XCoin = true;
		}
		
		if(PlayerPrefs.GetInt("M_Health")> 0){
			
			isMegaHealth = true;
			
		}
		
		
		/*Engine Choose Popup
		 * if(S_Engine > 0 || G_Engine > 0 || M_Engine > 0){
			
			Instantiate(EngChose);
		}
		*/
	
		
	}
	
	IEnumerator SMenu(float smtime){
		
		yield return new WaitForSeconds(smtime);
		
		isM_Open = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(isM_Open){
			isM_Open = false;
			StartCoroutine(Bar_Menu_O(0.01f));
			StartCoroutine(Play_Menu_O(0.25f));
			StartCoroutine(Store_Menu_O(0.34f));
			StartCoroutine(Options_Menu_O(0.4f));			
		}
		
		if(isM_Close){
			isM_Close = false;
			StartCoroutine(Bar_Menu_E(0.01f));
			StartCoroutine(Play_Menu_E(0.21f));
			StartCoroutine(Store_Menu_E(0.40f));
			StartCoroutine(Options_Menu_E(0.3f));
						
		}
		
		
		
	
	}
	
	IEnumerator Bar_Menu_O(float btime_o){
		
		yield return new WaitForSeconds(btime_o);
		bar.audio.PlayOneShot(sound);
		bar.animation.CrossFade("_M_Bar_O", 0.2f);
		TopBar.animation.CrossFade("_Top_Bar_O", 0.2f);
	}
	
	IEnumerator Bar_Menu_E(float btime_o){
		
		yield return new WaitForSeconds(btime_o);
		
		bar.animation.CrossFade("_M_Bar_E", 0.2f);
		TopBar.animation.CrossFade("_Top_Bar_E", 0.2f);
		bar.audio.PlayOneShot(sound);
	}
	
	
	IEnumerator Play_Menu_O(float ptime_O){
		
		yield return new WaitForSeconds(ptime_O);
		
		Play.animation.CrossFade("_M_Play_O", 0.2f);
		Play.audio.PlayOneShot(sound);
	}
	IEnumerator Options_Menu_O(float otime_O){
		
		yield return new WaitForSeconds(otime_O);
		
		Options.animation.CrossFade("_M_Options_O", 0.2f);
		Options.audio.PlayOneShot(sound);
	}
	IEnumerator Store_Menu_O(float stime_O){
		
		yield return new WaitForSeconds(stime_O);
		
		Store.animation.CrossFade("_M_Store_O", 0.2f);
		Store.audio.PlayOneShot(sound);
	}
	
	
	IEnumerator Play_Menu_E(float ptime_e){
		
		yield return new WaitForSeconds(ptime_e);
		
		Play.animation.CrossFade("_M_Play_E", 0.2f);
		Play.audio.PlayOneShot(sound);
	}
	IEnumerator Options_Menu_E(float otime_e){
		
		yield return new WaitForSeconds(otime_e);
		
		Options.animation.CrossFade("_M_Options_E", 0.2f);
		Options.audio.PlayOneShot(sound);
	}
	IEnumerator Store_Menu_E(float stime_e){
		
		yield return new WaitForSeconds(stime_e);
		
		Store.animation.CrossFade("_M_Store_E", 0.2f);
		Store.audio.PlayOneShot(sound);
	}
	
	
}
