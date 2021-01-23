using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//implementación de la estrategia: la busqueda será mediante sonar
public class SeekWithSonar : ISeekBehaviour
{
	
	public void Seek()
	{
		Debug.Log("Seeking with Sonar");
	}
}
