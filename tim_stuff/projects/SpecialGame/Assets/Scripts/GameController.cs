using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	//public GameObject[,] grid; // create 2D array of Sprite elements
	public int cols;
	public int rows;
	public GameObject tile;
	public GameObject wall;
	public GameObject player;

	// Use this for initialization
	void Start () {

		//grid[0,0] = (GameObject)Instantiate(tile, new Vector3(0, 0, 0), Quaternion.identity);

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

		//grid[0,0] = (GameObject)Instantiate(block, new Vector3(0, 0, 0), Quaternion.identity);
		//grid[0,1] = (GameObject)Instantiate(push_block, new Vector3(0, 1, 0), Quaternion.identity);


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
