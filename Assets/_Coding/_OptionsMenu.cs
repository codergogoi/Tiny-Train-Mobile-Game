using UnityEngine;
using System.Collections;

public class _OptionsMenu : MonoBehaviour {
	
	public AudioClip sound;
	
	public GameObject Store;
	public GameObject bar;
	
	public bool isS_Open;
	public static bool isS_Close;
	
	public GameObject OB1;
	public GameObject OB2;
	public GameObject OB3;
	public GameObject OB4;
	public GameObject OB5;
	public GameObject OB6;
	public GameObject OB7;
	public GameObject OB8;
	public GameObject OB9;
	public GameObject OB10;
	
	public Texture2D[] starImg;
	
	private int obj1,obj2,obj3,obj4,obj5,obj6,obj7,obj8,obj9,obj10;
	
	
	
	// Use this for initialization
	void Start () {
		
		StartCoroutine(SMenu(0.3f));
		obj1 = PlayerPrefs.GetInt("obj1");
		obj2 = PlayerPrefs.GetInt("obj2");
		obj3 = PlayerPrefs.GetInt("obj3");
		obj4 = PlayerPrefs.GetInt("obj4");
		obj5 = PlayerPrefs.GetInt("obj5");
		obj6 = PlayerPrefs.GetInt("obj6");
		obj7 = PlayerPrefs.GetInt("obj7");
		obj8 = PlayerPrefs.GetInt("obj8");
		obj9 = PlayerPrefs.GetInt("obj9");
		obj10 = PlayerPrefs.GetInt("obj10");
		CheckRating();
		
		//print(obj1+""+obj2+""+obj3+""+obj4+""+obj5+""+obj6+""+obj7+""+obj8+""+obj9+""+obj10);
	}
	
	IEnumerator SMenu(float smtime){
		
		yield return new WaitForSeconds(smtime);
		
		isS_Open = true;
	}
	
	void CheckRating(){
		
		switch(obj1){
			
		case 0:
			OB1.renderer.material.mainTexture = starImg[0];
			break;
		case 1:
			OB1.renderer.material.mainTexture = starImg[1];
			break;
		case 2:
			OB1.renderer.material.mainTexture = starImg[2];
			break;
		case 3:
			OB1.renderer.material.mainTexture = starImg[3];
			print("Here");
			break;
			
		}
		
		switch(obj2){
			
		case 0:
			OB2.renderer.material.mainTexture = starImg[0];
			break;
		case 1:
			OB2.renderer.material.mainTexture = starImg[1];
			break;
		case 2:
			OB2.renderer.material.mainTexture = starImg[2];
			break;
		case 3:
			OB2.renderer.material.mainTexture = starImg[3];
			break;
			
		}
		
		switch(obj3){
			
		case 0:
			OB3.renderer.material.mainTexture = starImg[0];
			break;
		case 1:
			OB3.renderer.material.mainTexture = starImg[1];
			break;
		case 2:
			OB3.renderer.material.mainTexture = starImg[2];
			break;
		case 3:
			OB3.renderer.material.mainTexture = starImg[3];
			break;
			
		}
		
		switch(obj4){
			
		case 0:
			OB4.renderer.material.mainTexture = starImg[0];
			break;
		case 1:
			OB4.renderer.material.mainTexture = starImg[1];
			break;
		case 2:
			OB4.renderer.material.mainTexture = starImg[2];
			break;
		case 3:
			OB4.renderer.material.mainTexture = starImg[3];
			break;
			
		}
		
		switch(obj5){
			
		case 0:
			OB5.renderer.material.mainTexture = starImg[0];
			break;
		case 1:
			OB5.renderer.material.mainTexture = starImg[1];
			break;
		case 2:
			OB5.renderer.material.mainTexture = starImg[2];
			break;
		case 3:
			OB5.renderer.material.mainTexture = starImg[3];
			break;
			
		}
		
		switch(obj6){
			
		case 0:
			OB6.renderer.material.mainTexture = starImg[0];
			break;
		case 1:
			OB6.renderer.material.mainTexture = starImg[1];
			break;
		case 2:
			OB6.renderer.material.mainTexture = starImg[2];
			break;
		case 3:
			OB6.renderer.material.mainTexture = starImg[3];
			break;
			
		}
		
		switch(obj7){
			
		case 0:
			OB7.renderer.material.mainTexture = starImg[0];
			break;
		case 1:
			OB7.renderer.material.mainTexture = starImg[1];
			break;
		case 2:
			OB7.renderer.material.mainTexture = starImg[2];
			break;
		case 3:
			OB7.renderer.material.mainTexture = starImg[3];
			break;
			
		}
		
		switch(obj8){
			
		case 0:
			OB8.renderer.material.mainTexture = starImg[0];
			break;
		case 1:
			OB8.renderer.material.mainTexture = starImg[1];
			break;
		case 2:
			OB8.renderer.material.mainTexture = starImg[2];
			break;
		case 3:
			OB8.renderer.material.mainTexture = starImg[3];
			break;
			
		}
		
		switch(obj9){
			
		case 0:
			OB9.renderer.material.mainTexture = starImg[0];
			break;
		case 1:
			OB9.renderer.material.mainTexture = starImg[1];
			break;
		case 2:
			OB9.renderer.material.mainTexture = starImg[2];
			break;
		case 3:
			OB9.renderer.material.mainTexture = starImg[3];
			break;
			
		}
		
		switch(obj10){
			
		case 0:
			OB10.renderer.material.mainTexture = starImg[0];
			break;
		case 1:
			OB10.renderer.material.mainTexture = starImg[1];
			break;
		case 2:
			OB10.renderer.material.mainTexture = starImg[2];
			break;
		case 3:
			OB10.renderer.material.mainTexture = starImg[3];
			break;
			
		}
		
		
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
