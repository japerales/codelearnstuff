using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OctreeIndex
{
	UpperLeftFront = 101,
	UpperRightFront = 111,
	UpperRightBack = 110,
	UpperLeftBack = 100,
	BottomLeftFront = 001,
	BottomLeftBack = 000,
	BottomRightFront = 011,
	BottonRightBack = 010
}

public class Octree<T>
{
	private OctreeNode<T> node;
	private int depth; //nivel de profundidad del octree
	
	
	public Octree(Vector3 position, float size, int depth)
	{
		node = new OctreeNode<T>(position, size);
	}
	
	/// <summary>
	/// Dado un nodo y una posición cercana a ese nodo, indica el index al que pertenece (enum OctreeIndex)
	/// </summary>
	/// <param name="lookUpPosition">posición que buscamos</param>
	/// <param name="nodePosition">posición del nodo desde el que miro.</param>
	/// <returns></returns>
	private int GetIndexOfPosition(Vector3 lookUpPosition, Vector3 nodePosition){
		
		int index =0;
		
		//operador bitwise OR acumulativo: 100 : 000
		index |= lookUpPosition.y > nodePosition.y ? 4 : 0;
		//al resultado anterior se le aplica un OR: Ejemplo --> 100 | 010 => 110
		index |= lookUpPosition.x > nodePosition.x ? 2 : 0;
		index |= lookUpPosition.z > nodePosition.z ? 1 : 0;
		
		return index;
	}
	
	private class OctreeNode<T>
	{
		public OctreeNode(Vector3 position, float size)
		{
			
		}
		
		Vector3 position; //posición del cubo
		float size; //tamaño del cubo.
	
		//Estos subnodos son hijos del octree deben ser 8
		OctreeNode<T>[] subNodes;
	
		IList<T> value; //Estos son los elementos que contendrá un nodo del octree. 
		//No todos los nodos tienen elementos, solo aquellos que sean "nodos hoja".	
	}
}


