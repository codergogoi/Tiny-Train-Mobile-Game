
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
public var LeftTurnSpeed : float;
public var RightTurnSpeed : float;

public var JumpSound : AudioClip;

 
// main function:
function Update()
{
	
    if (Input.touchCount > 0 && Time.timeScale > 0.9f)
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
				                            
				                          
				                            	
				                            	StartCoroutine(RightCommand(0.02f));
				                            	audio.PlayOneShot(JumpSound);
				                            	SendMessage("JumpAction",2);
												

				                            
				                            }else{
				                            	
				                            
				                            	
												SendMessage("JumpAction",2);
												StartCoroutine(LeftCommand(0.02f));
												audio.PlayOneShot(JumpSound);
				                            
				                            }
				                            
				                            
				                        }else {
				                            // the swipe is vertical:
				                            swipeType = Vector2.up * Mathf.Sign(direction.y);
				                            
				                             if(swipeType.y > 0){
				                            
				                            	
				                      
												SendMessage("JumpAction",2);
												audio.PlayOneShot(JumpSound);
				                            }else{
				                            
				                            	//log.text = "Down"+swipeType;

				                            
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

			 transform.Translate(Vector3.left * LeftTurnSpeed * Time.deltaTime , Space.World);
				
				 
			}else if(isRight){
				//				train.transform.Translate(Vector3.right * RightTurnSpeed * Time.deltaTime , Space.World);

				transform.Translate(Vector3.right * RightTurnSpeed * Time.deltaTime , Space.World);
			}
        
 }
 
 
 //movements
 

function LeftCommand(lctime : float ){
		
		yield WaitForSeconds(lctime);
		
		isLeft = true;
		StartCoroutine(WaitForLeft(0.10f)); //0.47
		
	}
	
function RightCommand(rctime : float){
		
		yield WaitForSeconds(rctime);
		isRight = true;
		StartCoroutine(WaitForRight(0.10f));
	}
	

function WaitForLeft(lTime : float){
		
		
		yield WaitForSeconds(lTime);
		
		isLeft = false;
		
	}
	
function WaitForRight(rTime : float){
		
		
		yield WaitForSeconds(rTime);
		
		isRight = false;
		
	}
 
    


