using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

	public int rows, cols;
	public GameObject player1;
	public GameObject player2;
	public GameObject player3;

	public GameObject door, exit;
	public GameObject[] floor;
	public GameObject[] wall;
	public GameObject[] boxList;
	public GameObject[] keys;
	public GameObject[] locks;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < cols; i++)
		{
			for (int j = 0; j < rows; j++)
			{
				if (i == 0 || i == cols - 1 || j == 0 || j == rows - 1) {
					if (i == 5 && j == 9) {
					} 
					else 
						Instantiate(wall[1], new Vector3 (i, j, 0f), Quaternion.identity);
				}
				else
					Instantiate(floor[1], new Vector3(i, j, 0f), Quaternion.identity);
			}
		}

		Instantiate(player1, new Vector3(5, 1, 0f), Quaternion.identity);
		Instantiate(player2, new Vector3(6, 1, 0f), Quaternion.identity);
		Instantiate(player3, new Vector3(4, 1, 0f), Quaternion.identity);

		Instantiate(door, new Vector3(5, 9.5f, 0f), Quaternion.identity);
		Instantiate(exit, new Vector3(5, 10, 0), Quaternion.identity);

		Instantiate(wall[1], new Vector3(2, 6, 0f), Quaternion.identity);
		Instantiate(wall[1], new Vector3(5, 5, 0f), Quaternion.identity);
		Instantiate(wall[1], new Vector3(8, 6, 0f), Quaternion.identity);

		Instantiate(locks[0], new Vector3 (3, 8, 0f), Quaternion.identity);
		Instantiate(locks[1], new Vector3 (5, 7, 0f), Quaternion.identity);
		Instantiate(locks[2], new Vector3 (7, 8, 0f), Quaternion.identity);

		Instantiate(keys[0], new Vector3(8, 5, 0f), Quaternion.identity);
		Instantiate(keys[1], new Vector3(2, 5, 0f), Quaternion.identity);
		Instantiate(keys[2], new Vector3(5, 4, 0f), Quaternion.identity);
	}
}
