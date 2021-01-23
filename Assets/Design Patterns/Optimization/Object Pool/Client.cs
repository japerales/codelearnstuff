using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.ObjectPool{
public class Client : MonoBehaviour
{
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.G))
		{
			GameObject walker = ObjectPool.Instance.PullObject("Walker");
			walker.transform.Translate(Vector3.forward * Random.Range(-5.0f, 5.0f));
			walker.transform.Translate(Vector3.right * Random.Range(-5.0f, 5.0f));
		}

		if (Input.GetKeyDown(KeyCode.P))
		{
			object[] objs = GameObject.FindObjectsOfType(typeof(GameObject));

			foreach (object o in objs)
			{
				GameObject obj = (GameObject)o;

				if (obj.gameObject.GetComponent<Walker>() != null)
				{
					ObjectPool.Instance.PoolObject(obj);
				}
			}
		}
	}
}
}