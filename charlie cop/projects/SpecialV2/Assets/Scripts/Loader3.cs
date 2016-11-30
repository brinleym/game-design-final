using UnityEngine;
using System.Collections;

public class Loader3 : MonoBehaviour 
{
	public GameObject player1;
	public GameObject player2;
	public GameObject player3;

	public GameObject door, exit;
	public GameObject[] floor;
	public GameObject[] wall;
	public GameObject[] boxes;
	public GameObject[] keys;
	public GameObject[] locks;

	// Use this for initialization
	void Start () {

		int cols = 13;
		int rows = 13;

		// set up main room space
		for (int i = 0; i < cols; i++) {
			for (int j = 0; j < rows; j++) {


				// do nothing to leave room for door
				if (i == 6 && j == 12)
				{
					
				}
				// outer walls with square floor
				else if (i == 0 || i == cols - 1 || j == 0 || j == rows - 1) {
					Instantiate(wall[0], new Vector3(i, j), Quaternion.identity);
				} 
				else {
					Instantiate(floor[0], new Vector3(i, j), Quaternion.identity);
				}

			}
		}

		// set up players
		Instantiate(player1, new Vector3(7, 1), Quaternion.identity);

		// set up locks
		Instantiate(locks[0], new Vector3(5, 11), Quaternion.identity);
		Instantiate(locks[1], new Vector3(6, 10), Quaternion.identity);
		Instantiate(locks[2], new Vector3(7, 11), Quaternion.identity);

		// set up door and exit
		Instantiate(door, new Vector3(6, 12.5f), Quaternion.identity);
		Instantiate(exit, new Vector3(8, 13), Quaternion.identity);
	
	}

}
