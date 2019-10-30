using UnityEngine;
using System.Collections;

public class _SparkHandler : _BaseClass {
	
	public static bool isSpark;
	
	public GameObject Player_L;
	public GameObject Player_R;
	public GameObject Tail_L;
	public GameObject Tail_R;
		
	void Start () {
	
		
		
	}
	
	void Update () {
	
		if(isSpark){
			isSpark = false;
			Player_L.particleEmitter.emit = true;
			Player_R.particleEmitter.emit = true;
			StartCoroutine(Tail_Spark(0.3f));
			
			StartCoroutine(WaitForStop(0.4f));
			
		}
		
	}
	
	IEnumerator Tail_Spark(float sptm){
		
		yield return new WaitForSeconds(sptm);
		
			Tail_L.particleEmitter.emit = true;
			Tail_R.particleEmitter.emit = true;
				
	}
	
	IEnumerator WaitForStop(float stopTm){
		
		yield return new WaitForSeconds(stopTm);
		
		if(!isOver){
			Player_L.particleEmitter.emit = false;
			Player_R.particleEmitter.emit = false;
		
			Tail_L.particleEmitter.emit = false;
			Tail_R.particleEmitter.emit = false;
		}
	}
}
