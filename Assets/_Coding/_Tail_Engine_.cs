using UnityEngine;
using System.Collections;

public class _Tail_Engine_ : _BaseClass {
	
	public GameObject S_Eng_;
	public GameObject G_Eng_;
	// Use this for initialization
	void Start () {
		
		switch(E_Index){
			
		case 0:
				S_Eng_.SetActiveRecursively(false);
				G_Eng_.SetActiveRecursively(false);
			break;
		case 1:
				S_Eng_.SetActiveRecursively(true);
				G_Eng_.SetActiveRecursively(false);
			break;
		case 2:
				S_Eng_.SetActiveRecursively(false);
				G_Eng_.SetActiveRecursively(true);
			break;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
