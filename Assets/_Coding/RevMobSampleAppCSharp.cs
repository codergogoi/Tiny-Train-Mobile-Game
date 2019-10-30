using System;
using System.Collections;
using System.Collections.Generic;


using UnityEngine;

public class RevMobSampleAppCSharp : MonoBehaviour, IRevMobListener {
	private static readonly int BUTTON_WIDTH = 200;
	private static readonly int BUTTON_HEIGHT = 50;
	private static readonly int PADDING = 20;

	private static readonly int X_POSITION_REFERENCE = 10 + PADDING;
	private static readonly int Y_POSITION_REFERENCE = BUTTON_HEIGHT + PADDING;

	private int i = 0;
	private Vector2 scrollPosition = Vector2.zero;
	delegate void OnButtonClicked();

	private static readonly Dictionary<String, String> appIds = new Dictionary<String, String>() {
		{ "Android", "523abc349d261eb5d0000017"}, // Find your RevMob App IDs in revmob.com
		{ "IOS", "523abc349d261eb5d0000017" }
	};

	private RevMob revmob;
	private RevMobFullscreen fullscreen;
	private RevMobPopup popup;
	private RevMobLink adLink;
	private RevMobBanner banner;
  private RevMobBanner loadedBanner;

	void OnApplicationFocus() {
	}


	void Start(){

		revmob = RevMob.Start(appIds, "GameObject");
		if (banner == null) {
			banner = revmob.CreateBanner();
		}
		banner.Show();
	}

	void Update() {
	}

	void ShowAdBanner(){

		banner.Show();

		//banner = revmob.CreateBanner(10, 20, 200, 40, null, null);
		//banner.Show();

	}

	public void CallFullScreenAd(){

			banner.Hide();


		revmob.ShowFullscreen();



	}

	/*
	void OnGUI() {
    	scrollPosition = GUI.BeginScrollView(new Rect(0,0,Screen.width,Screen.height), scrollPosition, new Rect(0,0,Screen.width,BUTTON_HEIGHT*30));

		i = 0;
		CreateButton("Start Session", () => { revmob = RevMob.Start(appIds, "GameObject"); });
		if (revmob != null) {
			CreateEnvButtons();
			CreateFullscreenButtons();
			CreatePopupButtons();
			CreateAdLinkButtons();
			CreateBannerButtons();
			PreLoadBanner();
		}

		GUI.EndScrollView ();
	}

	void CreateButton(String label, OnButtonClicked onClicked) {
		i++;
		if( GUI.Button(new Rect(X_POSITION_REFERENCE, i * Y_POSITION_REFERENCE, BUTTON_WIDTH, BUTTON_HEIGHT), label) ) {
			onClicked();
		}
	}

	void CreateEnvButtons() {
		CreateButton("Exit", () => { Application.Quit(); });
		CreateButton("Testing Mode With Ads", () => { revmob.SetTestingMode(RevMob.Test.WITH_ADS); });
		CreateButton("Testing Mode Without Ads", () => { revmob.SetTestingMode(RevMob.Test.WITHOUT_ADS); });
		CreateButton("Disable Testing Mode", () => { revmob.SetTestingMode(RevMob.Test.DISABLED); });
		CreateButton("Print Env Information", () => { revmob.PrintEnvironmentInformation(); });
		CreateButton("Set timeout to 5s", () => { revmob.SetTimeoutInSeconds(5); });
	}

	void CreateFullscreenButtons() {
		CreateButton("Show Fullscreen", () => { revmob.ShowFullscreen(); return; });
		i++;
		if( GUI.Button(new Rect(X_POSITION_REFERENCE, i * Y_POSITION_REFERENCE, BUTTON_WIDTH, BUTTON_HEIGHT), "Load Fullscreen") ) {
			fullscreen = revmob.CreateFullscreen();
			return;
		}

		if (fullscreen != null) {
			if ( GUI.Button(new Rect(X_POSITION_REFERENCE + BUTTON_WIDTH + PADDING, i * Y_POSITION_REFERENCE, BUTTON_WIDTH, BUTTON_HEIGHT), "Show Fullscreen") ) {
				fullscreen.Show();
				return;
			}
			
			if ( GUI.Button(new Rect(X_POSITION_REFERENCE + BUTTON_WIDTH + PADDING, (i + 1) * Y_POSITION_REFERENCE, BUTTON_WIDTH, BUTTON_HEIGHT), "Hide Fullscreen") ) {
				fullscreen.Hide();
				return;
			}
		}
	}

	void CreatePopupButtons() {
		CreateButton("Show Popup", () => { revmob.ShowPopup(); return; });
		i++;
		if( GUI.Button(new Rect(X_POSITION_REFERENCE, i * Y_POSITION_REFERENCE, BUTTON_WIDTH, BUTTON_HEIGHT), "Load Popup") ) {
			popup = revmob.CreatePopup();
			return;
		}

		if (popup != null) {
			if ( GUI.Button(new Rect(X_POSITION_REFERENCE + BUTTON_WIDTH + PADDING, i * Y_POSITION_REFERENCE, BUTTON_WIDTH, BUTTON_HEIGHT), "Show Popup") ) {
				popup.Show();
				popup = null;
				return;
			}
		}
	}

	void CreateAdLinkButtons() {
		CreateButton("Open Ad Link", () => { revmob.OpenAdLink(); return; });
		i++;
		if( GUI.Button(new Rect(X_POSITION_REFERENCE, i * Y_POSITION_REFERENCE, BUTTON_WIDTH, BUTTON_HEIGHT), "Create AdLink") ) {
			if (revmob == null)
				return;
			adLink = revmob.CreateAdLink();
			return;
		}

		if (adLink != null) {
			if ( GUI.Button(new Rect(X_POSITION_REFERENCE + BUTTON_WIDTH + PADDING, i * Y_POSITION_REFERENCE, BUTTON_WIDTH, BUTTON_HEIGHT), "Open Link") ) {
				adLink.Open();
				adLink = null;
				return;
			}
		}
	}

	void CreateBannerButtons() {
		i++;
		if( GUI.Button(new Rect(X_POSITION_REFERENCE, i * Y_POSITION_REFERENCE, BUTTON_WIDTH, BUTTON_HEIGHT), "Show Banner") ) {
		#if UNITY_ANDROID || UNITY_IPHONE
			if (banner == null) {
				banner = revmob.CreateBanner();
			}
			banner.Show();
		#endif
			return;
		}
		i++;
		if ( GUI.Button(new Rect(X_POSITION_REFERENCE, i * Y_POSITION_REFERENCE, BUTTON_WIDTH, BUTTON_HEIGHT), "Custom Banner") ) {
		#if UNITY_ANDROID
			banner = revmob.CreateBanner(RevMob.Position.TOP, 0, 0, Screen.width, 55);
			banner.Show();
		#elif UNITY_IPHONE
			banner = revmob.CreateBanner(10, 20, 200, 40, null, null);
			banner.Show();
		#endif
			return;
		}

		if (banner != null) 
		{
			if ( GUI.Button(new Rect(X_POSITION_REFERENCE + BUTTON_WIDTH + PADDING, i * Y_POSITION_REFERENCE, BUTTON_WIDTH, BUTTON_HEIGHT), "Hide Banner") ) {
			#if UNITY_ANDROID || UNITY_IPHONE
				banner.Hide();
			#endif
				return;
			}
		}

		if (banner != null) 
		{
			if ( GUI.Button(new Rect(X_POSITION_REFERENCE + BUTTON_WIDTH + PADDING, (i+1) * Y_POSITION_REFERENCE, BUTTON_WIDTH, BUTTON_HEIGHT), "Deactivate Banner") ) {
			#if UNITY_ANDROID || UNITY_IPHONE
				banner.Release();
				banner = null;
			#endif
				return;
			}
		}
  }
    
	void PreLoadBanner() {
		i++;
		if( GUI.Button(new Rect(X_POSITION_REFERENCE, i * Y_POSITION_REFERENCE, BUTTON_WIDTH, BUTTON_HEIGHT), "Load Banner") ) {
  		#if UNITY_ANDROID || UNITY_IPHONE
        // if (loadedBanner == null) {
  				loadedBanner = revmob.CreateBanner();
        // }
  		#endif
  			return;
    }
		
    if (loadedBanner != null)
    {
  		if( GUI.Button(new Rect(X_POSITION_REFERENCE + BUTTON_WIDTH + PADDING, (i+1) * Y_POSITION_REFERENCE, BUTTON_WIDTH, BUTTON_HEIGHT), "Show Loaded Banner") ) {
  		#if UNITY_ANDROID || UNITY_IPHONE
			  loadedBanner.Show();
  		#endif
  			return;
  		}
    }
    
    if (loadedBanner != null)
    {
      if( GUI.Button(new Rect(X_POSITION_REFERENCE + BUTTON_WIDTH + PADDING, (i+2) * Y_POSITION_REFERENCE, BUTTON_WIDTH, BUTTON_HEIGHT), "Hide Loaded Banner") ) {
  		#if UNITY_ANDROID || UNITY_IPHONE
			  loadedBanner.Hide();
  		#endif
  			return;
  		}
    }
    
    if (loadedBanner != null)
    {
      if( GUI.Button(new Rect(X_POSITION_REFERENCE + BUTTON_WIDTH + PADDING, (i+3) * Y_POSITION_REFERENCE, BUTTON_WIDTH, BUTTON_HEIGHT), "Release Loaded Banner") ) {
		#if UNITY_ANDROID || UNITY_IPHONE
				loadedBanner.Release();
        loadedBanner = null;
		#endif
			return;
  		}
    }
  }*/

	#region IRevMobListener implementation
	public void SessionIsStarted() {
		Debug.Log(">>> Session Started");
	}

	public void SessionNotStarted(string message) {
		Debug.Log(">>> Session not started");
	}

	public void AdDidReceive(string revMobAdType) {
		Debug.Log(">>> AdDidReceive: " + revMobAdType);
	}

	public void AdDidFail(string revMobAdType) {
		Debug.Log(">>> AdDidFail: " + revMobAdType);
	}

	public void AdDisplayed(string revMobAdType) {
		Debug.Log(">>> AdDisplayed: " + revMobAdType);
	}

	public void UserClickedInTheAd(string revMobAdType)	{
		Debug.Log(">>> AdClicked: " + revMobAdType);
	}

	public void UserClosedTheAd(string revMobAdType) {
		Debug.Log(">>> AdClosed: " + revMobAdType);
	}

	public void InstallDidReceive(string message) {}

	public void InstallDidFail(string message) {}

	#endregion
}