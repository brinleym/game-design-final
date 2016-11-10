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

		for (int i = -cols; i < cols; i++)
		{
			for (int j = -rows; j < rows; j++)
			{
				if (i == -cols || i == cols - 1 || j == -rows || j == rows - 1) {

					if((i == -8 && j == 0) || (i == -8 && j == -2) 
						|| (i == 1 && j == 6) || (i == 3 && j == 6)
						|| (i == 7 && j == -1) || (i == 7 && j == -3)) {
						// leave space empty
					}
					else {
						Instantiate(wall, new Vector3(i, j, 0f), Quaternion.identity);
					}
				}
				else
					Instantiate(tile, new Vector3(i, j, 0f), Quaternion.identity);
			}
		}

		for(int i = -5; i < 5; i++) {
			for(int j = -4; j < 4; j++) {

				if((i == -5 && j == -1) || (i == -5 && j == -3)
					|| (i == 0 && j == 3) || (i == 2 && j == 3) 
					|| (i == 4 && j == 0) || (i == 4 && j == -2)) {
					// leave space empty
				}
				else {
					Instantiate(wall, new Vector3(i, j, 0f), Quaternion.identity);
				}
			}

		}

		// init player
		Instantiate(player, new Vector3(-7, -6, 0f), Quaternion.identity);


		// init blocks
		Instantiate(boxList[0], new Vector3(-6, -3, 0f), Quaternion.identity);
		Instantiate(boxList[1], new Vector3(-7, -2, 0f), Quaternion.identity);
		Instantiate(boxList[0], new Vector3(-6, -1, 0f), Quaternion.identity);
		Instantiate(boxList[1], new Vector3(-7, 0, 0f), Quaternion.identity);
	
		Instantiate(boxList[2], new Vector3(0, 4, 0f), Quaternion.identity);
		Instantiate(boxList[1], new Vector3(1, 5, 0f), Quaternion.identity);
		Instantiate(boxList[2], new Vector3(2, 4, 0f), Quaternion.identity);
		Instantiate(boxList[1], new Vector3(3, 5, 0f), Quaternion.identity);

		Instantiate(boxList[0], new Vector3(5, 0, 0f), Quaternion.identity);
		Instantiate(boxList[2], new Vector3(6, -1, 0f), Quaternion.identity);
		Instantiate(boxList[0], new Vector3(5, -2, 0f), Quaternion.identity);
		Instantiate(boxList[2], new Vector3(6, -3, 0f), Quaternion.identity);

	}

}
