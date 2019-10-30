using UnityEngine;
using System.Collections;
using System;
using Chartboost;


public class CBUIManager : MonoBehaviour {
	
#if UNITY_ANDROID || UNITY_IPHONE

	void Awake(){


	}

	public void Update() {
#if UNITY_ANDROID
		// Handle the Android back button (only if impressions are set to not use activities)
		if (Input.GetKeyUp(KeyCode.Escape)) {
			// Check if Chartboost wants to respond to it
			if (CBBinding.onBackPressed()) {
				// If so, return and ignore it
				return;
			} else {
				// Otherwise, handle it ourselves -- let's close the app
				Application.Quit();
			}
		}
#endif
	}

	void OnEnable() {
		// Initialize the Chartboost plugin

		#if UNITY_ANDROID
		// Replace these with your own Android app ID and signature from the Chartboost web portal
		CBBinding.init("4f7b433509b6025804000002", "dd2d41b69ac01b80f443f5b6cf06096d457f82bd");
		
		#elif UNITY_IPHONE
		// Replace these with your own iOS app ID and signature from the Chartboost web portal
		CBBinding.init("53B28105C26Ee40B38966A37", "f0af312cb37ba17eb8a2a65d6d6770fc7ce96368");
		CBBinding.cacheInterstitial("Default");
		CBBinding.showInterstitial("Default");
		#endif
	}




	void Start(){

	

	}


	void OnApplicationPause(bool paused) {
#if UNITY_ANDROID
		// Manage Chartboost plugin lifecycle
		CBBinding.pause(paused);
#endif
	}

	void OnDisable() {
		// Shut down the Chartboost plugin
#if UNITY_ANDROID
		CBBinding.destroy();
#endif
	}

	/*
	void OnGUI() {
#if UNITY_ANDROID
		// Disable user input for GUI when impressions are visible
		// This is only necessary on Android if we have disabled impression activities
		//   by having called CBBinding.init(ID, SIG, false), as that allows touch
		//   events to leak through Chartboost impressions
		GUI.enabled = !CBBinding.isImpressionVisible();
#endif
		
		GUI.matrix = Matrix4x4.Scale(new Vector3(2, 2, 2));
		
		if (GUILayout.Button("Cache Interstitial")) {
			CBBinding.cacheInterstitial("Default");
		}
		
		if (GUILayout.Button("Show Interstitial")) {
			CBBinding.showInterstitial("Default");
		}
		
		if (GUILayout.Button("Cache More Apps")) {
			CBBinding.cacheMoreApps();
		}
		
		if (GUILayout.Button("Show More Apps")) {
			CBBinding.showMoreApps();
		}
	}

	*/

// UNITY_ANDROID || UNITY_IPHONE
#endif
}
