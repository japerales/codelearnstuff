using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.State
{
	
public class Client : MonoBehaviour
{
	public Ship ship;

	void Update()
	{
		if (Input.GetKeyDown("n"))
		{
			ship.Normalize();
		}

		if (Input.GetKeyDown("a"))
		{
			ship.TriggerRedAlert();
		}

		if (Input.GetKeyDown("d"))
		{
			ship.DisableShip();
		}
	}
}

}
