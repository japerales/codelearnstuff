using UnityEngine;
using System;
using System.Collections.Generic; 		//Allows us to use Lists.
using Random = UnityEngine.Random;      //Tells Random to use the Unity Engine random number generator.


public class BoardManager : MonoBehaviour
{
    // Using Serializable allows us to embed a class with sub properties in the inspector.
    [Serializable]
    public class Count
    {
        public int minimum;             //Minimum value for our Count class.
        public int maximum;             //Maximum value for our Count class.


        //Assignment constructor.
        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }
    public GameObject exit;
    public int columns = 5;
    public int rows = 5;
    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject[] outerWallTiles;
    private Transform boardHolder;
    private Transform dungeonBoardHolder;
    private Dictionary<Vector2, Vector2> gridPositions = new Dictionary<Vector2, Vector2>();
	private Dictionary<Vector2, Vector2> dungeonGridPositions;
    
    public void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;

        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                gridPositions.Add(new Vector2(x, y), new Vector2(x, y));

                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
            }
        }
    }

    public void addToBoard(int horizontal, int vertical)
    {
        int frontalSight = 3;
        int sideSight = 2;

        if (horizontal == 1)
        {
            //Check if tiles exist
            int x = (int)Player.position.x;
            //visión por delante: 3 unidades
            int sightX = x + frontalSight;
            //tileamos una posición por delante del player
            for (x += 1; x <= sightX; x++)
            {
                int y = (int)Player.position.y;
                //visión lateral, 5 unidades:
                //2x izquierda, central y 2xDerecha
                int sightY = y + sideSight;
                for (y -= sideSight; y <= sightY; y++)
                {
                    addTiles(new Vector2(x, y));
                }
            }
        }
        else if (horizontal == -1)
        {
            int x = (int)Player.position.x;
            int sightX = x - frontalSight;
            for (x -= 1; x >= sightX; x--)
            {
                int y = (int)Player.position.y;
                int sightY = y + sideSight;
                for (y -= sideSight; y <= sightY; y++)
                {
                    addTiles(new Vector2(x, y));
                }
            }
        }
        else if (vertical == 1)
        {
            int y = (int)Player.position.y;
            int sightY = y + frontalSight;
            for (y += 1; y <= sightY; y++)
            {
                int x = (int)Player.position.x;
                int sightX = x + sideSight;
                for (x -= sideSight; x <= sightX; x++)
                {
                    addTiles(new Vector2(x, y));
                }
            }
        }
        else if (vertical == -1)
        {
            int y = (int)Player.position.y;
            int sightY = y - frontalSight;
            for (y -= 1; y >= sightY; y--)
            {
                int x = (int)Player.position.x;
                int sightX = x + sideSight;
                for (x -= sideSight; x <= sightX; x++)
                {
                    addTiles(new Vector2(x, y));
                }
            }
        }
    }

    //función que pinta el board del world
	private void addTiles(Vector2 tileToAdd) {
	 if (!gridPositions.ContainsKey (tileToAdd)) {
		   gridPositions.Add (tileToAdd, tileToAdd);
			    GameObject toInstantiate = floorTiles [Random.Range (0, floorTiles.Length)];
		    GameObject instance = Instantiate (toInstantiate, new Vector3 (tileToAdd.x, tileToAdd.y, 0f), Quaternion.identity) as GameObject;
		    instance.transform.SetParent (boardHolder);
		    
		     if (Random.Range (0, 3) == 1) {
		       toInstantiate = wallTiles[Random.Range (0,wallTiles.Length)];
			     instance = Instantiate (toInstantiate, new Vector3 (tileToAdd.x, tileToAdd.y, 0f), Quaternion.identity) as GameObject;
			      instance.transform.SetParent (boardHolder);
			    }
		     //pinta una entrada a la dungeon
		     if (Random.Range (0, 100) == 1) {
		      toInstantiate = exit;
			     instance = Instantiate (toInstantiate, new Vector3 (tileToAdd.x, tileToAdd.y, 0f), Quaternion.identity) as GameObject;
			      instance.transform.SetParent (boardHolder);
		    }
		   }
	 }
    
	//pinta el Board en función de la información del dictionary que se le pasa (y se ha creado en el dungeonManager).
	public void SetDungeonBoard (Dictionary<Vector2,TileType> dungeonTiles, int bound, Vector2 endPos) {
		    boardHolder.gameObject.SetActive (false); //desactivamos el board del mundo
		    dungeonBoardHolder = new GameObject ("Dungeon").transform; //creamos un dungeon board
            dungeonBoardHolder.hierarchyCapacity = 10000;
		    GameObject toInstantiate, instance;
 
		    foreach(KeyValuePair<Vector2,TileType> tile in dungeonTiles) {
			      toInstantiate = floorTiles [Random.Range (0, floorTiles.Length)];
			      instance = Instantiate (toInstantiate, new Vector3 (tile.Key.x, tile.Key.y, 0f), Quaternion.identity) as GameObject;
			      instance.transform.SetParent (dungeonBoardHolder);
			    }

		    for (int x = -1; x < bound + 1; x++) {
			     for (int y = -1; y < bound + 1; y++) {
				        if (!dungeonTiles.ContainsKey(new Vector2(x, y))) {
					        toInstantiate = outerWallTiles [Random.Range (0, outerWallTiles.Length)];
					          instance = Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
					          instance.transform.SetParent (dungeonBoardHolder);
					        }
				      }
			    }
		
		    toInstantiate = exit;
		    instance = Instantiate (toInstantiate, new Vector3 (endPos.x, endPos.y, 0f), Quaternion.identity) as GameObject;
		    instance.transform.SetParent (dungeonBoardHolder);
		  }

	 public void SetWorldBoard () {
		    Destroy (dungeonBoardHolder.gameObject);
		    boardHolder.gameObject.SetActive (true);
		  }

}
