using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.ServiceLocator{
public class Client : MonoBehaviour
{
	void Update()
	{
		if (Input.GetKeyDown("o"))
		{
			ServiceLocator.Instance.GetService<LightingCoordinator>
			().TurnOffLights();
		}

		if (Input.GetKeyDown("c"))
		{
			ServiceLocator.Instance.GetService<CurrencyConverter>
			().ConvertToUsDollar(10);
		}

		if (Input.GetKeyDown("l"))
		{
			ServiceLocator.Instance.GetService<LobbyCoordinator>
			().AddPlayerToLobby();
		}
	}
}
}