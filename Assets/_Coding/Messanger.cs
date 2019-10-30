using UnityEngine;
using System.Collections;

public class Messanger : _BaseClass {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void PID (int x){
		
		switch(x){
			
		case 1: //_cbuy1
			gold+= 50000;
			break;
		case 2: //_cbuy2
			gold+= 900000;
			break;
			
		}
		
		
	}
}
