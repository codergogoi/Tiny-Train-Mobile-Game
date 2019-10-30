var speed : float = 3.0;
var gravity : float = 20.0;
var rotateSpeed : float = 3.0;
var jumpSpeed : float = 8.0;
private var moveDirection : Vector3 = Vector3.zero;

function Update () {
    var controller : CharacterController = GetComponent(CharacterController);
if(controller.isGrounded){   
transform.Rotate(0,0,Input.GetAxis ("Horizontal") * rotateSpeed);

//transform.Rotate(0,0,Input.GetAxis ("Vertical") * -rotateSpeed);



var forward : Vector3 = transform.TransformDirection(Vector3.left);
var curSpeed : float = speed * Input.GetAxis ("Vertical");

 if (Input.GetButton ("Jump")) 
 {transform.Translate(Vector3.forward * jumpSpeed * Time.deltaTime);}

}

moveDirection.y -= gravity * Time.deltaTime;
controller.SimpleMove(forward * curSpeed);

}

@script RequireComponent(CharacterController)
