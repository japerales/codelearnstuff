using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.State{
	
	public class NormalShipState : IShipState
{
	public void Execute(Ship ship)
	{
		ship.LogStatus("NORMAL: ship operating as normal.");
	}
}
}