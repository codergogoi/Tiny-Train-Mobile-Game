//
//  StoreKitBinding.m
//  StoreKit
//
//  Created by Mike DeSaro on 8/18/10.
//  Copyright 2010 Prime31 Studios. All rights reserved.
//

#import "StoreKitManager.h"
#if !TARGET_OS_IPHONE
#include <sys/socket.h>
#include <sys/sysctl.h>
#include <net/if.h>
#include <net/if_dl.h>
#import <CommonCrypto/CommonDigest.h>
#endif


// Converts NSString to C style string by way of copy (Mono will free it)
#define MakeStringCopy( _x_ ) ( _x_ != NULL && [_x_ isKindOfClass:[NSString class]] ) ? strdup( [_x_ UTF8String] ) : NULL

// Converts C style string to NSString
#define GetStringParam( _x_ ) ( _x_ != NULL ) ? [NSString stringWithUTF8String:_x_] : [NSString stringWithUTF8String:""]



bool _storeKitCanMakePayments()
{
	return ( [[StoreKitManager sharedManager] canMakePayments] == 1 );
}


// Accepts comma-delimited set of product identifiers
void _storeKitRequestProductData( const char *productIdentifiers )
{
	// grab the product list and split it on commas
	NSString *identifiers = GetStringParam( productIdentifiers );
	NSArray *parts = [identifiers componentsSeparatedByString:@","];
	NSMutableSet *set = [NSMutableSet set];
	
	// add all the products to the set
	for( NSString *product in parts )
		[set addObject:[product stringByTrimmingCharactersInSet:[NSCharacterSet whitespaceAndNewlineCharacterSet]]];
	
	[[StoreKitManager sharedManager] requestProductData:set];
}


void _storeKitPurchaseProduct( const char *product, int quantity )
{
	NSString *productId = GetStringParam( product );
	[[StoreKitManager sharedManager] purchaseProduct:productId quantity:quantity];
}


void _storeKitRestoreCompletedTransactions()
{
	[[StoreKitManager sharedManager] restoreCompletedTransactions];
}


void _storeKitValidateReceipt( const char *base64EncodedTransactionReceipt, bool isTest )
{
	NSString *receipt = GetStringParam( base64EncodedTransactionReceipt );
	[[StoreKitManager sharedManager] validateReceipt:receipt isTestReceipt:isTest];
}


void _storeKitValidateAutoRenewableReceipt( const char *base64EncodedTransactionReceipt, const char *secret, bool isTest )
{
	[[StoreKitManager sharedManager] validateAutoRenewableReceipt:GetStringParam( base64EncodedTransactionReceipt )
													   withSecret:GetStringParam( secret )
													isTestReceipt:isTest];
}


const char * _storeKitGetAllSavedTransactions()
{
	NSString *transactions = [[StoreKitManager sharedManager] getAllSavedTransactions];
	if( transactions )
		return MakeStringCopy( transactions );
	return MakeStringCopy( @"" );
}


#if !TARGET_OS_IPHONE
const char * _storeKitGetNextMessage()
{
	if( [StoreKitManager sharedManager].messages.count == 0 )
		return MakeStringCopy( @"" );

	// grab the first message and remove it from the array
	StoreKitMessage *mess = [[StoreKitManager sharedManager].messages objectAtIndex:0];
	
	NSString *ret = [NSString stringWithFormat:@"%@:::%@", mess.method, mess.param];
	[[StoreKitManager sharedManager].messages removeObjectAtIndex:0];
	
	return MakeStringCopy( ret );
}


// UDID
NSString * _storeKitMD5HashString( NSString *input )
{
    if( input == nil || input.length == 0 )
        return nil;
	
	NSData *data = [input dataUsingEncoding:NSUTF8StringEncoding];
    
	unsigned char result[CC_MD5_DIGEST_LENGTH];
	CC_MD5( data.bytes, data.length, result );
	
	return [NSString stringWithFormat:
			@"%02x%02x%02x%02x%02x%02x%02x%02x%02x%02x%02x%02x%02x%02x%02x%02x",
			result[0], result[1], result[2], result[3], result[4], result[5], result[6], result[7],
			result[8], result[9], result[10], result[11], result[12], result[13], result[14], result[15]
			];
}


NSString *_storeKitMacAddress()
{
    int mib[6];
    size_t len;
    char *buf;
    unsigned char *ptr;
    struct if_msghdr *ifm;
    struct sockaddr_dl *sdl;
    
    mib[0] = CTL_NET;
    mib[1] = AF_ROUTE;
    mib[2] = 0;
    mib[3] = AF_LINK;
    mib[4] = NET_RT_IFLIST;
    
    if( ( mib[5] = if_nametoindex( "en0" ) ) == 0 )
	{
        printf("Error: if_nametoindex error\n");
        return NULL;
    }
    
    if( sysctl( mib, 6, NULL, &len, NULL, 0 ) < 0 )
	{
        printf("Error: sysctl, take 1\n");
        return NULL;
    }
    
	buf = (char*)malloc( len );
    if( buf == NULL )
	{
        printf("Could not allocate memory. error!\n");
        return NULL;
    }
    
    if( sysctl( mib, 6, buf, &len, NULL, 0 ) < 0 )
	{
        printf("Error: sysctl, take 2");
        return NULL;
    }
    
    ifm = (struct if_msghdr*)buf;
    sdl = (struct sockaddr_dl*)( ifm + 1 );
    ptr = (unsigned char*)LLADDR( sdl );
    NSString *outstring = [NSString stringWithFormat:@"%02X:%02X:%02X:%02X:%02X:%02X", 
                           *ptr, *(ptr+1), *(ptr+2), *(ptr+3), *(ptr+4), *(ptr+5)];
    free( buf );
    
    return outstring;
}


const char * _storeKitUniqueDeviceIdentifier()
{
    NSString *stringToHash = [NSString stringWithFormat:@"%@%@", _storeKitMacAddress(), [[NSBundle mainBundle] bundleIdentifier]];
	NSString *hash = _storeKitMD5HashString( stringToHash );
	return MakeStringCopy( hash );
}


const char * _storeKitUniqueGlobalDeviceIdentifier()
{
	NSString *hash = _storeKitMD5HashString( _storeKitMacAddress() );
	return MakeStringCopy( hash );
}

#endif


