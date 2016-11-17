using UnityEngine;
using System;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {

	public int rows = 8;
	public int cols = 8;
	public GameObject[] wallTiles;
	public GameObject[] floorTiles;
	public GameObject[] keyTiles;
	public GameObject[] boxTiles;

	private Transform boardHolder;
	//private List <Vector3> gridPositions = new List<Vector3>();

	void RoomSetup()
	{
		boardHolder = new GameObject ("Board").transform;

		for (int x = -1; x < cols + 1; x++) {
			for (int y = -1; y < rows + 1; y++) {

				GameObject toInstantiate = floorTiles [0];
				if (x == -1 || x == cols || y == -1 || y == rows)
					toInstantiate = wallTiles [0];

				GameObject instance = Instantiate (toInstantiate, new Vector3 (x, y, 0f),
					                      Quaternion.identity) as GameObject;

				instance.transform.SetParent (boardHolder);
			}
		}
	}

	void placeObjects()
	{
		int objectCount = keyTiles.Length;

		for (int i = 0; i < objectCount; i++) {
			GameObject tile = keyTiles[i];
			Instantiate (tile, new Vector3 (i*2 + 2, 4, 0f), Quaternion.identity);
		}

		Instantiate (boxTiles [0], new Vector3 (2, 3, 0f), Quaternion.identity);
		Instantiate (boxTiles [0], new Vector3 (3, 2, 0f), Quaternion.identity);
		Instantiate (boxTiles [0], new Vector3 (4, 3, 0f), Quaternion.identity);

		Instantiate (boxTiles [1], new Vector3 (1, 2, 0f), Quaternion.identity);
		Instantiate (boxTiles [1], new Vector3 (0, 3, 0f), Quaternion.identity);

		Instantiate (boxTiles [2], new Vector3 (5, 2, 0f), Quaternion.identity);
		Instantiate (boxTiles [2], new Vector3 (6, 3, 0f), Quaternion.identity);
		Instantiate (boxTiles [2], new Vector3 (7, 2, 0f), Quaternion.identity);

		Instantiate (boxTiles [3], new Vector3 (0, 7, 0f), Quaternion.identity);
		Instantiate (boxTiles [3], new Vector3 (7, 7, 0f), Quaternion.identity);
	}

	public void SetupScene()
	{
		RoomSetup();
		placeObjects();
	}
}
