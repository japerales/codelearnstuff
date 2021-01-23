using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DesignPatterns.Command
{
public class TurnOnCommand : Command
{
	public TurnOnCommand(RemoteControlDevice receiver) : base (receiver)
	{}
	
	public override void Execute()
	{
		m_Receiver.TurnOn();
	}
}
}