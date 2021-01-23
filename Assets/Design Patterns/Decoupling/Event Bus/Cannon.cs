using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.EventBus{

public class Cannon : MonoBehaviour
{
	private bool m_IsQuitting;

	void OnEnable()
	{
		EventBus.Instance.StartListening("Shoot", Shoot);
	}

	void OnApplicationQuit()
	{
		m_IsQuitting = true;
	}

	void OnDisable()
	{
		if (m_IsQuitting == false)
		{
			EventBus.Instance.StopListening("Shoot", Shoot);
		}
	}

	void Shoot()
	{
		Debug.Log("Received a shoot event : shooting cannon!");
	}
}
}