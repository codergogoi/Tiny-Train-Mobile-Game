using UnityEngine;
using System.Collections;

public class _SimpleCoins : _BaseClass {
	
		
	private float tm;
	
	private float speed;
	

	void Start () {
	
		speed = Random.Range(50.0f,100.0f);
	}
	
	void Update () {
		
			
		tm += Time.deltaTime * speed;
		
		transform.eulerAngles = new Vector3(transform.eulerAngles.x,tm,transform.eulerAngles.z);
		
	}
	
	
	void OnTriggerEnter(Collider coll){
		
		
		
		if(coll.tag=="Player"){
			
			Destroy(gameObject,0.08f);
		}
	}
	
	
}
