using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Facade{
	
	public class ScoreManager
	{
		public int GetScore(int playerId)
		{
			Debug.Log("Returning player score.");
			return 0;
		}
	}
	
	public class CloudManager
	{
		public void UploadSaveGame(string playerData)
		{
			Debug.Log("Uploading save data.");
		}
	}
	
	public class UIManager
	{
		public void DisplaySaveIcon()
		{
			Debug.Log("Displaying the save icon.");
		}
	}
	
}
