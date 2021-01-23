using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateableTestComponent : UpdateableComponent
{
    public override void Initialize()
	{
		
	}

	public override void OnUpdate(float dt)
	{
		Debug.Log("Optimal object call");
	}
	
	
	
}
