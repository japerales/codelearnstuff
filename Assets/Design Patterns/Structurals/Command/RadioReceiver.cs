using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
public class RadioReceiver : RemoteControlDevice
{
	public override void TurnOn()
	{
		Debug.Log("Radio is turned on.");
	}

	public override void TurnOff()
	{
		Debug.Log("Radio is turned off.");
	}
}
}