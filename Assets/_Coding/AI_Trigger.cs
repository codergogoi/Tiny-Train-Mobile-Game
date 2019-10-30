using UnityEngine;
using System.Collections;

public class AI_Trigger : MonoBehaviour {
	
	private RaycastHit hit;
	
	private bool isJump;
	
	// Use this for initialization
	void Start () {
	
		isJump = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(isJump){
		
			Vector3 fwd = transform.TransformDirection (Vector3.forward);
					
			if (Physics.Raycast (transform.position,fwd,out hit,50)) {
				
							
	    		if (hit.collider.gameObject.tag=="block" || hit.collider.gameObject.tag=="AI_Player"){
					
					SendMessage("JumpAction",2);
					
					isJump = false;
					StartCoroutine(JumpDisable(0.9f));
									
				} 
			}
		
		
		
		}
		
	
	}
	
	IEnumerator JumpDisable(float jtime){
		
		
		yield return new WaitForSeconds(jtime);
		
		isJump = true;
		
	}
	
	
	void OnTriggerEnter(Collider coll){
		
		
		
		if(coll.tag=="path"){
			
			
			transform.position = new Vector3(coll.gameObject.transform.position.x,transform.position.y,transform.position.z);
			
		}
		
		
	}
	
	
}