using UnityEngine;
using System.Collections;

public class _SwipeControl : MonoBehaviour {

		Vector2 deltaPosition;
        Vector2 afterDeltaPosition;
        float angle;
		public float speed;
	
		public GUIText Log;
	
		public float LeftTurnSpeed;
		public float RightTurnSpeed;
		private bool isLeft;
		private bool isRight;
		

        void FixedUpdate()
        {
			
		
            if(Input.touchCount > 0 &&  Input.touches[0].phase == TouchPhase.Moved)
            { 
                //its always x=-1 and y=-1 if touchCount == 0 Resets
                if(deltaPosition.x == -1 && deltaPosition.y == -1)
                    deltaPosition = Input.GetTouch(0).position; //First touch  point stored
                afterDeltaPosition = Input.GetTouch(0).position;//the swiping points
                angle = Mathf.Atan2(afterDeltaPosition.y-deltaPosition.y,afterDeltaPosition.x -deltaPosition.x)* 180/Mathf.PI ; // angle in degrees from 0,-180 and 0,180)
                //Debug.Log("Angle "+ angle);
                
				if(angle < 45f && angle > -45f)
                {
				
              	SendMessage("JumpAction", 2);
				StartCoroutine(RightCommand(0.02f));
				//Log.text ="Right";
				//if(anim.isPlaying() && anim.CurrentClip.name != "right")
                //{
                //anim.Play("right"); 
				
                rigidbody.velocity = (Vector3.right * speed);
            //}
        }
        else if(angle < 135f && angle > 45f)
        {
            /*if(anim.isPlaying() && anim.CurrentClip.name != "front")
            {
					Log.text ="Back";
                //anim.Play("back"); 
                rigidbody.velocity = (Vector3.up * speed);
            }*/
				SendMessage("JumpAction", 2);
				//Log.text ="up";
                //anim.Play("back"); 
                rigidbody.velocity = (Vector3.up * speed);
        }
        else if(angle > 135f || angle < -135f)
        {
				/*
            if(anim.isPlaying() && anim.CurrentClip.name != "left")
            {
				
                //anim.Play("left"); 
                rigidbody.velocity = (Vector3.left * speed); 
            }*/
				SendMessage("JumpAction", 2);
				StartCoroutine(LeftCommand(0.02f));
	
				rigidbody.velocity = (Vector3.left * speed); 
				
        }
        else if(angle > -135f && angle < -45f)
        {
            /*if(anim.isPlaying() && anim.CurrentClip.name != "front")
            {
				
               // anim.Play("front"); 
                rigidbody.velocity = (Vector3.down * speed);
            }*/
			//SendMessage("JumpAction", 1);
			//Log.text ="down";
			rigidbody.velocity = (Vector3.down * speed);
        }
    }
    else if( Input.touchCount == 0)
    {
        if(deltaPosition.x != -1 && deltaPosition.y != -1)
        {
            deltaPosition.x=-1;
            deltaPosition.y=-1;
        }
	}
		
	}
	
	
	void Update(){
		
		
			if(isLeft){
			
				transform.Translate(Vector3.left * LeftTurnSpeed * Time.deltaTime , Space.World);
				
				 
			}else if(isRight){
				
				transform.Translate(Vector3.right * RightTurnSpeed * Time.deltaTime , Space.World);
			}
		
		
	}
	
	
	
	IEnumerator LeftCommand(float lctime){
		
		yield return new WaitForSeconds(lctime);
		
		isLeft = true;
		StartCoroutine(WaitForLeft(0.20f)); //0.47
		
	}
	
	IEnumerator RightCommand(float rctime){
		
		yield return new WaitForSeconds(rctime);
		isRight = true;
		StartCoroutine(WaitForRight(0.20f));
	}
	
	
	
	IEnumerator WaitForLeft(float lTime){
		
		
		yield return new WaitForSeconds(lTime);
		
		isLeft = false;
		
	}
	
	IEnumerator WaitForRight(float rTime){
		
		
		yield return new WaitForSeconds(rTime);
		
		isRight = false;
		
	}
	
}