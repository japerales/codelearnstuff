using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
public abstract class Command 
{
	protected RemoteControlDevice m_Receiver;
	
	public Command(RemoteControlDevice receiver)
	{
		m_Receiver = receiver;
	}
	
	public abstract void Execute();
}
}