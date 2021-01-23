using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.ServiceLocator{
	

    // Start is called before the first frame update
	public class CurrencyConverter
	{
		public void ConvertToUsDollar(int inGameCurrency)
		{
			Debug.Log("Players in-game currency is worth 100$ US");
		}
	}
	
	public class LightingCoordinator
	{
		public void TurnOffLights()
		{
			Debug.Log("Turning off all the lights.");
		}
	}
	
	public class LobbyCoordinator
	{
		public void AddPlayerToLobby()
		{
			Debug.Log("Adding a player to the lobby.");
		}
	}

}