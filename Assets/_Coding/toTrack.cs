using UnityEngine;
using System.Collections;

public class toTrack : MonoBehaviour {
	
	private float dtime;
	public float life;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		dtime += Time.deltaTime;
		
		if(dtime >  life){
			

			Destroy(gameObject);
		}
	
	}
}
