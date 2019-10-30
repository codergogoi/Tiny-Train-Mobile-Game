using UnityEngine;
using System.Collections;

public class _destroyCommand : _BaseClass {
	
	public bool isDeath;
	
	void Start () {
	
	}
	
	
	void Update () {
	
		if(isDeath && Time.timeScale > 0.9f){
			isDeath = false;
			StartCoroutine(WaitForDeath(18.0f));
		}
	}
	

	
	IEnumerator WaitForDeath(float dtime){
		
		yield return new WaitForSeconds(dtime);	
		if(!isOver && Time.timeScale > 0.9f)
			Destroy(gameObject);
	}
	
}
