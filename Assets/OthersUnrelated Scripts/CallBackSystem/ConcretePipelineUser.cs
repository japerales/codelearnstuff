using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcretePipelineUser : CallBackSystem
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

	protected override void OnUpdate(float dt)
	{
		//Called on everyUpdate
		Debug.Log("Called once per Update");
		//Podemos usar expresiones lambda pero son muy lentas
		//FunctionWithCallBackArgument((boolArg) =>{ boolArg =!boolArg; });
		FunctionWithCallBackArgument(CallBackAsParameterFunction);
	}
	
	protected override void CallBackFromInheritanceInsideThePipeline1()
	{
		Debug.Log("This is the callBack");
	}
	
	void CallBackAsParameterFunction(bool param)
	{
		Debug.Log("The value is " + param + "and this is called as callback param");
		
	}
}
