using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class GameCenterScore
{
	public string category;
	public string formattedValue;
	public int value;
	public DateTime date;
	public string playerId;
	public int rank;
	public bool isFriend;
	public string alias;
	
	
	public static List<GameCenterScore> fromJSON( string json )
	{
		var scoreList = new List<GameCenterScore>();
		
		// decode the json
		var list = json.arrayListFromJson();
		
		// create DTO's from the Hashtables
		foreach( Hashtable ht in list )
			scoreList.Add( new GameCenterScore( ht ) );
		
		return scoreList;
	}
	
	
	public GameCenterScore( Hashtable ht )
	{
		category = ht["category"] as string;
		formattedValue = ht["formattedValue"] as string;
		value = int.Parse( ht["value"].ToString() );
		playerId = ht["playerId"] as string;
		rank = int.Parse( ht["rank"].ToString() );
		isFriend = (bool)ht["isFriend"];
		alias = ht["alias"] as string;
		
		// grab and convert the date
		double timeSinceEpoch = double.Parse( ht["date"].ToString() );
		DateTime intermediate = new DateTime( 1970, 1, 1, 0, 0, 0, DateTimeKind.Utc );
		date = intermediate.AddSeconds( timeSinceEpoch );
	}
	
	
	public override string ToString()
	{
		 return string.Format( "<Score> category: {0}, formattedValue: {1}, date: {2}, rank: {3}, alias: {4}",
			category, formattedValue, date, rank, alias );
	}

}