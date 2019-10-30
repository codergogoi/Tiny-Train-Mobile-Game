using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameCenterPlayer
{
	public string playerId;
	public string alias;
	public bool isFriend;
	
	
	public static List<GameCenterPlayer> fromJSON( string json )
	{
		List<GameCenterPlayer> scoreList = new List<GameCenterPlayer>();
		
		// decode the json
		var list = json.arrayListFromJson();
		
		// create DTO's from the Hashtables
		foreach( Hashtable ht in list )
			scoreList.Add( new GameCenterPlayer( ht ) );
		
		return scoreList;
	}
	
	
	public GameCenterPlayer( Hashtable ht )
	{
		playerId = ht["playerId"] as string;
		alias = ht["alias"] as string;
		isFriend = (bool)ht["isFriend"];
	}
	
	
	public override string ToString()
	{
		 return string.Format( "<Player> playerId: {0}, alias: {1}, isFriend: {2}", playerId, alias, isFriend );
	}

}