using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Facade{
	
public class Client : MonoBehaviour
{
	private Player m_Player;

	void Start()
	{
		m_Player = new Player();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.S))
		{
			// Save the current player instance.
			SaveManager.Instance.SaveGame(m_Player);
		}
	}
}
}