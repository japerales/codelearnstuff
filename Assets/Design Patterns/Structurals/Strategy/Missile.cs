using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Es el misil el que ejecuta la estrategia, no la propia estrategia. Hay una variable asignada para la estrategia.
/// </summary>
public class Missile : ScriptableObject
{
	ISeekBehaviour _seekingSystem;
	
	
	public void SetBehaviour(ISeekBehaviour seekingSystem)
	{
		_seekingSystem = seekingSystem;
	}
	
	public void ApplySeek()
	{
		_seekingSystem.Seek();
	}
	
	public virtual void Launch()
	{
	}
	
}
