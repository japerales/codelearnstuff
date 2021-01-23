using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
public class TurnOffCommand : Command
{
	TurnOffCommand(RemoteControlDevice receiver) : base (receiver)
	{}
	
	public override void Execute()
	{
		m_Receiver.TurnOff();
	}
}
}