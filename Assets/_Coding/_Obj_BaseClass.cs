using UnityEngine;
using System.Collections;

public class _Obj_BaseClass : _BaseClass {
	
	
	//objectives
	/*
	 20Lakh score
	 
	 5 Make 50,00,000 & Collect 100 gold Stone in a Lap 
	 4 make 10,00,000 & collect 1KG gold in a Lap 
	 3 make 5,00,000 & collect 500grms Gold in a Lap
	 2 Make 1,00,000 score or 300 grms gold in a lap
	 1 Make 50,000 score or 200 Grms Gold in a lap
	 */
	
	public static int star;
	public static string alert;
	public static int objective_number;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(score > 499999 && PlayerPrefs.GetInt("obj9") < 3){ //9
			
			if(Health > 3){
				
				star = 3;
				objective_number = 9;
				PlayerPrefs.SetInt("obj9",3);
			}else{
				objective_number = 9;
				star = 2;
			if(PlayerPrefs.GetInt("obj9") < 2)
				PlayerPrefs.SetInt("obj9",2);
			}
			
		}else if(score > 499999 && PlayerPrefs.GetInt("obj8") < 3){ // 8
			
			if(tempgold > 500){
				
				star = 3;
				objective_number = 8;
				PlayerPrefs.SetInt("obj8",3);
			}else{
				objective_number = 8;
				star = 2;
			if(PlayerPrefs.GetInt("obj8") < 2)
				PlayerPrefs.SetInt("obj8",2);
			}
			
		}else if(score > 200000 && PlayerPrefs.GetInt("obj7") < 3){ // 7
			
			if(tempgold > 1499){
				
				star = 3;
				objective_number = 7;
				PlayerPrefs.SetInt("obj7",3);
				
			}else{
				objective_number = 7;
				if(PlayerPrefs.GetInt("obj7") < 2)
				PlayerPrefs.SetInt("obj7",2);
				star = 2;
			}
			
		}else if(score > 199999 && PlayerPrefs.GetInt("obj6") < 3){ // 6
			
			if(Health > 2){
				
				star = 3;
				objective_number = 6;
				PlayerPrefs.SetInt("obj6",3);
			}else{
				objective_number = 6;
				star = 2;
			if(PlayerPrefs.GetInt("obj6") < 2)
				PlayerPrefs.SetInt("obj6",2);
			}
			
		}else if(score > 99999 && PlayerPrefs.GetInt("obj5") < 3){ // 5
			
			if(tempgold > 499){
				
				star = 3;
				objective_number = 5;
				PlayerPrefs.SetInt("obj5",3);
				
			}else{
				objective_number = 5;
				if(PlayerPrefs.GetInt("obj5") < 2)
					PlayerPrefs.SetInt("obj5",2);
				star = 2;
			}
			
		}else if(score > 69999 && PlayerPrefs.GetInt("obj3") < 3){ // 3
			
			if(Health > 2){
				
				star = 3;
				objective_number = 3;
				PlayerPrefs.SetInt("obj3",3);
			}else{
				objective_number = 3;
				star = 2;
			if(PlayerPrefs.GetInt("obj3") < 2)
				PlayerPrefs.SetInt("obj3",2);
			}
			
		}else if(score > 20000 && PlayerPrefs.GetInt("obj4") < 3){ // 4
			
			if(tempgold > 299){
				
				star = 3;
				objective_number = 4;
				PlayerPrefs.SetInt("obj4",3);
				
			}else{
				objective_number = 4;
				if(PlayerPrefs.GetInt("obj4") < 2)
					PlayerPrefs.SetInt("obj4",2);
				star = 2;
			}
			
		}else if(score > 10000 && PlayerPrefs.GetInt("obj2") < 3){ // 2
			
			if(tempgold > 199){
				
				star = 3;
				objective_number = 2;
				PlayerPrefs.SetInt("obj2",3);
				
			}else{
			if(PlayerPrefs.GetInt("obj2") < 2)
				objective_number = 2;
				PlayerPrefs.SetInt("obj2",2);
				star = 2;
			}
			
		}else if(score > 5000 && PlayerPrefs.GetInt("obj1") < 3){ // 1
			
			if(tempgold > 99){
				
				star = 3;
				objective_number = 1;
				PlayerPrefs.SetInt("obj1",3);
				
			}else{
				objective_number = 1;
			if(PlayerPrefs.GetInt("obj1") < 2)
				PlayerPrefs.SetInt("obj1",2);
				star = 2;
			}
			
		}else{
			
			star = 0;
		}
		
	//print("Working" + objective_number +""+ star);	
	
	}
}
