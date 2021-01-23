using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreatedListenerComponent : MonoBehaviour {
	void Start () {
        //Hay un problema: el sistema no registra listeners de objetos que aun no están en la escena. Cuidado con la creación de objetos en runtime!!
        MessagingSystem.Instance.AttachListener(typeof(EnemyCreatedMessage),
            HandleEnemyCreated);
    }
  
	bool HandleEnemyCreated(Message msg) {
		EnemyCreatedMessage castMsg = msg as EnemyCreatedMessage;
		//Debug.Log(string.Format("A new enemy was created! {0}", 
		//castMsg.enemyName));
		Destroy(gameObject,3);
		return true;
	}

    void OnDestroy()
    {
        if (MessagingSystem.IsAlive)
        {
            MessagingSystem.Instance.DetachListener(typeof(EnemyCreatedMessage),
                                                    HandleEnemyCreated);
        }
    }
}
