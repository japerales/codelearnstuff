using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//imeplementación de la estrategia: la busqueda va a ser mediante GPS
public class SeekWithGPS : ISeekBehaviour
{
	
	public void Seek()
	{
		Debug.Log("Seeking with GPS");
	}
}
