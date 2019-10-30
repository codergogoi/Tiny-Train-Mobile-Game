using UnityEngine;
using System.Collections;

public class _StoreMenu : _BaseClass {
	
	public AudioClip sound;
	
	public GameObject Store;
	public GameObject bar;
	
	public bool isS_Open;
	public static bool isS_Close;
	
	// Use this for initialization
	void Start () {
		
		if(isMusic){
				audio.Play();
			
		}else{
			
				audio.Stop();
			
		}
		

		
		
		StartCoroutine(SMenu(0.3f));
		
	}
	
	IEnumerator SMenu(float smtime){
		
		yield return new WaitForSeconds(smtime);
		
		isS_Open = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(isS_Open){
			isS_Open = false;
			StartCoroutine(Bar_Menu_O(0.01f));
			StartCoroutine(Store_Menu_O(0.29f));		
		}
		
		if(isS_Close){
			isS_Close = false;
			StartCoroutine(Bar_Menu_E(0.005f));
			StartCoroutine(Store_Menu_E(0.2f));
								
		}
		
		
	
	}
	
	IEnumerator Bar_Menu_O(float btime_o){
		
		yield return new WaitForSeconds(btime_o);
		
		bar.animation.CrossFade("_S_Top_Bar_O", 0.2f);
		bar.audio.PlayOneShot(sound);
	}
	
	IEnumerator Bar_Menu_E(float btime_o){
		
		yield return new WaitForSeconds(btime_o);
		
		bar.animation.CrossFade("_S_Top_Bar_E", 0.2f);
		bar.audio.PlayOneShot(sound);
	}
	
	IEnumerator Store_Menu_O(float stime_O){
		
		yield return new WaitForSeconds(stime_O);
		
		Store.animation.CrossFade("_S_Store_O", 0.2f);
		Store.audio.PlayOneShot(sound);
	}
	
	IEnumerator Store_Menu_E(float stime_e){
		
		yield return new WaitForSeconds(stime_e);
		
		Store.animation.CrossFade("_S_Store_E", 0.2f);
		Store.audio.PlayOneShot(sound);
	}
	
	
}
