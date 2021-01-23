using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Observer{

public class Buzer : MonoBehaviour
{
	void OnEnable()
	{
		Timer.OnTimerStarted += PlayStartBuzzer;
		Timer.OnTimerEnded += PlayEndBuzzer;
	}

	void OnDisable()
	{
		Timer.OnTimerStarted -= PlayStartBuzzer;
		Timer.OnTimerEnded -= PlayEndBuzzer;
	}

	void PlayStartBuzzer()
	{
		Debug.Log("[BUZZER] : Play start buzzer!");
	}

	void PlayEndBuzzer()
	{
		Debug.Log("[BUZZER] : Play end buzzer!");
	}
}
}