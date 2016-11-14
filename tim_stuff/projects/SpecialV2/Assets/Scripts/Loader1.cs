using UnityEngine;
using System.Collections;

public class Loader1 : MonoBehaviour {

	public int rows, cols;
	public GameObject floor;
	public GameObject wall;
	public GameObject door;
	public GameObject[] players;
	public GameObject[] boxes;
	public GameObject[] keys;
	public GameObject[] locks;

	// Use this for initialization
	void Start () {

		for (int i = -cols; i <= cols; i++)
		{
			for (int j = -rows; j <= rows; j++)
			{	
				// leave room for door
				if ((i == 2 && j == 6) || (i == 2 && j == 7)) {
					// do nothing
				}

				// cover outer two rims
				else if (i == -cols || i == cols || i == -cols + 1 || i == cols - 1 ||
					j == -rows || j == rows || j == -rows + 1 || j == rows - 1) {

					// leave room for box nooks
					if ((i == -cols + 1 && j == -1) || (i == cols - 1 && j == -1) ||
						(i == -cols + 1 && j == 1) || (i == cols - 1 && j == 1) || 
						(i == -3 && j == rows - 1) || (i == -1 && j == rows - 1)) 
						Instantiate (floor, new Vector3 (i, j, 0f), Quaternion.identity);
					else
						Instantiate (wall, new Vector3 (i, j, 0f), Quaternion.identity);
				}

				// cover rest with floor
				else
					Instantiate (floor, new Vector3 (i, j, 0f), Quaternion.identity);
			}
		}

		// wall blocks in middle
		for (int i = -4; i <= 4; i++) {
			for (int j = -3; j <= 3; j++) {

				if ((i == -4 && j == 0) || (i == 4 && j == 0) || (i == -2 && j == 3)) {
				}
				else
					Instantiate (wall, new Vector3 (i, j, 0f), Quaternion.identity);
			}
		}

		// extra wall blocks
		Instantiate (wall, new Vector3 (-1, -4, 0f), Quaternion.identity);
		Instantiate (wall, new Vector3 (-1, -5, 0f), Quaternion.identity);
		Instantiate (wall, new Vector3 (0, -4, 0f), Quaternion.identity);
		Instantiate (wall, new Vector3 (0, -5, 0f), Quaternion.identity);
		Instantiate (wall, new Vector3 (1, -4, 0f), Quaternion.identity);
		Instantiate (wall, new Vector3 (1, -5, 0f), Quaternion.identity);

		// door
		Instantiate (door, new Vector3 (2, 6.5f, 0), Quaternion.identity);

		// init blocks
		Instantiate(boxes[0], new Vector3(-6, -1, 0f), Quaternion.identity);
		Instantiate(boxes[1], new Vector3(-5, 0, 0), Quaternion.identity);
		Instantiate(boxes[2], new Vector3(-6, 1, 0f), Quaternion.identity);

		Instantiate(boxes[2], new Vector3(6, -1, 0f), Quaternion.identity);
		Instantiate(boxes[0], new Vector3(5, 0, 0), Quaternion.identity);
		Instantiate(boxes[1], new Vector3(6, 1, 0f), Quaternion.identity);

		Instantiate(boxes[1], new Vector3(-3, 5, 0f), Quaternion.identity);
		Instantiate(boxes[2], new Vector3(-2, 4, 0), Quaternion.identity);
		Instantiate(boxes[0], new Vector3(-1, 5, 0f), Quaternion.identity);

		// init keys and locks
		Instantiate(keys[0], new Vector3(-6, 5, 0f), Quaternion.identity);
		Instantiate(keys[1], new Vector3(0, 4, 0), Quaternion.identity);
		Instantiate(keys[2], new Vector3(6, 5, 0f), Quaternion.identity);
		Instantiate(locks[0], new Vector3(2, -5, 0f), Quaternion.identity);
		Instantiate(locks[1], new Vector3(4, -5, 0), Quaternion.identity);
		Instantiate(locks[2], new Vector3(6, -5, 0f), Quaternion.identity);

		// init players
		Instantiate(players[0], new Vector3(-6, -5, 0f), Quaternion.identity);
		Instantiate(players[1], new Vector3(-4, -5, 0), Quaternion.identity);
		Instantiate(players[2], new Vector3(-2, -5, 0f), Quaternion.identity);
	}

}