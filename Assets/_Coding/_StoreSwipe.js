
/* this variable is used to make use of the swipe. Once a swipe is detected
 * a function called Swipe(swipeType : Vector2) is called
 */

//var controller : PlayerController;

// variables:
//var log :GUIText;
private var fingerStartTime : float   = 0.0;
private var fingerStartPos  : Vector2 = Vector2.zero;
 
private var isSwipe         : boolean = false;
private var minSwipeDist    : float   = 50.0;
private var maxSwipeTime    : float   = 0.5;


private var isLeft : boolean;
private var isRight : boolean;
public var SwipeSound : AudioClip;

function Start(){
}
 
// main function:
function Update()
{
	
    if (Input.touchCount > 0)
    {
        for (var touch : Touch in Input.touches)
        {
            switch (touch.phase)
            {
            
	                case TouchPhase.Began:
	                    /* this is a new touch */
	                    isSwipe = true;
	                    fingerStartTime = Time.time;
	                    fingerStartPos = touch.position;
	                    break;
	
	                case TouchPhase.Canceled :
	                    /* The touch is being canceled */
	                    isSwipe = false;
	                    break;
	
	                case TouchPhase.Ended :
	                
	                
			                    var gestureTime : float = Time.time - fingerStartTime;
			                    var gestureDist : float = (touch.position - fingerStartPos).magnitude;
			                    
			                    if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist) {
				                        
				                        var direction : Vector2 = touch.position - fingerStartPos;
				                        var swipeType : Vector2 = Vector2.zero;
				                        
				                      if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
				                            // the swipe is horizontal:
				                            swipeType = Vector2.right * Mathf.Sign(direction.x);
				                            
				                            if(swipeType.x > 0){
				                            	
				                          	
												SendMessage("GetMessage", 2);
												audio.PlayOneShot(SwipeSound);
												//right

				                            
				                            }else{
				                            	
												//left
				                            	SendMessage("GetMessage", 3);
				                            	audio.PlayOneShot(SwipeSound);
				                            	
				                            
				                            }
				                            
				                            
				                        }
				                       // controller.Swipe(swipeType);
			                    }
	
	                    break;
                }
            }
        }
        
        
        //train movement
        	
        	if(isLeft){
			//			 train.transform.Translate(Vector3.left * LeftTurnSpeed * Time.deltaTime , Space.World);

				
				 
			}else if(isRight){
				//				train.transform.Translate(Vector3.right * RightTurnSpeed * Time.deltaTime , Space.World);

			}
        
 }
 
 
 //movements
 


function WaitForLeft(lTime : float){
		
		
		yield WaitForSeconds(lTime);
		
		isLeft = false;
		
	}
	
function WaitForRight(rTime : float){
		
		
		yield WaitForSeconds(rTime);
		
		isRight = false;
		
	}
 
    


