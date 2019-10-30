using UnityEngine;
using System.Collections;

public class _TheamChanger : MonoBehaviour {

	public Color col1;
	public Color col2;
	public Color col3;
	public Color col4;
	public Color col5;
	public Color col6;
	public Color col7;
	public Color col8;
	public Color col9;
	public Color col10;
	
	private Color TempCol1,TempCol2;
	
	
	public float duration = 3.0f;
	
	private float changeTime;
		
	// Use this for initialization
	void Start () {
	
		TempCol1 = col1;
		TempCol2 = col2;
		RenderSettings.fog = true;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		changeTime += Time.deltaTime;
		
		if(changeTime > 150){
			
			TempCol1 = col4;
			TempCol2 = col5;		
		}else if(changeTime > 120){
			
			TempCol1 = col3;
			TempCol2 = col4;
			
		}else if(changeTime > 80){
			
			TempCol1 = col2;
			TempCol2 = col3;		
		}else if(changeTime > 50){
			
			TempCol1 = col1;
			TempCol2 = col2;
		}
		
			float t = Mathf.PingPong(Time.time, duration)/ duration;
			camera.backgroundColor = Color.Lerp(TempCol1, TempCol2,t);
						
			RenderSettings.fogColor = Color.Lerp(TempCol1, TempCol2,t);
	
	}
}
