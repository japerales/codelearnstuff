using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerWithMessagesComponent : MonoBehaviour
{
    // Start is called before the first frame update
	private List<GameObject> _enemies = new List<GameObject>();
	[SerializeField] private GameObject _enemyPrefab;

	void Start() {
        //nos apuntamos mensaje
		MessagingSystem.Instance.AttachListener(typeof(CreateEnemyMessage), 
			HandleCreateEnemy);
   
    }

	bool HandleCreateEnemy(Message msg) {
		CreateEnemyMessage castMsg = msg as CreateEnemyMessage;
		string[] names = { "Tom", "Dick", "Harry" };
		GameObject enemy = Instantiate(_enemyPrefab, 
			5.0f * Random.insideUnitSphere, 
			Quaternion.identity);
		string enemyName = names[Random.Range(0, names.Length)];
		enemy.gameObject.name = enemyName;
		_enemies.Add(enemy);
        //a su vez este mensaje encola otro
		MessagingSystem.Instance.QueueMessage(new EnemyCreatedMessage(enemy, 
			enemyName));
		return true;
	}

    void OnDestroy()
    {
        if (MessagingSystem.IsAlive)
        {
            MessagingSystem.Instance.DetachListener(typeof(EnemyCreatedMessage),
                                                    HandleCreateEnemy);
        }
    }
}


