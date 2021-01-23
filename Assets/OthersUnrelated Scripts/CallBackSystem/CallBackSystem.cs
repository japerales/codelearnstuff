using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CallBackSystem : MonoBehaviour
{
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
    	{
    		//call all the system
    		ClosedMethodOfThePipeline1();
			ClosedMethodOfThePipeline2();
			CallBackFromInheritanceInsideThePipeline1();
    		
    	}
    	
		OnUpdate(Time.deltaTime);
	}
    
    
    
	void ClosedMethodOfThePipeline1()
	{
		
		Debug.Log("ClosedMethodOfThePipeline1");
	}
    
	void ClosedMethodOfThePipeline2()
	{
		
		Debug.Log("ClosedMethodOfThePipeline2");
	}
    
	//called in the update
	protected virtual void OnUpdate(float dt){}
	
	//called when Input Event
	protected virtual void CallBackFromInheritanceInsideThePipeline1(){} 
	
	protected void FunctionWithCallBackArgument(Action<bool> action)
	{
		bool argument = false;
		Debug.Log("We call the first part of the function");
		action.Invoke(argument);
	}
}
