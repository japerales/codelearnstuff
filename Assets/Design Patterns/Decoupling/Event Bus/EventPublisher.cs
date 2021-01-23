using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.EventBus{

public class EventPublisher : MonoBehaviour
{
	void Update()
	{
		if (Input.GetKeyDown("s"))
		{
			EventBus.Instance.TriggerEvent("Shoot");
		}

		if (Input.GetKeyDown("l"))
		{
			EventBus.Instance.TriggerEvent("Launch");
		}
	}
}
}