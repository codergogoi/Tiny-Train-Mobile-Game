using UnityEngine;
using System.Collections;

public class _PopUpEffect : MonoBehaviour {
	
	private float time;
	private bool isDone; // tutorial Done
	
	// Use this for initialization
	void Start () {
	
			Destroy(gameObject,2.0f);
		
	}
	
	// Update is called once per frame
	void Update () {
	
		
			
		time += Time.deltaTime;
	
		
		
		if(time > 0.5f){
			if(transform.tag=="st")
				transform.localScale= new Vector3(0.01f,0.07f,0);
			else
				transform.localScale= new Vector3(0.07f,0.01f,0);
			time = 0;
			StartCoroutine(WaitForNormal(0.2f));
		}
		
				
		
	
				
	}
	
	IEnumerator WaitForNormal(float tm){
		
		yield return new WaitForSeconds(tm);
		
		transform.localScale=new Vector3(0,0,0);
		
		
	}
	
}
