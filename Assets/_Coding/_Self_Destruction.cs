using UnityEngine;
using System.Collections;

public class _Self_Destruction : MonoBehaviour {
	
	public GameObject MainObj;
	public bool isDeath;

	void Start () {
	
	}

	void Update () {
	
		if(isDeath){
			isDeath = false;
			MainObj.GetComponent<_destroyCommand>().isDeath = true;
			
		}
		
		
	}
	
	
	
}
