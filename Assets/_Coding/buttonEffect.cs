using UnityEngine;
using System.Collections;

public class buttonEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void Update () 
	{
		
		if(Time.timeScale > 0)
		{
	
			transform.localScale=new Vector3(0,0,0);
	
		
			if(guiTexture.HitTest(Input.mousePosition) ) 
			{

				transform.localScale= new Vector3(0.01f,0.01f,0);
				
				
			}
		}
	}
	
}