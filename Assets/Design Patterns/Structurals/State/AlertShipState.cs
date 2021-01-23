using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.State{
	
	public class AlertShipState : IShipState
{
    // Start is called before the first frame update
	public void Execute(Ship ship)
	{
		ship.LogStatus("ALERT: all hands on deck.");
	}
	
	
}

}