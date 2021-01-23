using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateableComponent : MonoBehaviour, IUpdateable
{
	// Start is called before the first frame update
	void Start()
	{
		GameLogic.Instance.RegisterUpdateableObject(this);
		Initialize();
	}
	
	public virtual void Initialize()
	{
		
	}
	//esta función no será invocada, al ser virtual.
	//Serán los hijos de esta clase quienes llamen a esta función
	public virtual void OnUpdate(float dt){	}
	
	// This function is called when the MonoBehaviour will be destroyed.
	private void OnDestroy()
	{		
		if(GameLogic.IsAlive)
			GameLogic.Instance.DeregisterUpdateableObject(this);
			
	}
}
