using UnityEngine;
using System.Collections;

public class _AdStart : _BaseClass {

	public AudioClip CoinsSound;

	public GUITexture FreeCoinsBtn;

	private float width,height;

	void Start(){

		width = Screen.width;
		height = Screen.height;

		FreeCoinsBtn.pixelInset = new  Rect(0,0,width/3.5f,width/2.8f);
		Initialize();


	}



	void Update(){

		if(Input.GetMouseButtonDown(0)){


			Vector3 pos = Input.mousePosition;

			if(FreeCoinsBtn.HitTest(pos)){

				PlayAVideo("vzc731a439072747168a");
			}

		}

	}


	public void ShowVideoAdd(){

		PlayAVideo("vzc731a439072747168a");

	}

		public void Initialize()
		{
			// Assign any AdColony Delegates before calling Configure
			AdColony.OnVideoFinished = this.OnVideoFinished;
			
			// If you wish to use a the customID feature, you should call  that now.
			// Then, configure AdColony:
			AdColony.Configure
				(
					"2.0", // Arbitrary app version and Android app store declaration.
					"appd6bb55f42e354847b2",   // ADC App ID from adcolony.com
					"vzc731a439072747168a", // A zone ID from adcolony.com
					"vzc731a439072747168a", // Any number of additional Zone IDS
					"vzc731a439072747168a"
					);
		}
		
		// When a video is available, you may choose to play it in any fashion you like.
		// Generally you will play them automatically during breaks in your game,
		// or in response to a user action like clicking a button.
		// Below is a method that could be called, or attached to a GUI action.
		public void PlayAVideo( string zoneID )
		{
			// Check to see if a video is available in the zone.
			if(AdColony.IsVideoAvailable(zoneID))
			{
				Debug.Log("Play AdColony Video");
				// Call AdColony.ShowVideoAd with that zone to play an interstitial video.
				// Note that you should also pause your game here (audio, etc.) AdColony will not
				// pause your app for you.
				AdColony.ShowVideoAd(zoneID); 
			}
			else
			{
				Debug.Log("Video Not Available");
			}
		}
		
		private void OnVideoFinished(bool ad_was_shown)
		{
			Debug.Log("On Video Finished");
			
			gold  = PlayerPrefs.GetInt("Gold");
			
			gold+= 200;
			PlayerPrefs.SetInt("Gold",gold);
			audio.PlayOneShot(CoinsSound);
			// load clellange mode here
			// Resume your app here.
		}
	}