using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActionCallTest : MonoBehaviour
{
	//Devuelve un bool, manda un mensaje
	Func<Message, bool> Response;
	//Action<Message> Reaction;
	Message msg;
    // Start is called before the first frame update
    void Start()
	{
		msg = new Message();
	    Response+=TestResponse;
	    Response+=TestResponse2;
    }
    
    
	bool TestResponse(Message msg)
	{
		Debug.Log("TestResponse1");
		return false;
	}
	
	bool TestResponse2(Message msg)
	{
		Debug.Log("TestResponse2");
		return false;
	}
	
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Response(msg);
		}
	}  

}
