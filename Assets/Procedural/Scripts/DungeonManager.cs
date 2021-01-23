using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public enum TileType
{
	essential, random, empty
}

public class DungeonManager : MonoBehaviour {

	[Serializable]
	public class PathTile {

		public TileType type;
		public Vector2 position;
		public List<Vector2> adjacentPathTiles;

		public PathTile (TileType t, Vector2 p, int min, int max, Dictionary<Vector2, TileType> currentTiles) {
			type = t;
			position = p;
			adjacentPathTiles = getAdjacentPath(min, max, currentTiles);
		}

		//añade a la lista los tiles adyacentes que aun no están registrados en el grid.
		public List<Vector2> getAdjacentPath(int minBound, int maxBound, Dictionary<Vector2, TileType> currentTiles) {
			List<Vector2> pathTiles = new List<Vector2> ();
			if (position.y + 1 < maxBound && !currentTiles.ContainsKey(new Vector2(position.x, position.y + 1))) {
				pathTiles.Add(new Vector2(position.x, position.y + 1));
			}
			if (position.x + 1 < maxBound && !currentTiles.ContainsKey(new Vector2(position.x + 1, position.y))) {
				pathTiles.Add(new Vector2(position.x + 1, position.y));
			}
			if (position.y - 1 > minBound && !currentTiles.ContainsKey(new Vector2(position.x, position.y - 1))) {
				pathTiles.Add(new Vector2(position.x, position.y - 1));
			}
			if (position.x - 1 >= minBound && !currentTiles.ContainsKey(new Vector2(position.x - 1, position.y)) && type != TileType.essential) {
				pathTiles.Add(new Vector2(position.x - 1, position.y));
			}
			return pathTiles;
		}
	}

	//guarda el grid. Los grid para comprobar el contenido (contains) es instantaneo.
	public Dictionary<Vector2, TileType> gridPositions = new Dictionary<Vector2, TileType> ();

	//limite por la izq y derecha (posición mínima y máxima en x).
	public int minBound = 0, maxBound;

	public static Vector2 startPos;

	public Vector2 endPos;

	public void StartDungeon () {
		Random.InitState(1);
		gridPositions.Clear ();
		maxBound = Random.Range (50, 101);

		BuildEssentialPath ();

		BuildRandomPath ();
	}

	private void BuildEssentialPath () {
		//elejimos un tile random a la izquierda del todo.
		int randomY = Random.Range (0, maxBound + 1);
		PathTile ePath = new PathTile (TileType.essential, new Vector2 (0, randomY), minBound, maxBound, gridPositions);
		//posición de comienzo.
		startPos = ePath.position;
		
		//cada vez que nos movemos a la derecha boundTracker aumenta en uno.
		int boundTracker = 0;

		//mientras que no alcancemos el final (a la derecha)
		while (boundTracker < maxBound) {

			//añadimos la posición actual
			gridPositions.Add (ePath.position, TileType.empty);

			//vemos los tiles adyacentes que aun no están en el grid.
			int adjacentTileCount = ePath.adjacentPathTiles.Count;

			//elegimos uno.
			int randomIndex = Random.Range (0, adjacentTileCount);

			//hasta que no lleguemos al final, debe haber siempre tiles disponibles, si no hay, pues break y termina el loop.
			Vector2 nextEPathPos;
			if (adjacentTileCount > 0) {
				//elejimos un tile aleatorio.
				nextEPathPos = ePath.adjacentPathTiles[randomIndex];
			} else {
				break;
			}

			//Creamos el tile.
			PathTile nextEPath = new PathTile (TileType.essential, nextEPathPos, minBound, maxBound, gridPositions);
			//si avanzamos a la derecha, actualizamos el tracker.
			if (nextEPath.position.x > ePath.position.x || (nextEPath.position.x == maxBound - 1 && Random.Range (0,2) == 1)) { // Update boundtracker before EPath update
				++boundTracker;
			} 
			//y confirmamos el nuevo ePath.
			ePath = nextEPath;
		}

		//si el loop se rompe antes de tiempo en el break, comprobamos que hemos añadido el último tile.
		if (!gridPositions.ContainsKey (ePath.position))
			gridPositions.Add (ePath.position, TileType.empty);

		endPos = new Vector2 (ePath.position.x, ePath.position.y);

	}

	//esta función recorre el essential path y crea caminos alternativos.
	private void BuildRandomPath () {

		//copiamos el essential path
		List<PathTile> pathQueue = new List<PathTile> ();
		foreach (KeyValuePair<Vector2,TileType> tile in gridPositions) {
			Vector2 tilePos = new Vector2(tile.Key.x, tile.Key.y);
			pathQueue.Add(new PathTile(TileType.random, tilePos, minBound, maxBound, gridPositions));
		}

		//ejecuta el delegado en cada elemento de la lista
		for(int i=0; i<pathQueue.Count; i++) {
			PathTile tile = pathQueue[i];
			//comprueba si quedan tiles adyacentes para crear un camino...
			int adjacentTileCount = tile.adjacentPathTiles.Count;
			if (adjacentTileCount != 0) {
				if (Random.Range(0, 5) == 1) {
					BuildRandomChamber (tile); //con una probabilidad del 20% creará un chamber.
				}
				//si no, intenta extender un camino: si existen tiles adyacentes donde extenderse, con un 20% de probabilidad lo  hará
				else if (Random.Range (0, 5) == 1 || (tile.type == TileType.random && adjacentTileCount > 1)) { 

					int randomIndex = Random.Range (0, adjacentTileCount);

					Vector2 newRPathPos = tile.adjacentPathTiles[randomIndex];
					//añadimos el nuevo tile al grid...
					if (!gridPositions.ContainsKey(newRPathPos)) {
						gridPositions.Add (newRPathPos, TileType.empty);
						//y a la cola, para ver si seguimos extendiéndolo.
						PathTile newRPath = new PathTile (TileType.random, newRPathPos, minBound, maxBound, gridPositions);
						pathQueue.Add (newRPath);
					}
				}
			}
		}
	}

	//construye una room
	private void BuildRandomChamber (PathTile tile) {
		int chamberSize = 3,
			adjacentTileCount = tile.adjacentPathTiles.Count,
			randomIndex = Random.Range (0, adjacentTileCount);
		Vector2 chamberOrigin = tile.adjacentPathTiles[randomIndex];

		for (int x = (int) chamberOrigin.x; x < chamberOrigin.x + chamberSize; x++) {
			for (int y = (int) chamberOrigin.y; y < chamberOrigin.y + chamberSize; y++) {
				Vector2 chamberTilePos = new Vector2 (x, y);
				if (!gridPositions.ContainsKey(chamberTilePos) && 
				    chamberTilePos.x < maxBound && chamberTilePos.x > 0 &&
				    chamberTilePos.y < maxBound && chamberTilePos.y > 0)

					gridPositions.Add (chamberTilePos, TileType.empty);
			}
		}
	}
}
