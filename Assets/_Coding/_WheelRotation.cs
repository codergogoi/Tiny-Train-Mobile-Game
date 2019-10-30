using UnityEngine;
using System.Collections;

public class _WheelRotation : _BaseClass {
	
	
	private float tm;
	
	public float speed;
	public GameObject WheelR;
	public GameObject WheelL;

	void Start () {
	
	}
	
	void Update () {
		
		if(isOver){
			
			Destroy(gameObject);
		}
		
		if(Time.timeScale == 1){
		
			tm += Time.deltaTime * speed;
			
			WheelR.transform.eulerAngles = new Vector3(tm,0,0);
			WheelL.transform.eulerAngles = new Vector3(tm,0,180);
		}
	}
}
