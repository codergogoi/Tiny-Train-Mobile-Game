using UnityEngine;
using System.Collections;

public class _SMS_Popup : MonoBehaviour {
	
	public static bool isSMSOn;
	public AudioClip Message_Sound;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(isSMSOn){
			
			isSMSOn = false;
			
			audio.PlayOneShot(Message_Sound);
			
		}
	
	}
}
