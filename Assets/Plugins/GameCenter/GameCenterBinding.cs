using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;


public enum GameCenterLeaderboardTimeScope
{
	Today = 0,
	Week,
	AllTime
};


// All Objective-C exposed methods should be bound here
public class GameCenterBinding
{
    [DllImport("__Internal")]
    private static extern bool _gameCenterIsGameCenterAvailable();

	// Checks to see if GameCenter is available on the current device and iOS version
    public static bool isGameCenterAvailable()
    {
        // Call plugin only when running on real device
        if( Application.platform == RuntimePlatform.IPhonePlayer )
			return _gameCenterIsGameCenterAvailable();
		return false;
    }
	
	
	#region Player methods
	
	[DllImport("__Internal")]
    private static extern void _gameCenterAuthenticateLocalPlayer();

	// Authenticates the player.  This needs to be called before using anything in GameCenter and should
	// preferalbly be called shortly after application launch.
    public static void authenticateLocalPlayer()
    {
        // Call plugin only when running on real device
        if( Application.platform == RuntimePlatform.IPhonePlayer )
			_gameCenterAuthenticateLocalPlayer();
    }
	
	
    [DllImport("__Internal")]
    private static extern bool _gameCenterIsPlayerAuthenticated();

	// Checks to see if the current player is authenticated.
	public static bool isPlayerAuthenticated()
    {
        // Call plugin only when running on real device
        if( Application.platform == RuntimePlatform.IPhonePlayer )
			return _gameCenterIsPlayerAuthenticated();
		return false;
    }
	
	
    [DllImport("__Internal")]
    private static extern string _gameCenterPlayerAlias();

	// Gets the alias of the current player.
    public static string playerAlias()
    {
        // Call plugin only when running on real device
        if( Application.platform == RuntimePlatform.IPhonePlayer )
			return _gameCenterPlayerAlias();
		return string.Empty;
    }
	

    [DllImport("__Internal")]
    private static extern string _gameCenterPlayerIdentifier();

	// Gets the playerIdentifier of the current player.
    public static string playerIdentifier()
    {
        // Call plugin only when running on real device
        if( Application.platform == RuntimePlatform.IPhonePlayer )
			return _gameCenterPlayerIdentifier();
		return string.Empty;
    }
	
	
    [DllImport("__Internal")]
    private static extern bool _gameCenterIsUnderage();

	// Checks to see if the current player is underage.
    public static bool isUnderage()
    {
        // Call plugin only when running on real device
        if( Application.platform == RuntimePlatform.IPhonePlayer )
			return _gameCenterIsUnderage();
		return false;
    }
	
	
    [DllImport("__Internal")]
    private static extern void _gameCenterRetrieveFriends();

	// Sends off a request to get the current users friend list
    public static void retrieveFriends()
    {
        // Call plugin only when running on real device
        if( Application.platform == RuntimePlatform.IPhonePlayer )
			_gameCenterRetrieveFriends();
    }


    [DllImport("__Internal")]
    private static extern void _gameCenterLoadPlayerData( string playerIds );

	// Gets GameCenterPlayer objects for all the given playerIds
    public static void loadPlayerData( string[] playerIdArray )
    {
        if( Application.platform == RuntimePlatform.IPhonePlayer )
			_gameCenterLoadPlayerData( string.Join( ",", playerIdArray ) );
    }

	#endregion;
	
	
	#region Leaderboard methods
	
    [DllImport("__Internal")]
    private static extern void _gameCenterLoadLeaderboardLeaderboardTitles();

	// Sends off a request to get all the currently live leaderboards including leaderboardId and title.
    public static void loadLeaderboardTitles()
    {
        // Call plugin only when running on real device
        if( Application.platform == RuntimePlatform.IPhonePlayer )
			_gameCenterLoadLeaderboardLeaderboardTitles();
    }


    [DllImport("__Internal")]
    private static extern void _gameCenterReportScore( System.Int64 score, string leaderboardId );

	// Reports a score for the given leaderboardId.
    public static void reportScore( System.Int64 score, string leaderboardId )
    {
        // Call plugin only when running on real device
        if( Application.platform == RuntimePlatform.IPhonePlayer )
			_gameCenterReportScore( score, leaderboardId );
    }


    [DllImport("__Internal")]
    private static extern void _gameCenterShowLeaderboardWithTimeScope( int timeScope );

	// Shows the standard GameCenter leaderboard with the given time scope.
    public static void showLeaderboardWithTimeScope( GameCenterLeaderboardTimeScope timeScope )
    {
        // Call plugin only when running on real device
        if( Application.platform == RuntimePlatform.IPhonePlayer )
			_gameCenterShowLeaderboardWithTimeScope( (int)timeScope );
    }


    [DllImport("__Internal")]
    private static extern void _gameCenterShowLeaderboardWithTimeScopeAndLeaderboardId( int timeScope, string leaderboardId );

	// Shows the standard GameCenter leaderboard for the given leaderboardId with the given time scope.
    public static void showLeaderboardWithTimeScopeAndLeaderboard( GameCenterLeaderboardTimeScope timeScope, string leaderboardId )
    {
        // Call plugin only when running on real device
        if( Application.platform == RuntimePlatform.IPhonePlayer )
			_gameCenterShowLeaderboardWithTimeScopeAndLeaderboardId( (int)timeScope, leaderboardId );
    }


    [DllImport("__Internal")]
    private static extern void _gameCenterRetrieveScores( bool friendsOnly, int timeScope, int start, int end );

	// Sends a request to get the current scores with the given criteria.  Start and end MUST be between 1 and 100 inclusive.
    public static void retrieveScores( bool friendsOnly, GameCenterLeaderboardTimeScope timeScope, int start, int end )
    {
        // Call plugin only when running on real device
        if( Application.platform == RuntimePlatform.IPhonePlayer )
			_gameCenterRetrieveScores( friendsOnly, (int)timeScope, start, end );
    }
    
    
    [DllImport("__Internal")]
    private static extern void _gameCenterRetrieveScoresForLeaderboard( bool friendsOnly, int timeScope, int start, int end, string leaderboardId );

	// Sends a request to get the current scores with the given criteria.  Start and end MUST be between 1 and 100 inclusive.
    public static void retrieveScores( bool friendsOnly, GameCenterLeaderboardTimeScope timeScope, int start, int end, string leaderboardId )
    {
        // Call plugin only when running on real device
        if( Application.platform == RuntimePlatform.IPhonePlayer )
			_gameCenterRetrieveScoresForLeaderboard( friendsOnly, (int)timeScope, start, end, leaderboardId );
    }
    

    [DllImport("__Internal")]
    private static extern void _gameCenterRetrieveScoresForPlayerId( string playerId );

	// Sends a request to get the current scores for the given playerId.
    public static void retrieveScoresForPlayerId( string playerId )
    {
        // Call plugin only when running on real device
        if( Application.platform == RuntimePlatform.IPhonePlayer )
			_gameCenterRetrieveScoresForPlayerId( playerId );
    }
    
    
    [DllImport("__Internal")]
    private static extern void _gameCenterRetrieveScoresForPlayerIdAndLeaderboard( string playerId, string leaderboardId );

	// Sends a request to get the current scores for the given playerId and leaderboardId
    public static void retrieveScoresForPlayerId( string playerId, string leaderboardId )
    {
        // Call plugin only when running on real device
        if( Application.platform == RuntimePlatform.IPhonePlayer )
			_gameCenterRetrieveScoresForPlayerIdAndLeaderboard( playerId, leaderboardId );
    }

	#endregion;


	#region Achievement methods

    [DllImport("__Internal")]
    private static extern void _gameCenterReportAchievement( string identifier, float percent );

	// Reports an achievement with the given identifier and percent complete
    public static void reportAchievement( string identifier, float percent )
    {
        // Call plugin only when running on real device
        if( Application.platform == RuntimePlatform.IPhonePlayer )
			_gameCenterReportAchievement( identifier, percent );
    }


    [DllImport("__Internal")]
    private static extern void _gameCenterGetAchievements();

	// Sends a request to get a list of all the current achievements for the authenticated in player.
    public static void getAchievements()
    {
        // Call plugin only when running on real device
        if( Application.platform == RuntimePlatform.IPhonePlayer )
			_gameCenterGetAchievements();
    }


    [DllImport("__Internal")]
    private static extern void _gameCenterResetAchievements();

	// Resets all the achievements for the authenticated player.
    public static void resetAchievements()
    {
        // Call plugin only when running on real device
        if( Application.platform == RuntimePlatform.IPhonePlayer )
			_gameCenterResetAchievements();
    }


    [DllImport("__Internal")]
    private static extern void _gameCenterShowAchievements();

	// Shows the standard, GameCenter achievement list
    public static void showAchievements()
    {
        // Call plugin only when running on real device
        if( Application.platform == RuntimePlatform.IPhonePlayer )
			_gameCenterShowAchievements();
    }


    [DllImport("__Internal")]
    private static extern void _gameCenterRetrieveAchievementMetadata();

	// Sends a request to get the achievements for the current game.
    public static void retrieveAchievementMetadata()
    {
        // Call plugin only when running on real device
        if( Application.platform == RuntimePlatform.IPhonePlayer )
			_gameCenterRetrieveAchievementMetadata();
    }


	[DllImport("__Internal")]
	private static extern void _gameCenterShowCompletionBannerForAchievements();

	// Shows a completion banner for achievements if when reported they are at 100%.  Only has an effect on iOS 5+
    public static void showCompletionBannerForAchievements()
    {
        // Call plugin only when running on real device
        if( Application.platform == RuntimePlatform.IPhonePlayer )
			_gameCenterShowCompletionBannerForAchievements();
    }

	#endregion;

}