using UnityEngine;
using System.Collections;

public class _Engine_Used : _BaseClass {

	// Use this for initialization
	void Start () {
		
		if(isG_Engine || isS_Engine){
			
			switch(E_Index){
				
			case 1:
				transform.collider.isTrigger = true;
				break;
			case 2:
				transform.collider.isTrigger = true;
				break;
				
			}
			
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
