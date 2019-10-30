using UnityEngine;
using System.Collections;

public class VelocityTest : _BaseClass {

		
	private int hitx;
	
	public static bool isSpeed;
	private float deathTime;
	
	// Use this for initialization
	void Start () {
	
		Destroy(gameObject,3.0f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		
	}
	
	
	void OnCollisionEnter(Collision col){
		
		if(col.collider.tag =="_stonebase"){
			
			rigidbody.velocity = transform.TransformDirection(0,70,0);
					
				
			}
						
		}
		
		
		
	}

