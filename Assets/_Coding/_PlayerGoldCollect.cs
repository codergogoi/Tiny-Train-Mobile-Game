using UnityEngine;
using System.Collections;

public class _PlayerGoldCollect : MonoBehaviour {
	
	
	private Ray ray;
	private RaycastHit hit;
	
	public AudioClip GoldCollectSound;

	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		for ( var i = 0 ; i < Input.touchCount; i++ ){
	     	 	Touch touch = Input.GetTouch(i);
	     
	     
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				
				if(Physics.Raycast(ray, out	 hit, 500)){	
				
				  	  	if(touch.phase == TouchPhase.Began ){
						
							if(hit.collider.tag=="goldStone"){ 
																	
								audio.PlayOneShot(GoldCollectSound);
								Destroy(hit.collider.gameObject);
						
							}
						
						
						}
			
				}
			
			}
	
	}
}
