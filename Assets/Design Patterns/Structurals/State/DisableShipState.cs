using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.State{
	
	public class DisableShipState : IShipState
{
	public void Execute(Ship ship)
	{
		ship.LogStatus("DISABLED: crew jumping ship.");
	}
}
}