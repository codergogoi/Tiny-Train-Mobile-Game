//
//  StoreKitManager.h
//  StoreKit
//
//  Created by Mike DeSaro on 8/18/10.
//  Copyright 2010 Prime31 Studios. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <StoreKit/StoreKit.h>
#import "StoreKitReceiptRequest.h"
#if !TARGET_OS_IPHONE
#import "StoreKitMessage.h"
#endif


@interface StoreKitManager : NSObject <SKProductsRequestDelegate, SKPaymentTransactionObserver, StoreKitReceiptRequestDelegate>
{
	NSArray *products;
#if !TARGET_OS_IPHONE
	NSMutableArray *messages;
#endif
}
@property (nonatomic, retain) NSArray *products;
#if !TARGET_OS_IPHONE
@property (nonatomic, retain) NSMutableArray *messages;
#endif


+ (StoreKitManager*)sharedManager;


- (BOOL)canMakePayments;

- (void)restoreCompletedTransactions;

- (void)requestProductData:(NSSet*)productIdentifiers;

- (void)purchaseProduct:(NSString*)productIdentifier quantity:(int)quantity;

- (void)validateReceipt:(NSString*)transactionReceipt isTestReceipt:(BOOL)isTest;

- (void)validateAutoRenewableReceipt:(NSString*)transactionReceipt withSecret:(NSString*)sharedSecret isTestReceipt:(BOOL)isTest;

- (NSString*)getAllSavedTransactions;

@end
