using UnityEngine;
using System;
using System.Collections.Generic;



public class StoreKitManager : MonoBehaviour
{
	//public GUIText Log;
	public AudioClip BuyDoneSound;
#if UNITY_IPHONE
	// Events and delegates
	public delegate void ProductPurchasedEventHandler( string productIdentifier, string receipt, int quantity );	
	public delegate void ProductListReceivedEventHandler( List<StoreKitProduct> productList );
	public delegate void StoreKitErrorEventHandler( string error );
	public delegate void StoreKitEmptyEventHandler();
	public delegate void StoreKitStringEventHandler( string response );
	public delegate void ValidateReceiptSuccessfulEventHandler();
	
	// Fired when a product is successfully paid for.  returnValue will hold the productIdentifer and receipt of the purchased product.
	public static event ProductPurchasedEventHandler purchaseSuccessful;
	
	// Fired when the product list your required returns.  Automatically serializes the productString into StoreKitProduct's.
	public static event ProductListReceivedEventHandler productListReceived;
	
	// Fired when requesting product data fails
	public static event StoreKitErrorEventHandler productListRequestFailed;
	
	// Fired when a product purchase fails
	public static event StoreKitErrorEventHandler purchaseFailed;
	
	// Fired when a product purchase is cancelled by the user or system
	public static event StoreKitErrorEventHandler purchaseCancelled;
	
	// Fired when the validateReceipt call fails
	public static event StoreKitErrorEventHandler receiptValidationFailed;
	
	// Fired when receive validation completes and returns the raw receipt data
	public static event StoreKitStringEventHandler receiptValidationRawResponseReceived;
	
	// Fired when the validateReceipt method finishes.  It does not automatically mean success.
	public static event ValidateReceiptSuccessfulEventHandler receiptValidationSuccessful;
	
	// Fired when an error is encountered while adding transactions from the user's purchase history back to the queue
	public static event StoreKitErrorEventHandler restoreTransactionsFailed;
	
	// Fired when all transactions from the user's purchase history have successfully been added back to the queue
	public static event StoreKitEmptyEventHandler restoreTransactionsFinished;
	
	
    void Awake()
    {
		// Set the GameObject name to the class name for easy access from Obj-C
		gameObject.name = this.GetType().ToString();
		DontDestroyOnLoad( this );
    }
	
	
	public void productPurchased( string returnValue )
	{
		// split up into useful data
		string[] receiptParts = returnValue.Split( new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries );
		if( receiptParts.Length != 3 )
		{
			if( purchaseFailed != null )
				purchaseFailed( "Could not parse receipt information: " + returnValue );
			return;
		}
			
		string productIdentifier = receiptParts[0];
		string receipt = receiptParts[1];
		int quantity = int.Parse( receiptParts[2] );
		
		if( purchaseSuccessful != null )
			purchaseSuccessful( productIdentifier, receipt, quantity );
		//Log.text= productIdentifier;
		audio.PlayOneShot(BuyDoneSound);
		
		
		/* 
			 _cbuy1 CSpack
			 gold += 50000;
			 _cbuy2 CMpack
			 gold+= 900000;
			 _hbuy2 HMpack				
			PlayerPrefs.SetInt("M_Health",2); 
			_cxbuy2 CXpack
			PlayerPrefs.SetInt("COIN4X", 2);
			_engbuy1ESpack
			PlayerPrefs.SetInt("G_ENG",2);
			_engbuy2EMpack
			PlayerPrefs.SetInt("S_ENG",2);
		*/
		//PlayerPrefs.SetInt("Gold",)
		
		if(productIdentifier == "CSpack"){
			
			
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
			
			PlayerPrefs.SetInt("S_ENG",2);
			
		}
		
		
		
	}
	
	
	public void productPurchaseFailed( string error )
	{
		if( purchaseFailed != null )
			purchaseFailed( error );
	}
	
		
	public void productPurchaseCancelled( string error )
	{
		if( purchaseCancelled != null )
			purchaseCancelled( error );
	}
	
	
	public void productsReceived( string productString )
	{
        List<StoreKitProduct> productList = new List<StoreKitProduct>();

		// parse out the products
        string[] productParts = productString.Split( new string[] { "||||" }, StringSplitOptions.RemoveEmptyEntries );
        for( int i = 0; i < productParts.Length; i++ )
            productList.Add( StoreKitProduct.productFromString( productParts[i] ) );
		
		if( productListReceived != null )
			productListReceived( productList );
	}
	
	
	public void productsRequestDidFail( string error )
	{
		if( productListRequestFailed != null )
			productListRequestFailed( error );
	}
	
	
	public void validateReceiptFailed( string error )
	{
		if( receiptValidationFailed != null )
			receiptValidationFailed( error );
	}
	
	
	public void validateReceiptRawResponse( string response )
	{
		if( receiptValidationRawResponseReceived != null )
			receiptValidationRawResponseReceived( response );
	}
	
	
	public void validateReceiptFinished( string statusCode )
	{
		if( statusCode == "0" )
		{
			if( receiptValidationSuccessful != null )
				receiptValidationSuccessful();
		}
		else
		{
			if( receiptValidationFailed != null )
				receiptValidationFailed( "Receipt validation failed with statusCode: " + statusCode );
		}
	}
	
	
	public void restoreCompletedTransactionsFailed( string error )
	{
		if( restoreTransactionsFailed != null )
			restoreTransactionsFailed( error );
	}
	
	
	public void restoreCompletedTransactionsFinished( string empty )
	{
		if( restoreTransactionsFinished != null )
			restoreTransactionsFinished();
	}
#endif
}

