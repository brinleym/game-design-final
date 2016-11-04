using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject[,] grid; // create 2D array of Sprite elements
	public int cols;
	public int rows;
	public GameObject tile;
	public GameObject block;
	public GameObject push_block;

	// Use this for initialization
	void Start () {

		grid = new GameObject[10,10];

		//grid[0,0] = tile;
		grid[0,0] = (GameObject)Instantiate(tile, new Vector3(0, 0, 0), Quaternion.identity);

		for (int i = 0; i < cols; i++)
		{
			for (int j = 0; j < rows; j++)
			{
				grid[i,j] = (GameObject)Instantiate(tile, new Vector3(i, j, 0), Quaternion.identity);
			}
		}

		grid[0,0] = (GameObject)Instantiate(block, new Vector3(0, 0, 0), Quaternion.identity);
		grid[0,1] = (GameObject)Instantiate(push_block, new Vector3(0, 1, 0), Quaternion.identity);


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
