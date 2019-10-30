using UnityEngine;
using System;
using System.Collections.Generic;


// Any methods that Obj-C calls back using UnitySendMessage should be present here
public class GameCenterManager : MonoBehaviour
{
	// Player events
	// Fired when retrieving player data (friends) fails
	public static event Action<string> loadPlayerDataFailed;
	
	// Fired when player data is loaded after requesting friends
	public static event Action<List<GameCenterPlayer>> playerDataLoaded;
	
	// Fired when a player is logged in
	public static event Action playerAuthenticated;
	
	// Fired when a player fails to login
	public static event Action<string> playerFailedToAuthenticate;
	
	// Fired when a player logs out
	public static event Action playerLoggedOut;
	
	// Leaderboard events
	// Fired when loading leaderboard category data fails
	public static event Action<string> loadCategoryTitlesFailed;
	
	// Fired when loading leaderboard category data completes
	public static event Action<List<GameCenterLeaderboard>> categoriesLoaded;
	
	// Fired when reporting a score fails
	public static event Action<string> reportScoreFailed;
	
	// Fired when reporting a score finishes successfully
	public static event Action<string> reportScoreFinished;
	
	// Fired when retrieving scores fails
	public static event Action<string> retrieveScoresFailed;
	
	// Fired when retrieving scores completes successfully
	public static event Action<List<GameCenterScore>> scoresLoaded;
	
	// Fired when retrieving scores for a playerId fails
	public static event Action<string> retrieveScoresForPlayerIdFailed;
	
	// Fired when retrieving scores for a playerId completes successfully
	public static event Action<List<GameCenterScore>> scoresForPlayerIdLoaded;
	
	// Achievement events
	// Fired when reporting an achievement fails
	public static event Action<string> reportAchievementFailed;
	
	// Fired when reporting an achievement completes successfully
	public static event Action<string> reportAchievementFinished;
	
	// Fired when loading achievements fails
	public static event Action<string> loadAchievementsFailed;
	
	// Fired when loading achievements completes successfully
	public static event Action<List<GameCenterAchievement>> achievementsLoaded;
	
	// Fired when resetting achievements fails
	public static event Action<string> resetAchievementsFailed;
	
	// Fired when resetting achievements completes successfully
	public static event Action resetAchievementsFinished;
	
	// Fired when loading achievement metadata fails
	public static event Action<string> retrieveAchievementMetadataFailed;
	
	// Fired when loading achievement metadata completes successfully
	public static event Action<List<GameCenterAchievementMetadata>> achievementMetadataLoaded;
	
	
    void Awake()
    {
		// Set the GameObject name to the class name for easy access from Obj-C
		gameObject.name = this.GetType().ToString();
		DontDestroyOnLoad( this );
    }
	
	
	#region Player callbacks
	
	public void loadPlayerDataDidFail( string error )
	{
		if( loadPlayerDataFailed != null )
			loadPlayerDataFailed( error );
	}
	
	
	public void loadPlayerDataDidLoad( string jsonFriendList )
	{
		List<GameCenterPlayer> list = GameCenterPlayer.fromJSON( jsonFriendList );
		
		if( playerDataLoaded != null )
			playerDataLoaded( list );
	}
	
	
	public void playerDidLogOut()
	{
		if( playerLoggedOut != null )
			playerLoggedOut();
	}
	
	
	public void playerDidAuthenticate()
	{
		if( playerAuthenticated != null )
			playerAuthenticated();
	}
	
	
	public void playerAuthenticationFailed( string error )
	{
		if( playerFailedToAuthenticate != null )
			playerFailedToAuthenticate( error );
	}
	
	#endregion;
	
	
	#region Leaderboard callbacks
	
	public void loadCategoryTitlesDidFail( string error )
	{
		if( loadCategoryTitlesFailed != null )
			loadCategoryTitlesFailed( error );
	}
	
	
	public void categoriesDidLoad( string jsonCategoryList )
	{
		List<GameCenterLeaderboard> list = GameCenterLeaderboard.fromJSON( jsonCategoryList );
		
		if( categoriesLoaded != null )
			categoriesLoaded( list );
	}
	
	
	public void reportScoreDidFail( string error )
	{
		if( reportScoreFailed != null )
			reportScoreFailed( error );
	}
	
	
	public void reportScoreDidFinish( string category )
	{
		if( reportScoreFinished != null )
			reportScoreFinished( category );
	}
	
	
	public void retrieveScoresDidFail( string category )
	{
		if( retrieveScoresFailed != null )
			retrieveScoresFailed( category );
	}
	
	
	public void retrieveScoresDidLoad( string jsonScoresList )
	{
		List<GameCenterScore> list = GameCenterScore.fromJSON( jsonScoresList );
		
		if( scoresLoaded != null )
			scoresLoaded( list );
	}
	
	
	public void retrieveScoresForPlayerIdDidFail( string error )
	{
		if( retrieveScoresForPlayerIdFailed != null )
			retrieveScoresForPlayerIdFailed( error );
	}
	
	
	public void retrieveScoresForPlayerIdDidLoad( string jsonScoresList )
	{
		List<GameCenterScore> list = GameCenterScore.fromJSON( jsonScoresList );
		
		if( scoresForPlayerIdLoaded != null )
			scoresForPlayerIdLoaded( list );
	}
	
	#endregion;
	
	
	#region Achievements	
	
	public void reportAchievementDidFail( string error )
	{
		if( reportAchievementFailed != null )
			reportAchievementFailed( error );
	}
	
	
	public void reportAchievementDidFinish( string identifier )
	{
		if( reportAchievementFinished != null )
			reportAchievementFinished( identifier );
	}
	
	
	public void loadAchievementsDidFail( string error )
	{
		if( loadAchievementsFailed != null )
			loadAchievementsFailed( error );
	}
	
	
	public void achievementsDidLoad( string jsonAchievmentList )
	{
		List<GameCenterAchievement> list = GameCenterAchievement.fromJSON( jsonAchievmentList );
		
		if( achievementsLoaded != null )
			achievementsLoaded( list );
	}
	
	
	public void resetAchievementsDidFail( string error )
	{
		if( resetAchievementsFailed != null )
			resetAchievementsFailed( error );
	}
	
	
	public void resetAchievementsDidFinish( string emptyString )
	{
		if( resetAchievementsFinished != null )
			resetAchievementsFinished();
	}
	

	public void retrieveAchievementsMetadataDidFail( string error )
	{
		if( retrieveAchievementMetadataFailed != null )
			retrieveAchievementMetadataFailed( error );
	}
	
	
	public void achievementMetadataDidLoad( string jsonAchievementDescriptionList )
	{
		List<GameCenterAchievementMetadata> list = GameCenterAchievementMetadata.fromJSON( jsonAchievementDescriptionList );
		
		if( achievementMetadataLoaded != null )
			achievementMetadataLoaded( list );
	}
	
	#endregion;

}