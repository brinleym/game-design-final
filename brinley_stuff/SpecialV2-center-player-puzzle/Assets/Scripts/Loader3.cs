using UnityEngine;
using System.Collections;

public class Loader3 : MonoBehaviour {

	public int rows, cols;
	public GameObject door, exit;
	public GameObject[] gates;
	public GameObject[] floor;
	public GameObject wall;
	public GameObject[] boxes;
	public GameObject[] players;

	// Use this for initialization
	void Start () {


		for (int i = -cols; i <= cols; i++)
		{
			for (int j = -rows; j <= rows; j++)
			{
				// outer walls
				if (i == -cols || i == cols || j == -rows || j == rows || j == 6 || j == -6) 
					Instantiate(wall, new Vector3(i, j, 0f), Quaternion.identity);

				// inner walls
				else if((i == -3 && j <= 3) || (i == 3 && j <= 3))
					Instantiate(wall, new Vector3(i, j, 0f), Quaternion.identity);
				else if(j == 3 || j == 2)
					Instantiate(wall, new Vector3(i, j, 0f), Quaternion.identity);
				else if(j == -1 && (i <= -4 || i >= 4))
					Instantiate(wall, new Vector3(i, j, 0f), Quaternion.identity);
				else if(j == -2 && (i <= -4 || i >= 4))
					Instantiate(wall, new Vector3(i, j, 0f), Quaternion.identity);

				// colored tiles
				else if(i == -1 && j == -4)
					Instantiate(floor[1], new Vector3(i, j, 0f), Quaternion.identity);
				else if(i == 1 && j == -4)
					Instantiate(floor[2], new Vector3(i, j, 0f), Quaternion.identity);
				else if(i == -1 && j == 4)
					Instantiate(floor[3], new Vector3(i, j, 0f), Quaternion.identity);
				else if(i == 1 && j == 4)
					Instantiate(floor[4], new Vector3(i, j, 0f), Quaternion.identity);

				// floor
				else
					Instantiate(floor[0], new Vector3(i, j, 0f), Quaternion.identity);
			}
		}

		//boxes
		Instantiate(boxes[0], new Vector3(0, -2, 0f), Quaternion.identity);
		Instantiate(boxes[1], new Vector3(2, 4, 0f), Quaternion.identity);
		Instantiate(boxes[2], new Vector3(-2, 4, 0f), Quaternion.identity);

		// door
		Instantiate (door, new Vector3 (0, 6.5f, 0), Quaternion.identity);
		Instantiate (exit, new Vector3 (0, 7, 0), Quaternion.identity);

		//gates
		Instantiate (gates[0], new Vector3 (-6, -2, 0), Quaternion.identity);
		Instantiate (gates[0], new Vector3 (6, 2, 0), Quaternion.identity);
		Instantiate (gates[1], new Vector3 (6, -2, 0), Quaternion.identity);
		Instantiate (gates[1], new Vector3 (-6, 2, 0), Quaternion.identity);
		Instantiate (gates[2], new Vector3 (0, 2, 0), Quaternion.identity);

		//players
		Instantiate(players[0], new Vector3(-4, -3, 0f), Quaternion.identity);
		Instantiate(players[1], new Vector3(7, -5, 0f), Quaternion.identity);
		Instantiate(players[2], new Vector3(0, 0, 0f), Quaternion.identity);

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
