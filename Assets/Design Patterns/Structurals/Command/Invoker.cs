using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
public class Invoker
{
	private Command m_Command;

	public void SetCommand(Command command)
	{
		m_Command = command;
	}

	public void ExecuteCommand()
	{
		m_Command.Execute();
	}
}
}