using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCreator : MonoBehaviour
{
	public delegate void Foo();
	public static event Foo eventFoo;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	    	if (eventFoo!=null)
	    	{
	    		eventFoo();
	    	}
	    	
	    }
    }
}
