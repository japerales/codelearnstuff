using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//clase de ejecución, de testing
public class EnemyCreator : MonoBehaviour
{
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		InvokeRepeating("CreateEnemy", 1, 0.05f);
	}

	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			CreateEnemy();
	}
	
	void CreateEnemy()
	{
		MessagingSystem.Instance.QueueMessage(new CreateEnemyMessage()); 
	}
}
