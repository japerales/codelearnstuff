using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.ObjectPool{

public class ObjectPool : SingletonComponent<ObjectPool>
{
	public static ObjectPool Instance { get{ return (ObjectPool)_Instance;}}
	
	// The objects to pool.
	public GameObject[] objects;

	// The list of pooled objects.
	public List<GameObject>[] pooledObjects;

	// The amount of objects to buffer.
	public int[] amountToBuffer;

	public int defaultBufferAmount = 3;

	// The container of pooled objects.
	protected GameObject containerObject;

	void Start()
	{
		containerObject = new GameObject("ObjectPool");
		pooledObjects = new List<GameObject>[objects.Length];

		int i = 0;
		foreach (GameObject obj in objects)
		{
			pooledObjects[i] = new List<GameObject>();

			int bufferAmount;

			if (i < amountToBuffer.Length)
			{
				bufferAmount = amountToBuffer[i];
			}
			else
			{
				bufferAmount = defaultBufferAmount;
			}

			for (int n = 0; n < bufferAmount; n++)
			{
				GameObject newObj = Instantiate(obj) as GameObject;
				newObj.name = obj.name;
				PoolObject(newObj);
			}

			i++;
		}
	}

	// Pull an object of a specific type from the pool.
	public GameObject PullObject(string objectType)
	{
		bool onlyPooled = false;
		for (int i = 0; i < objects.Length; i++)
		{
			//itera la lista de objectos
			GameObject prefab = objects[i];
			
			//si el tipo de objeto es el que buscamos... (allocation ahi)
			if (prefab.name == objectType)
			{
				//Si la pool tiene objetos... (puede no tener porque esta pool se vacía)
				if (pooledObjects[i].Count > 0)
				{
					//coge el primer elemento de la pool
					GameObject pooledObject = pooledObjects[i][0];
					pooledObject.SetActive(true);
					pooledObject.transform.parent = null; //lo saca fuera del padre ObjectPool

					pooledObjects[i].Remove(pooledObject); //lo quita de la lista.

					return pooledObject;
				}
				else if (!onlyPooled)
				{
					return Instantiate(objects[i]) as GameObject;
				}

				break;
			}
		}

		// Null if there's a hit miss.
		return null;
	}

	// Add object of a specific type to the pool.
	public void PoolObject(GameObject obj)
	{
		for (int i = 0; i < objects.Length; i++)
		{
			if (objects[i].name == obj.name)
			{
				obj.SetActive(false);
				obj.transform.parent = containerObject.transform;
				pooledObjects[i].Add(obj);
				return;
			}
		}

		Destroy(obj);
	}
}
}