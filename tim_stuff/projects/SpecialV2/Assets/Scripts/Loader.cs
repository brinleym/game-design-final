using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

	public int rows, cols;
	public GameObject tile;
	public GameObject wall;
	public GameObject player;
	public GameObject[] boxList;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < cols; i++)
		{
			for (int j = 0; j < rows; j++)
			{
				if (i == 0 || i == cols - 1 || j == 0 || j == rows - 1)
					Instantiate(wall, new Vector3(i, j, 0f), Quaternion.identity);
				else
					Instantiate(tile, new Vector3(i, j, 0f), Quaternion.identity);
			}
		}

		Instantiate(player, new Vector3(1, 1, 0f), Quaternion.identity);
		Instantiate(boxList[0], new Vector3(4, 4, 0f), Quaternion.identity);
		Instantiate(boxList[1], new Vector3(5, 5, 0f), Quaternion.identity);
		Instantiate(boxList[2], new Vector3(6, 4, 0f), Quaternion.identity);
	}

}
