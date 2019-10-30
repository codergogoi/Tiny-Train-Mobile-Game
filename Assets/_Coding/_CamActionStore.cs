using UnityEngine;
using System.Collections;

public class _CamActionStore : _BaseClass {
			
	private Ray ray;
	private RaycastHit hit;
	
	public GameObject HealthText;
	
	public GUITexture Back;
	public GUITexture Restore;
	public GameObject CoinsDeposit;
	
	public GameObject HealthBuy;
	public GameObject CoinsBuy;
	public GameObject CoinsXBuy;
	public GameObject EngineBuy;
	
	//details set
	public GameObject HB1_details;
	public GameObject HB2_details;
	public GameObject CB1_details;
	public GameObject CB2_details;
	public GameObject CXB1_details;
	public GameObject CXB2_details;
	public GameObject EB1_details;
	public GameObject EB2_details;
	
	public GameObject _hbuy2;
	public GameObject _cxbuy1;
	public GameObject _cxbuy2;
	public GameObject _engbuy1;
	public GameObject _engbuy2;
	
	
	
	public AudioClip ActionSound;
	
	public Texture2D[] buyimg;
	
	private float width,height;
	
	private int AnimCode = 1;
	private bool isBuy;
	
	//public AudioClip bgmusic;
	
	// Use this for initialization
	void Start () {
		
		width = Screen.width;
		height = Screen.height;
		
		Back.pixelInset = new Rect(0,0, width/4,height/6);
		
		Restore.pixelInset = new Rect(0,0,width/5, height/9);
	
	
	}
	
	// fund 2000
	
	/* 
	 1. 10,000 gram Gold for 5 Strong Engine 
	 	: Strong engine can destroy everything by collide.. it's a great engine to make scores..
	 2. 30,000 Gram Gold for 10 Gost Engine
	 	: Ghost Engine can Go as fast as inside any objects this is a so amaizing engine ever.. buy this engine to make more score 
	 3. 50,000 Grams Gold for 10 Magnet Engine 
	 	: It's a Magnet Field Engine it can destroy all obstracles and collect gold stone and coins autometically.. buy this engine..  
	 	Enjoy a funny train journey
	 
		 
	1. 30,000 gram Gold at $1
	2. 70,000 gram Gold at $1.99
	 	 
	 
	 	 
	 	 	 	 
	 */
	
	
	
	void Update () {
		
		   	CoinsDeposit.GetComponent<TextMesh>().text = ""+gold;
			HealthText.GetComponent<TextMesh>().text = ""+ Health;
			HB1_details.GetComponent<TextMesh>().text = "Protect yourself \nfrom Front Collision..\nSpending 5,000 coins";
			HB2_details.GetComponent<TextMesh>().text = "Protect yourself \nforever from Front \nCollision... does not\nmatter the obstacle \nsize..and quantity.. ";
			CB1_details.GetComponent<TextMesh>().text = "Get coins and use \nother features...";
			CB2_details.GetComponent<TextMesh>().text = "Get Mega coins and \nuse other features...\ndon't worry.. about\nmissed coins.. on \nGame play";
			CXB1_details.GetComponent<TextMesh>().text = "Get Double coins value\nenjoy more funn...";	
			CXB2_details.GetComponent<TextMesh>().text = "4x multiply coins value\nenjoy more funn...";
			EB1_details.GetComponent<TextMesh>().text = "Unlock Challengeing \nnever die Ghost mode \nIt is incredible.. \nrealy great..";
			EB2_details.GetComponent<TextMesh>().text = "Unlock Super Mode.\nfeel your joy\nand funn with game.";

		if(PlayerPrefs.GetInt("M_Health") > 0){
			
			_hbuy2.SetActiveRecursively(false);
		}else{
			
			_hbuy2.SetActiveRecursively(true);
		}
		
		if(PlayerPrefs.GetInt("COIN2X") > 0){
			
			_cxbuy1.SetActiveRecursively(false);
		}else{
			_cxbuy1.SetActiveRecursively(true);
		}
		
		
		if(PlayerPrefs.GetInt("COIN4X") > 0){
			
			_cxbuy2.SetActiveRecursively(false);
		}else{
			_cxbuy2.SetActiveRecursively(true);
		}
		
		if(PlayerPrefs.GetInt("S_ENG") > 0){
			
			_engbuy2.SetActiveRecursively(false);
			
		}else{
			
			_engbuy2.SetActiveRecursively(true);
			
		}
		
		
		if(PlayerPrefs.GetInt("G_ENG") > 0){
			
			_engbuy1.SetActiveRecursively(false);
			
		}else{
			
			_engbuy1.SetActiveRecursively(true);
			
		}
		
		
		
				if(Input.GetMouseButtonDown(0)){
			
			
					Vector3 touchPos = Input.mousePosition;
			
					if(Back.HitTest(touchPos)){
				
						_StoreMenu.isS_Close = true;
						PlayerPrefs.SetInt("Health", Health);
						StartCoroutine(waitlevels(0.9f));
						audio.PlayOneShot(ActionSound);
				
					}
					if(Restore.HitTest(touchPos)){
				
						audio.PlayOneShot(ActionSound);
						StoreKitBinding.restoreCompletedTransactions();
				
				
					}
				
					ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					
				
						if(Physics.Raycast(ray, out	 hit, 500)){
						
				
								if(hit.collider.tag=="_hbuy1"){  // 5000 coins >>
									
									audio.PlayOneShot(ActionSound);
									if(gold > 4999){
									
										Health += 24;
										gold-= 5000;
									}
								
									// Heale += 24;
								}
								if(hit.collider.tag=="_hbuy2"){  // 40,000 coins $0.99
									audio.PlayOneShot(ActionSound);
									if(gold > 39999){
										
										PlayerPrefs.SetInt("M_Health",2); // true
										gold-= 40000;
									}else{
										StoreKitBinding.purchaseProduct( "HMpack", 1 );
						
									}
									
						
									
					
								}
								if(hit.collider.tag=="_cbuy1"){ //$0.99  >> 
									audio.PlayOneShot(ActionSound);
									//gold += 50000;
									StoreKitBinding.purchaseProduct( "CSpack", 1 );
					
								}
								if(hit.collider.tag=="_cbuy2"){  //$1.99 >>
									audio.PlayOneShot(ActionSound);
									//gold+= 900000;
									StoreKitBinding.purchaseProduct( "CMpack", 1 );
					
								}
								if(hit.collider.tag=="_cxbuy1"){  // 50,000 coins   
									audio.PlayOneShot(ActionSound);
									if(gold > 49999){
											PlayerPrefs.SetInt("COIN2X", 2);
											gold-= 50000;
									}
								}
								if(hit.collider.tag=="_cxbuy2"){  //3,00,000 coins $0.99
									audio.PlayOneShot(ActionSound);
									if(gold > 299999){
										gold -= 300000;
										PlayerPrefs.SetInt("COIN4X", 2);
									}else{
										StoreKitBinding.purchaseProduct( "CXpack", 1 );
						
									}
					
								}
								if(hit.collider.tag=="_engbuy1"){ //7,00,000 coins $1.99 
									audio.PlayOneShot(ActionSound);
									if(gold > 699999){
										gold-= 700000;
										PlayerPrefs.SetInt("G_ENG",2);
									}else{
										StoreKitBinding.purchaseProduct( "ESpack", 1 );
						
									}
								}
								if(hit.collider.tag=="_engbuy2"){ //9,00,000 coins $2.99
									audio.PlayOneShot(ActionSound);
									if(gold > 899999){
										gold -= 900000;
										PlayerPrefs.SetInt("S_ENG",2);
									}else{
										StoreKitBinding.purchaseProduct( "EMpack", 1 );
						
									}
											
					
								}
								
		
				
							
									
						
				}
			
				
			
			}
	
		
	}
	
	/*if(productIdentifier == "CSpack"){
			
			
			SendMessage("PID", 1);
			
		}
		
		if(productIdentifier == "CMpack"){
			
			SendMessage("PID", 2);
		}
		
		
		if(productIdentifier == "HMpack"){
			
			PlayerPrefs.SetInt("M_Health",2);
			
		}
		if(productIdentifier == "CXpack"){
			
			PlayerPrefs.SetInt("COIN4X",2);
			
		}
		
		if(productIdentifier == "ESpack"){
			
			PlayerPrefs.SetInt("G_ENG",2);
			
		}
		if(productIdentifier == "EMpack"){
			*/
	
	
	void GetMessage(int x){
		
		if(x > 2){
			
				if(AnimCode < 4 ){
					AnimCode += 1;
				
			}
			//left
			
			switch(AnimCode){
					
					
					case 1:
						HealthBuy.animation.CrossFade("_Item_L_O", 0.2f);
						EngineBuy.animation.CrossFade("_Item_R_E", 0.2f);
						CoinsBuy.animation.CrossFade("_Item_R_E", 0.2f);
						CoinsXBuy.animation.CrossFade("_Item_R_E", 0.2f);

						break;
					case 2:
						HealthBuy.animation.CrossFade("_Item_R_E", 0.2f);
						EngineBuy.animation.CrossFade("_Item_L_O", 0.2f);
						CoinsBuy.animation.CrossFade("_Item_R_E", 0.2f);
						CoinsXBuy.animation.CrossFade("_Item_R_E", 0.2f);

						break;
					case 3:
						HealthBuy.animation.CrossFade("_Item_R_E", 0.2f);
						EngineBuy.animation.CrossFade("_Item_R_E", 0.2f);
						CoinsBuy.animation.CrossFade("_Item_L_O", 0.2f);
						CoinsXBuy.animation.CrossFade("_Item_R_E", 0.2f);

						break;
					case 4:
						HealthBuy.animation.CrossFade("_Item_R_E", 0.2f);
						EngineBuy.animation.CrossFade("_Item_R_E", 0.2f);
						CoinsBuy.animation.CrossFade("_Item_R_E", 0.2f);
						CoinsXBuy.animation.CrossFade("_Item_L_O", 0.2f);

						break;
				}
			
			
			
		}else{
			//right
			if(AnimCode > 0){
				
					AnimCode -= 1;
				
			}
			
			switch(AnimCode){
					
					
					case 1:
						HealthBuy.animation.CrossFade("_Item_R_O", 0.2f);
						EngineBuy.animation.CrossFade("_Item_L_E", 0.2f);
						CoinsBuy.animation.CrossFade("_Item_L_E", 0.2f);
						CoinsXBuy.animation.CrossFade("_Item_L_E", 0.2f);

						break;
					case 2:
						HealthBuy.animation.CrossFade("_Item_L_E", 0.2f);
						EngineBuy.animation.CrossFade("_Item_R_O", 0.2f);
						CoinsBuy.animation.CrossFade("_Item_L_E", 0.2f);
						CoinsXBuy.animation.CrossFade("_Item_L_E", 0.2f);

						break;
					case 3:
						HealthBuy.animation.CrossFade("_Item_L_E", 0.2f);
						EngineBuy.animation.CrossFade("_Item_L_E", 0.2f);
						CoinsBuy.animation.CrossFade("_Item_R_O", 0.2f);
						CoinsXBuy.animation.CrossFade("_Item_L_E", 0.2f);

						break;
					case 4:
						HealthBuy.animation.CrossFade("_Item_L_E", 0.2f);
						EngineBuy.animation.CrossFade("_Item_L_E", 0.2f);
						CoinsBuy.animation.CrossFade("_Item_L_E", 0.2f);
						CoinsXBuy.animation.CrossFade("_Item_R_O", 0.2f);

						break;
				}
			
			
			
		
	}
		
		
		
}
	
	
	
	
	/*void GetMessage(int x){
		
		if(x > 2){
			
				if(AnimCode < 4 ){
					AnimCode += 1;
				if(AnimCode== 5)
					AnimCode = 1;
			}
			//left
			
			switch(AnimCode){
					
					
					case 1:
						HealthBuy.animation.CrossFade("_Item_R_O", 0.2f);
						EngineBuy.animation.CrossFade("_Item_R_E", 0.2f);
						CoinsBuy.animation.CrossFade("_Item_R_E", 0.2f);
						CoinsXBuy.animation.CrossFade("_Item_R_E", 0.2f);

						break;
					case 2:
						HealthBuy.animation.CrossFade("_Item_R_E", 0.2f);
						EngineBuy.animation.CrossFade("_Item_R_O", 0.2f);
						CoinsBuy.animation.CrossFade("_Item_R_E", 0.2f);
						CoinsXBuy.animation.CrossFade("_Item_R_E", 0.2f);

						break;
					case 3:
						HealthBuy.animation.CrossFade("_Item_R_E", 0.2f);
						EngineBuy.animation.CrossFade("_Item_R_E", 0.2f);
						CoinsBuy.animation.CrossFade("_Item_R_O", 0.2f);
						CoinsXBuy.animation.CrossFade("_Item_R_E", 0.2f);

						break;
					case 4:
						HealthBuy.animation.CrossFade("_Item_R_E", 0.2f);
						EngineBuy.animation.CrossFade("_Item_R_E", 0.2f);
						CoinsBuy.animation.CrossFade("_Item_R_E", 0.2f);
						CoinsXBuy.animation.CrossFade("_Item_R_O", 0.2f);

						break;
				}
			
			
		}else{
			//right
			if(AnimCode < 5){
				
					AnimCode -= 1;
				
			}
			
			switch(AnimCode){
					
					
					case 1:
						HealthBuy.animation.CrossFade("_Item_L_O", 0.2f);
						EngineBuy.animation.CrossFade("_Item_L_E", 0.2f);
						CoinsBuy.animation.CrossFade("_Item_L_E", 0.2f);
						CoinsXBuy.animation.CrossFade("_Item_L_E", 0.2f);

						break;
					case 2:
						HealthBuy.animation.CrossFade("_Item_L_E", 0.2f);
						EngineBuy.animation.CrossFade("_Item_L_O", 0.2f);
						CoinsBuy.animation.CrossFade("_Item_L_E", 0.2f);
						CoinsXBuy.animation.CrossFade("_Item_L_E", 0.2f);

						break;
					case 3:
						HealthBuy.animation.CrossFade("_Item_L_E", 0.2f);
						EngineBuy.animation.CrossFade("_Item_L_E", 0.2f);
						CoinsBuy.animation.CrossFade("_Item_L_O", 0.2f);
						CoinsXBuy.animation.CrossFade("_Item_L_E", 0.2f);

						break;
					case 4:
						HealthBuy.animation.CrossFade("_Item_L_E", 0.2f);
						EngineBuy.animation.CrossFade("_Item_L_E", 0.2f);
						CoinsBuy.animation.CrossFade("_Item_L_E", 0.2f);
						CoinsXBuy.animation.CrossFade("_Item_L_O", 0.2f);

						break;
				}
		
	}
		
		
		
*/
	
	
	
	IEnumerator waitlevels(float levelTm){
		
		yield return new WaitForSeconds(levelTm);
		
		Application.LoadLevel("MainMenu");
	}
	

}


/*
 _cbuy1
 gold += 50000;
 _cbuy2
 gold+= 900000;
 _hbuy2						
PlayerPrefs.SetInt("M_Health",2); 
_cxbuy2
PlayerPrefs.SetInt("COIN4X", 2);
_engbuy1
PlayerPrefs.SetInt("G_ENG",2);
_engbuy2
PlayerPrefs.SetInt("S_ENG",2);

  
 if(hit.collider.tag=="_hbuy2"){  // 40,000 coins $0.99
		
		_hbuy2						
		PlayerPrefs.SetInt("M_Health",2); // true
	

		

	}
	if(hit.collider.tag=="_cbuy1"){ //$0.99  >> 
		
		gold += 50000;

	}
	if(hit.collider.tag=="_cbuy2"){  //$1.99 >>
		
		//gold+= 900000;

	}
	if(hit.collider.tag=="_cxbuy1"){  // 50,000 coins   
		
		if(gold > 49999){
				PlayerPrefs.SetInt("COIN2X", 2);
				gold-= 50000;
			}
	}
	if(hit.collider.tag=="_cxbuy2"){  //3,00,000 coins $0.99
		
		if(gold > 299999){
			gold -= 300000;
			PlayerPrefs.SetInt("COIN4X", 2);
		}

	}
	if(hit.collider.tag=="_engbuy1"){ //7,00,000 coins $1.99 
		
		if(gold > 699999){
			gold-= 700000;
			PlayerPrefs.SetInt("G_ENG",2);
		}
	}
	if(hit.collider.tag=="_engbuy2"){ //9,00,000 coins $2.99
		if(gold > 899999){
			gold -= 900000;
			PlayerPrefs.SetInt("S_ENG",2);
		}
				

	}
*/