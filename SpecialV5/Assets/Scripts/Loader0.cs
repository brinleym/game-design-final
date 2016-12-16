using UnityEngine;
using System.Collections;

public class Loader0 : MonoBehaviour {

	public GameObject player1, player2, player3;
	public GameObject door, exit;
	public GameObject[] floor;
	public GameObject[] wall;
	public GameObject[] boxes;
	public GameObject[] keys;
	public GameObject[] locks;

	// Use this for initialization
	void Start () {

		int rows = 10;
		int cols = 11;

		for (int i = 0; i < cols; i++)
		{
			for (int j = 0; j < rows; j++)
			{
				if (i == 0 || i == cols - 1 || j == 0 || j == rows - 1) {
					if (i == 5 && j == 9) {
					} 
					else 
						Instantiate (wall[0], new Vector3(i, j), Quaternion.identity);
				}
				else
					Instantiate(floor[0], new Vector3(i, j), Quaternion.identity);
			}
		}

		Instantiate(player1, new Vector3(5, 1), Quaternion.identity);
		Instantiate(player2, new Vector3(6, 1), Quaternion.identity);
		Instantiate(player3, new Vector3(4, 1), Quaternion.identity);

		Instantiate(locks[0], new Vector3 (3, 8), Quaternion.identity);
		Instantiate(locks[1], new Vector3 (5, 6), Quaternion.identity);
		Instantiate(locks[2], new Vector3 (7, 8), Quaternion.identity);

		Instantiate(door, new Vector3(5, 9.5f), Quaternion.identity);
		Instantiate(exit, new Vector3(5, 10), Quaternion.identity);

		Instantiate(wall[0], new Vector3(2, 6), Quaternion.identity);
		Instantiate(wall[0], new Vector3(5, 5), Quaternion.identity);
		Instantiate(wall[0], new Vector3(8, 6), Quaternion.identity);

		Instantiate(keys[0], new Vector3(8, 5), Quaternion.identity);
		Instantiate(keys[1], new Vector3(2, 5), Quaternion.identity);
		Instantiate(keys[2], new Vector3(5, 4), Quaternion.identity);
	}
}
