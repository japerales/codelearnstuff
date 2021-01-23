using UnityEngine;


public class CreateEnemyMessage : Message {}

//un mensaje es un contenedor de datos que empaqueta información que se manda a otro elemento.
public class EnemyCreatedMessage : Message {

	//hacer los mensajes readonly es bueno, nos aseguramos de que no sean alterados
	public readonly GameObject enemyObject;
	public readonly string enemyName;
	

	public EnemyCreatedMessage(GameObject enemyObject, string enemyName) {
		this.enemyObject = enemyObject;
		this.enemyName = enemyName;
	}
}



