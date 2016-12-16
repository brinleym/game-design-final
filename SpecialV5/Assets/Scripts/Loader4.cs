using UnityEngine;
using System.Collections;

public class Loader4 : MonoBehaviour
{
	public GameObject player1, player2, player3;
	public GameObject door, exit;
	public GameObject[] floor;
	public GameObject[] wall;
	public GameObject[] boxes;
	public GameObject[] keys;
	public GameObject[] locks;

	// Use this for initialization
	void Start()
	{
		int rows = 14;
		int cols = 17;
		for (int i = 0; i < cols; i++)
		{
			for (int j = 0; j < rows; j++)
			{
				if (i == 0 || i == cols - 1 || j == 0 || j == rows - 1)
				{
					if (i == 8 && j == 13)
					{
					}
					else if (i == 7 && j == 0)
					{
						Instantiate(floor[1], new Vector3(i, j), Quaternion.identity);

					}
					else if (i == 8 && j == 0)
					{
						Instantiate(floor[1], new Vector3(i, j), Quaternion.identity);

					}
					else if (i == 9 && j == 0)
					{
						Instantiate(floor[1], new Vector3(i, j), Quaternion.identity);

					}
					else
						Instantiate(wall[0], new Vector3(i, j), Quaternion.identity);
				}
				else
					Instantiate(floor[1], new Vector3(i, j), Quaternion.identity);
			}
		}

		//Player Starting Squares (No wall to keep them enclosed)
		Instantiate(wall[0], new Vector3(7, -1), Quaternion.identity);
		Instantiate(wall[0], new Vector3(8, -1), Quaternion.identity);
		Instantiate(wall[0], new Vector3(9, -1), Quaternion.identity);
		Instantiate(wall[0], new Vector3(6, -1), Quaternion.identity);
		Instantiate(wall[0], new Vector3(10, -1), Quaternion.identity);

		//Walls
		for (int i = 2; i < 15; i++)
		{
			if (i == 2)
			{
				for (int j = 3; j < 10; j++)
				{
					if (j != 7)
					{
						Instantiate(wall[0], new Vector3(i, j), Quaternion.identity);
					}
				}
			}
			else if (i == 14)
			{
				for (int j = 3; j < 10; j++)
				{
					if (j != 5)
					{
						Instantiate(wall[0], new Vector3(i, j), Quaternion.identity);
					}
				}
			}
			else
			{
				Instantiate(wall[0], new Vector3(i, 2), Quaternion.identity);
				Instantiate(wall[0], new Vector3(i, 10), Quaternion.identity);
			}

		}
		for (int j = 4; j < 9; j++)
		{
			if (j == 4)
			{
				for (int i = 4; i < 13; i++)
				{
					if (i != 10)
					{
						Instantiate(wall[0], new Vector3(i, j), Quaternion.identity);
					}
				}
			}
			else if (j == 8)
			{
				for (int i = 4; i < 13; i++)
				{
					if (i != 6)
					{
						Instantiate(wall[0], new Vector3(i, j), Quaternion.identity);
					}
				}
			}
			else
			{
				Instantiate(wall[0], new Vector3(4, j), Quaternion.identity);
				Instantiate(wall[0], new Vector3(12, j), Quaternion.identity);
			}

		}

		// extra walls
		for (int i = 0; i < cols; i++) {
			if (i != 8)
				Instantiate (wall [0], new Vector3 (i, 12), Quaternion.identity);
		}
		Instantiate (wall [0], new Vector3 (2, 10), Quaternion.identity);
		Instantiate (wall [0], new Vector3 (14, 10), Quaternion.identity);

		Instantiate(boxes[0], new Vector3(15, 2), Quaternion.identity);
		Instantiate(boxes[0], new Vector3(10, 5), Quaternion.identity);
		Instantiate(boxes[0], new Vector3(7, 6), Quaternion.identity);

		Instantiate(boxes[1], new Vector3(13, 4), Quaternion.identity);
		Instantiate(boxes[1], new Vector3(3, 4), Quaternion.identity);
		Instantiate(boxes[1], new Vector3(4, 9), Quaternion.identity);
		Instantiate(boxes[1], new Vector3(12, 9), Quaternion.identity);
		Instantiate(boxes[1], new Vector3(8, 5), Quaternion.identity);
		Instantiate(boxes[1], new Vector3(8, 7), Quaternion.identity);

		Instantiate(boxes[2], new Vector3(1, 3), Quaternion.identity);
		Instantiate(boxes[2], new Vector3(6, 7), Quaternion.identity);
		Instantiate(boxes[2], new Vector3(9, 6), Quaternion.identity);


		Instantiate(player1, new Vector3(7, 0), Quaternion.identity);
		Instantiate(player2, new Vector3(8, 0), Quaternion.identity);
		Instantiate(player3, new Vector3(9, 0), Quaternion.identity);

		Instantiate(door, new Vector3(8, 12.5f), Quaternion.identity);
		Instantiate(exit, new Vector3(8, 13), Quaternion.identity);

		Instantiate(locks[0], new Vector3(6, 11), Quaternion.identity);
		Instantiate(locks[1], new Vector3(8, 11), Quaternion.identity);
		Instantiate(locks[2], new Vector3(10, 11), Quaternion.identity);

		Instantiate(keys[0], new Vector3(8, 6), Quaternion.identity);
		Instantiate(keys[1], new Vector3(9, 5), Quaternion.identity);
		Instantiate(keys[2], new Vector3(7, 7), Quaternion.identity);
	}
}