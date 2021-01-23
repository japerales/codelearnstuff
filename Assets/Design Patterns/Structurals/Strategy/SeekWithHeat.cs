using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//implementación de la estrategia: la busqueda será mediante ondas de calor.
public class SeekWithHeat : ISeekBehaviour
{
	public void Seek()
	{
		Debug.Log("Seeking with heat");
	}
}
