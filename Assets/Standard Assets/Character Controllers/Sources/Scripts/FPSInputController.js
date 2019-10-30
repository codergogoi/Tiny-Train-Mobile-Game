/*
var comfortZoneVerticalSwipe: float = 50; // the vertical swipe will have to be inside a 50 pixels horizontal boundary
var comfortZoneHorizontalSwipe: float = 50; // the horizontal swipe will have to be inside a 50 pixels vertical boundary
var minSwipeDistance: float = 14; // the swipe distance will have to be longer than this for it to be considered a swipe

var startPos : Vector3;
var startTime : float;

var moving : boolean;

var maxSwipeTime : float;

private var isLeft : boolean;
private var isRight : boolean;
public var LeftTurnSpeed : float;
public var RightTurnSpeed : float;

*/

private var motor : CharacterMotor;

private var isJump : boolean;

// Use this for initialization
function Awake () {
	motor = GetComponent(CharacterMotor);
}


function JumpAction(x : int){

	if(x > 1){
	
		isJump = true;
	}else{
	
		isJump = false;
	}

}
// Update is called once per frame
function Update () {
	// Get the input vector from kayboard or analog stick
	//var directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	
	//var directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, 1);
	
	var  directionVector : Vector3;
	
	 if(Time.timeScale == 1)
		directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, 1);
	 else
	 	directionVector = new Vector3(0, 0, 0);
	 	
	 	
	if (directionVector != Vector3.zero) {
		// Get the length of the directon vector and then normalize it
		// Dividing by the length is cheaper than normalizing when we already have the length anyway
		var directionLength = directionVector.magnitude;
		directionVector = directionVector / directionLength;
		
		// Make sure the length is no bigger than 1
		directionLength = Mathf.Min(1, directionLength);
		
		// Make the input vector more sensitive towards the extremes and less sensitive in the middle
		// This makes it easier to control slow speeds when using analog sticks
		directionLength = directionLength * directionLength;
		
		// Multiply the normalized direction vector by the modified length
		directionVector = directionVector * directionLength;
	}
	
	// Apply the direction to the CharacterMotor
	motor.inputMoveDirection = transform.rotation * directionVector;
	//motor.inputJump = Input.GetButton("Jump");
	motor.inputJump = isJump;
	
	/*
	//controls
	
	
			if(isLeft){
			//			 train.transform.Translate(Vector3.left * LeftTurnSpeed * Time.deltaTime , Space.World);

			 transform.Translate(Vector3.left * LeftTurnSpeed * Time.deltaTime , Space.World);
				
				 
			}else if(isRight){
				//				train.transform.Translate(Vector3.right * RightTurnSpeed * Time.deltaTime , Space.World);

				transform.Translate(Vector3.right * RightTurnSpeed * Time.deltaTime , Space.World);
			}
	// touches
	if (Input.touchCount >0) {
	var touch = Input.touches[0];
	
	switch (touch.phase) { //following are 2 cases
	case TouchPhase.Began: //here begins the 1st case
	startPos = touch.position;
	startTime = Time.time;
	
	break; //here ends the 1st case
	
	
	
	case TouchPhase.Ended: //here begins the 2nd case
	var swipeTime = Time.time - startTime;
	var swipeDist = (touch.position - startPos).magnitude;
	var endPos = touch.position;
	
	if ((Mathf.Abs(touch.position.x - startPos.x))<comfortZoneVerticalSwipe && (swipeTime < maxSwipeTime) && (swipeDist > minSwipeDistance) && Mathf.Sign(touch.position.y - startPos.y)>0 && !moving)
	{
	//... then go up
	
		JumpAction(2);
		moving=true;
	
	StartCoroutine(DisableMove(0.02));
	}
	
	
	if ((Mathf.Abs(touch.position.x - startPos.x))<comfortZoneVerticalSwipe && (swipeTime < maxSwipeTime) && (swipeDist > minSwipeDistance) && Mathf.Sign(touch.position.y - startPos.y)<0 && !moving)
	{
	//... then go down
	moving=true;
	StartCoroutine(DisableMove(0.05));
	}
	
	
	if ((Mathf.Abs(touch.position.y - startPos.y))<comfortZoneHorizontalSwipe && (swipeTime < maxSwipeTime) && (swipeDist > minSwipeDistance) && Mathf.Sign(touch.position.x - startPos.x)<0 && !moving)
	{
	//... then go left
	moving=true;
	JumpAction(2);
	StartCoroutine(LeftCommand(0.02f));
	StartCoroutine(DisableMove(0.02));
	
	}
	
	if ((Mathf.Abs(touch.position.y - startPos.y))<comfortZoneHorizontalSwipe && (swipeTime < maxSwipeTime) && (swipeDist > minSwipeDistance) && Mathf.Sign(touch.position.x - startPos.x)>0 && !moving)
	{
	//...then go right
	moving=true;
	JumpAction(2);
			StartCoroutine(RightCommand(0.02f));
	StartCoroutine(DisableMove(0.02));
	
	}
	break; //here ends the 2nd case
	
	}

}
	
	
	
}


// components

function DisableMove (waitTime : float) {

        yield WaitForSeconds (waitTime);
		moving = false;
		//log.text = "";


}



function LeftCommand(lctime : float ){
		
		yield WaitForSeconds(lctime);
		
		isLeft = true;
		StartCoroutine(WaitForLeft(0.20f)); //0.47
		
	}
	
function RightCommand(rctime : float){
		
		yield WaitForSeconds(rctime);
		isRight = true;
		StartCoroutine(WaitForRight(0.20f));
	}
	

function WaitForLeft(lTime : float){
		
		
		yield WaitForSeconds(lTime);
		
		isLeft = false;
		
	}
	
function WaitForRight(rTime : float){
		
		
		yield WaitForSeconds(rTime);
		
		isRight = false;
		
	}
*/
// original codes in bellow
}
// Require a character controller to be attached to the same game object
@script RequireComponent (CharacterMotor)
@script AddComponentMenu ("Character/FPS Input Controller")
