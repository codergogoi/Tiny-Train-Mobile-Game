using UnityEngine;
using System.Collections;

public class Trigger : _BaseClass {
	
 	public GameObject LeftSwipe;
	public GameObject RightSwipe;
	public GameObject StraightSwipe;
	public GameObject GoodLuck; // end tutorial disable forever
	
	
	public float RotationSpeed;
	private bool isControll;
	private float scoreTime;
	
	private bool isAutoDrive;
	
	public float LeftTurnSpeed;
	public float RightTurnSpeed;
	private bool isLeft;
	private bool isRight;
	private Vector3 newpos;
	
	public GUITexture LeftJump;
	public GUITexture RightJump;
	private RaycastHit hit;
	
		
	//New Road Instantiate
	public GameObject Road_0;
	public GameObject Road_1;
	public GameObject Road_2;
	public GameObject Road_3;
	public GameObject Road_4;
	public GameObject Road_5;
	public GameObject Road_6;
	public GameObject Road_7;
	public GameObject Road_8;
	public GameObject Road_9;
	public GameObject Road_10;
	public GameObject Road_11;
	public GameObject Road_12;
	public GameObject Road_13;
	public GameObject Road_14;
	public GameObject Road_15;
	public GameObject Road_16;
	public GameObject Road_17;
	public GameObject Road_18;
	public GameObject Road_19;
	
	
	public GameObject Inst_Point;
	private GameObject TempGo,GO;
	private int rand;
	
	private bool isLock;
	
	public GameObject N_Eng_; //normal engine
	public GameObject S_Eng_; //super engine
	public GameObject G_Eng_; // Ghost engine
	public AudioClip CoinsCollect;
	public AudioClip CollideSound;
	private bool isHit;
	
	void Start () {
		
		isControll = true;
		isHit = true;
		Inst_Point = GameObject.Find("Inst_Point");
				
	}
	
	
	void Update () {
		
		switch(E_Index){
			
		case 0:
				N_Eng_.SetActiveRecursively(true);
				S_Eng_.SetActiveRecursively(false);
				G_Eng_.SetActiveRecursively(false);
			break;
		case 1: // super engine
				N_Eng_.SetActiveRecursively(false);
				S_Eng_.SetActiveRecursively(true);
				G_Eng_.SetActiveRecursively(false);
			break;
		case 2: // ghost engine
				N_Eng_.SetActiveRecursively(false);
				S_Eng_.SetActiveRecursively(false);
				G_Eng_.SetActiveRecursively(true);
			break;
		}
		
		
		
				
		if(Input.GetKeyDown("space")){
			
			SendMessage("JumpAction",2);
			
		}
	
		if(isS_Engine){
		
			Vector3 Left = transform.TransformDirection (Vector3.left);
			
			Vector3 Right = transform.TransformDirection (Vector3.right);
			
			if (Physics.Raycast (transform.position,Left,out hit,200)) {
					
					Debug.DrawLine(transform.position,hit.point,Color.red);	
					
					if(hit.collider.tag=="jems"){
					
						Destroy(hit.collider.gameObject);
						if(audio.pitch < 2.5)
							audio.pitch += 0.1f;
						else
							audio.pitch = 1.0f;
						
						audio.PlayOneShot(CoinsCollect);
						
						if(is4XCoin) // coins multiplier 4x
							tempgold += Random.Range(4,8);
						else if(is2XCoin) // multiplier 2x
							tempgold += Random.Range(2,6);
						else // default coins value
							tempgold += Random.Range(1,3);
						
						
					
				}
			}
			
				if (Physics.Raycast (transform.position,Right,out hit,200)) {
					
					Debug.DrawLine(transform.position,hit.point,Color.red);
				
					if(hit.collider.tag=="jems"){
						
							Destroy(hit.collider.gameObject);
							if(audio.pitch < 2.5)
								audio.pitch += 0.1f;
							else
								audio.pitch = 1.0f;
							
							audio.PlayOneShot(CoinsCollect);
							
							if(is4XCoin) // coins multiplier 4x
								tempgold += Random.Range(4,8);
							else if(is2XCoin) // multiplier 2x
								tempgold += Random.Range(2,6);
							else // default coins value
								tempgold += Random.Range(1,3);
							
							
						
					}
			}
			
			
			
		}
	
				
		/*
		if(Input.GetMouseButtonDown(0)){
			
			Vector3 pos = Input.mousePosition;
			
			SendMessage("JumpAction",2);
			
			if(LeftJump.HitTest(pos)){
				
				StartCoroutine(LeftCommand(0.02f));
			}
			
			if(RightJump.HitTest(pos)){
				
				StartCoroutine(RightCommand(0.02f));
			}
						
		}
		*/
		
		
		
		if(isControll){
			

			if(Input.GetKeyDown("a")){
				
				
					
					SendMessage("JumpAction",2);
					StartCoroutine(LeftCommand(0.02f));
		
				
			}
			if(Input.GetKeyDown("s")){
				
				
				SendMessage("JumpAction",2);
				StartCoroutine(RightCommand(0.02f));
				
			}
			
		
			
			if(isLeft){
				transform.Translate(Vector3.left * LeftTurnSpeed * Time.deltaTime , Space.World);
				
				 
			}else if(isRight){
				
				transform.Translate(Vector3.right * RightTurnSpeed * Time.deltaTime , Space.World);
			}
					
		}
		
		if(!isOver && Time.timeScale == 1){
		
			scoreTime += (Time.deltaTime * 0.2f);
			
			score += (int)scoreTime;
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
	
	
	void RandomRoad(){
		
		
		rand = Random.Range(0,19);
		
	//	print(rand);
		
		switch(rand){
			
			case 0:
				GO = Road_0;
				break;
			case 1:
				GO = Road_1;
				break;
			case 2:
				GO = Road_2;
				break;
			case 3:
				GO = Road_3;
				break;
			case 4:
				GO = Road_4;
				break;
			case 5:
				GO = Road_5;
				break;
			case 6:
				GO = Road_6;
				break;
			case 7:
				GO = Road_7;
				break;
			case 8:
				GO = Road_8;
				break;
			case 9:
				GO = Road_9;
				break;
			case 10:
				GO = Road_10;
				break;
			case 11:
				GO = Road_11;
				break;
			case 12:
				GO = Road_12;
				break;
			case 13:
				GO = Road_13;
				break;
			case 14:
				GO = Road_14;
				break;
			case 15:
				GO = Road_15;
				break;
			case 16:
				GO = Road_16;
				break;
			case 17:
				GO = Road_17;
				break;
			case 18:
				GO = Road_18;
				break;
			case 19:
				GO = Road_19;
				break;
		}
		
	}
	
	IEnumerator PitchReset(float pitchTime){
		
		yield return new WaitForSeconds(pitchTime);
		
		audio.pitch = 1.0f;
		
	}
	
	void OnTriggerEnter(Collider coll){
	
		
		if(coll.tag=="jems"){
			
			if(audio.pitch < 2.5)
				audio.pitch += 0.1f;
			else
				audio.pitch = 1.0f;
			
			audio.PlayOneShot(CoinsCollect);
			
			if(is4XCoin) // coins multiplier 4x
				tempgold += Random.Range(4,8);
			else if(is2XCoin) // multiplier 2x
				tempgold += Random.Range(2,6);
			else // default coins value
				tempgold += Random.Range(1,3);
			
			StartCoroutine(PitchReset(2.5f));
		}
		
		if(coll.tag=="lt_inst"){
			
			RandomRoad();
			Inst_Point = GameObject.Find("Inst_Point");
			TempGo = Instantiate(GO,Inst_Point.transform.position,Quaternion.identity) as GameObject;
			coll.gameObject.GetComponent<_Self_Destruction>().isDeath = true;
			Destroy(Inst_Point,0.5f);
		}
		
		if(coll.tag=="tckey"){
			isControll = true;
			Destroy(coll.gameObject);
		}
			
		
		
		if(coll.tag=="path"){
			
			_SparkHandler.isSpark = true;
			transform.position = new Vector3(coll.gameObject.transform.position.x,transform.position.y,transform.position.z);

		}
		
		
		
		if(coll.tag=="ls" && isHelp){
			
			Instantiate(LeftSwipe);
					
			
		}else if(coll.tag=="rs" && isHelp){
			
			Instantiate(RightSwipe);
		
			
		}else if(coll.tag=="ss" && isHelp){
			
			Instantiate(StraightSwipe);
				
		}else if(coll.tag=="gl" && isHelp){
			
			Instantiate(GoodLuck);
			isHelp = false;
			PlayerPrefs.SetInt("HelpIndex", 10);
		}
		
	
	}
	
	
	
	
	
	void OnControllerColliderHit(ControllerColliderHit colide){
		
		isLock = true;
	
		
		if(colide.gameObject.tag=="DeathColl" || colide.gameObject.tag == "_stonebase"){
			
			isOver = true;
			
			if(isLock){
				_GameOverMenu.isGO = true;
				//instantiate Restriction Menu
			}else{
				
				_GameOverMenu.isGO = true;
			}
			
			
			
			Destroy(gameObject, 0.3f);
			
		}
		
		
		
		if(colide.gameObject.tag=="O_b_1" && isHit){
			
			isHit = false;
			
			
			if(isMegaHealth){
				
				Destroy(colide.gameObject);
				
			}else if(Health > 0){
				
				Destroy(colide.gameObject);
				Health -=1;
			
			}else{
					
					Destroy(colide.gameObject);
					SendMessage("JumpAction",2);
					StartCoroutine(LeftCommand(0.02f));
				
			}
			
			audio.pitch = 1.0f;
			audio.PlayOneShot(CollideSound);
			
			
			StartCoroutine(HitInitilize(0.4f));
			
					
		}
		if(colide.gameObject.tag=="O_b_2" && isHit){
			
			isHit = false;
			
			
			if(isMegaHealth){
				
				Destroy(colide.gameObject);
				
			}else if(Health > 0){
				
				Destroy(colide.gameObject);
				Health -=1;
			
			}else{
					
					Destroy(colide.gameObject);
					SendMessage("JumpAction",2);
					StartCoroutine(LeftCommand(0.02f));
				
			}
			
			audio.pitch = 1.0f;
			audio.PlayOneShot(CollideSound);
			
			
			StartCoroutine(HitInitilize(0.4f));
			
					
		}
		if(colide.gameObject.tag=="O_b_3" && isHit){
			
			isHit = false;
			
			
			if(isMegaHealth){
				
				Destroy(colide.gameObject);
				
			}else if(Health > 0){
				
				Destroy(colide.gameObject);
				Health -=1;
			
			}else{
					
					Destroy(colide.gameObject);
					SendMessage("JumpAction",2);
					StartCoroutine(LeftCommand(0.02f));
				
			}
			
			audio.pitch = 1.0f;
			audio.PlayOneShot(CollideSound);
			
			
			StartCoroutine(HitInitilize(0.4f));
			
					
		}
		if(colide.gameObject.tag=="W_b_1" && isHit){
			
			isHit = false;
			
			
			if(isMegaHealth){
				
				Destroy(colide.gameObject);
				
			}else if(Health > 0){
				
				Destroy(colide.gameObject);
				Health -=1;
			
			}else{
					
					Destroy(colide.gameObject);
					SendMessage("JumpAction",2);
					StartCoroutine(LeftCommand(0.02f));
				
			}
			
			audio.pitch = 1.0f;
			audio.PlayOneShot(CollideSound);
			
			
			StartCoroutine(HitInitilize(0.4f));
					
		}
		if(colide.gameObject.tag=="W_b_2" && isHit){
			
			isHit = false;
			
			
			if(isMegaHealth){
				
				Destroy(colide.gameObject);
				
			}else if(Health > 0){
				
				Destroy(colide.gameObject);
				Health -=1;
			
			}else{
					
					Destroy(colide.gameObject);
					SendMessage("JumpAction",2);
					StartCoroutine(LeftCommand(0.02f));
				
			}
			
			audio.pitch = 1.0f;
			audio.PlayOneShot(CollideSound);
			
			
			StartCoroutine(HitInitilize(0.4f));
			
					
		}
		if(colide.gameObject.tag=="W_b_3" && isHit){
			
			isHit = false;
			
			
			if(isMegaHealth){
				
				Destroy(colide.gameObject);
				
			}else if(Health > 0){
				
				Destroy(colide.gameObject);
				Health -=1;
			
			}else{
					
					Destroy(colide.gameObject);
					SendMessage("JumpAction",2);
					StartCoroutine(LeftCommand(0.02f));
				
			}
			
			audio.pitch = 1.0f;
			audio.PlayOneShot(CollideSound);
			
			
			StartCoroutine(HitInitilize(0.4f));
			
					
		}
		if(colide.gameObject.tag=="W_x_4" && isHit){
			
			isHit = false;
			
			
			if(isMegaHealth){
				
				Destroy(colide.gameObject);
				
			}else if(Health > 0){
				
				Destroy(colide.gameObject);
				Health -=1;
			
			}else{
					
					Destroy(colide.gameObject);
					SendMessage("JumpAction",2);
					StartCoroutine(LeftCommand(0.02f));
				
			}
			
			audio.pitch = 1.0f;
			audio.PlayOneShot(CollideSound);
			
			
			StartCoroutine(HitInitilize(0.4f));
			
					
		}
		if(colide.gameObject.tag=="W_x_5" && isHit){
			
			isHit = false;
			
			
			if(isMegaHealth){
				
				Destroy(colide.gameObject);
				
			}else if(Health > 0){
				
				Destroy(colide.gameObject);
				Health -=1;
			
			}else{
					
					Destroy(colide.gameObject);
					SendMessage("JumpAction",2);
					StartCoroutine(LeftCommand(0.02f));
				
			}
			
			audio.pitch = 1.0f;
			audio.PlayOneShot(CollideSound);
			
			
			StartCoroutine(HitInitilize(0.4f));
			
		}
	
		
		
	}
	
	
	
	IEnumerator HitInitilize(float hTime){
		
		yield return new WaitForSeconds(hTime);
		
		isHit = true;
		
	}
	
	
	
	
		
	
}
