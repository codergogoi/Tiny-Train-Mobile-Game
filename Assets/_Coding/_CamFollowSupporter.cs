using UnityEngine;
using System.Collections;

public class _CamFollowSupporter : _BaseClass {

	
	
	public Transform target;
    public float smooth = 0.3F;
    public float distance = 5.0F;
    public float height = 5.0F;
	private float yVelocity = 0.0F;
	
	
	
	void Update () {
		
		
		if(!isOver){
		
			float yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref yVelocity, smooth);
			
	       Vector3 position = new Vector3(target.position.x,0,target.position.z);
			
	        
			position += Quaternion.Euler(0, yAngle, 0) * new Vector3(0, height, -distance);
	        
			transform.position = position;
			
	        transform.LookAt(target);
		
		}//else{
			
			//Destroy(gameObject);
		//}
		
    }
}