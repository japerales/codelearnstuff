using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class TimerTest : MonoBehaviour
{
	Stopwatch timer;
	float coolDown = 2;
    // Start is called before the first frame update
    void Start()
    {
	    timer = new Stopwatch();
	    timer.Start();
    }

    // Update is called once per frame
    void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space)){
			float et = timer.ElapsedMilliseconds/1000f;
			if (et > coolDown)
			{
				UnityEngine.Debug.Log(et);
				timer.Restart();
			}
		}
    }
}
