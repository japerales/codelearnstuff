using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonTestManager : SingletonComponent<SingletonTestManager>
{
	public static SingletonTestManager Instance {
		get { return ((SingletonTestManager)_Instance); }
		set { _Instance = value; }
	}
	
	public void UnregisterComponent(Component cp)
	{
		
		
	}
}
