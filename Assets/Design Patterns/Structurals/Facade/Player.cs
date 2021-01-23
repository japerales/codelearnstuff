using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Facade{

public class Player
{
	public int GetHealth()
	{
		return 10;
	}
	
	public int GetPlayerID()
	{
		return 007;
	}
}

	[System.Serializable]
	class PlayerData
	{
		public int score;
		public int playerID;
		public float health;
	}

}