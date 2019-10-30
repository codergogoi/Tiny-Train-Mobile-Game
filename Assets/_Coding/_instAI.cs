using UnityEngine;
using System.Collections;

public class _instAI : MonoBehaviour {
	
	public GameObject AI_Player;
	
	public GameObject inst_Point;
	private float inst_Time;
	
		
	
	void Start () {
	
	}
	
	
	void Update () {
		
		inst_Time += Time.deltaTime;
		
		if(inst_Time > Random.Range(4f,6f)){
			
			GameObject TempAI = Instantiate(AI_Player, inst_Point.transform.position,inst_Point.transform.rotation) as GameObject;
			inst_Time =0;
		}
	
	}
}
