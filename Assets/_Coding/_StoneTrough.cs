using UnityEngine;
using System.Collections;

public class _StoneTrough : _BaseClass {
	
	
	public GameObject GoldStone;
	public GameObject TroughPoint1;
	public GameObject TroughPoint2;
	private GameObject tempStone;
	
	private bool isStone;
	
	private float ttime;
	
	private int rand;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		if(!isOver && Time.timeScale == 1){
			
				rand = Random.Range(0,3);
				ttime += Time.deltaTime;
				
				if(ttime > 3.0f){
					ttime = 0;
					
					switch(rand){
						
					case 0:
						tempStone = Instantiate(GoldStone,TroughPoint1.transform.position,TroughPoint1.transform.rotation) as GameObject;				
						break;
					case 1:
						tempStone = Instantiate(GoldStone,TroughPoint2.transform.position,TroughPoint2.transform.rotation) as GameObject;
						break;
					default:
						tempStone = Instantiate(GoldStone,TroughPoint1.transform.position,TroughPoint1.transform.rotation) as GameObject;
						break;
						
					}
					
					tempStone.rigidbody.velocity = transform.TransformDirection(Random.Range(0,10),Random.Range(0,10),Random.Range(0,10));
					
					
				
						
				}
		
		}
	}
}
