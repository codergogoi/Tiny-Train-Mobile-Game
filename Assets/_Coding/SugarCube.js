#pragma strict

var IsSugarTouchedByUser:boolean=false;

private var OldPos:Vector3;
private var FinalPos:Vector3;
private var time:float;
private var time2:float;
public var isTrue : boolean;

function Start()
{

time=0;
time2=0;

OldPos=transform.position;
FinalPos = Camera.main.ScreenToWorldPoint (Vector3 (Screen.width/10-20,Screen.height-50,camera.main.nearClipPlane+12));

}

function FixedUpdate()
{

	if(Input.GetMouseButtonDown(0)){
		
		isTrue = true;
	
	}

	if(isTrue)
	{
		//isTrue = false;
		
		var c:float=0.15;
		
		if(transform.localScale.x<0.4)
		transform.localScale+=Vector3(Time.deltaTime*c,Time.deltaTime*c,Time.deltaTime*c);
		
		if(transform.eulerAngles.y<=360)
		transform.eulerAngles.y+=(Time.deltaTime*170);
		
		
		transform.position=Vector3.Lerp(OldPos,FinalPos,time);
		
		if(time>1)
		Destroy(gameObject);
		
	time+=Time.deltaTime*1.3;
	//print("time");	
   }


		
		if(time2>8 && !IsSugarTouchedByUser)
		Destroy(gameObject);

	time2+=Time.deltaTime;		
}
