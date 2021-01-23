using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonUserComponent : MonoBehaviour
{
    
	void OnDestroy()
	{
		if (SingletonTestManager.IsAlive)
		{
			SingletonTestManager.Instance.UnregisterComponent(this);
			
		}
		
	}
}
