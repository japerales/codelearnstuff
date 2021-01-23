using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Observer{
public class Notifier : MonoBehaviour
{
	void OnEnable()
	{
		Timer.OnTimerEnded += ShowGameOverPopUp;
	}

	void OnDisable()
	{
		Timer.OnTimerEnded -= ShowGameOverPopUp;
	}

	void ShowGameOverPopUp()
	{
		Debug.Log("[NOTIFIER] : Show game over pop up!");
	}
}
}