using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneRandomEventHandler : MonoBehaviour
{
	
	// This function is called when the object becomes enabled and active.
	protected void OnEnable()
	{
		EventCreator.eventFoo+= EventHandler;	
	}
    
	private void EventHandler()
	{
		Debug.Log("Foo Managed");
	}
    
	// This function is called when the behaviour becomes disabled () or inactive.
	protected void OnDisable()
	{
		EventCreator.eventFoo-= EventHandler;	
	}
}
