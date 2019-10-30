using UnityEngine;
using System.Collections;

public class jumpImplement : MonoBehaviour {
	
	public float Speed;
	
	public bool isControll;
	
	void Start () {
	
	}
	
	void Update () {
	
		if(Input.GetKeyDown("p")){
			
			if(isControll){
				
				transform.Translate(Vector3.right * Speed, Space.World);
				isControll = false;
			}else{
				
				transform.Translate(Vector3.left * Speed, Space.World);
				isControll = true;
			}
			
		}
		
		/*
		if(Input.GetKeyDown("p")){
			
			  //this.transform.position += new Vector3(-1.0f, 0.0f, 0.0f) * Speed;
			  transform.Translate(Vector3.left * Speed, Space.World);
		}
		if(Input.GetKeyDown("o")){
			
			 transform.Translate(Vector3.right* Speed, Space.World);
		}
		*/
		
	}
}
