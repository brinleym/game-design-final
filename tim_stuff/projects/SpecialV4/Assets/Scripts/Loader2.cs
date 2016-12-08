using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Loader2 : MonoBehaviour {

	public int rows, cols;
	public GameObject door, exit;
	public GameObject floor;
	public GameObject wall;
	public GameObject gate;
	public GameObject[] keys;
	public GameObject[] locks;
	public GameObject[] boxes;
	public GameObject[] players;
	public GameObject[] switches;

	// Use this for initialization
	void Start () {

		for (int i = -cols; i <= cols; i++)
		{
			for (int j = -rows; j <= rows; j++)
			{
				// outer walls
				if (i == -cols || i == cols || j == -rows || j == rows || j == 6 || j == -6) {

					// leave room for door!
					if (i == 0 && (j == rows || j == rows-1)) {
					} else {
						Instantiate (wall, new Vector3 (i, j, 0f), Quaternion.identity);
					}
				}



				// inner walls

				// horiz walls
				if(j == 2 && (i != -7 && i != -6 && i != -1 && i != 0 && i != 5 && i != 6))
					Instantiate(wall, new Vector3(i, j, 0f), Quaternion.identity);
				if(j == -2 && (i != -7 && i != -6 && i != -2 && i != -1 && i != 0 && i != 1 && i != 2 && i != 5 && i != 6))
					Instantiate(wall, new Vector3(i, j, 0f), Quaternion.identity);

				// vert walls
				if(i == -3 && j <= 1)
					Instantiate(wall, new Vector3(i, j, 0f), Quaternion.identity);
				if(i == 3 && j <= 1)
					Instantiate(wall, new Vector3(i, j, 0f), Quaternion.identity);

				// floor
				Instantiate(floor, new Vector3(i, j, 0f), Quaternion.identity);
			}
		}

		//boxes
		Instantiate(boxes[0], new Vector3(0, -2, 0f), Quaternion.identity);
		Instantiate(boxes[1], new Vector3(2, 4, 0f), Quaternion.identity);
		Instantiate(boxes[2], new Vector3(-2, 4, 0f), Quaternion.identity);
		Instantiate(boxes[1], new Vector3(6, -4, 0f), Quaternion.identity);
		Instantiate(boxes[1], new Vector3(6, -5, 0f), Quaternion.identity);
		Instantiate(boxes[1], new Vector3(7, -4, 0f), Quaternion.identity);
		Instantiate(boxes[1], new Vector3(8, -4, 0f), Quaternion.identity);

		// door
		Instantiate (door, new Vector3 (0, 6.5f, 0f), Quaternion.identity);
		Instantiate (exit, new Vector3 (0, 7, 0f), Quaternion.identity);

		// set up keys
		Instantiate(keys[0], new Vector3(-1, 1), Quaternion.identity);
		Instantiate(keys[1], new Vector3(0, 1), Quaternion.identity);
		Instantiate(keys[2], new Vector3(1, 1), Quaternion.identity);

		// set up locks
		Instantiate(locks[0], new Vector3(4, 5), Quaternion.identity);
		Instantiate(locks[1], new Vector3(5, 5), Quaternion.identity);
		Instantiate(locks[2], new Vector3(6, 5), Quaternion.identity);

		//players
		Instantiate(players[2], new Vector3(-4, -3, 0f), Quaternion.identity); // red
		Instantiate(players[1], new Vector3(7, -5, 0f), Quaternion.identity); // green
		Instantiate(players[0], new Vector3(0, 0, 0f), Quaternion.identity); // blue

		// set up gates and switches
		GameObject rswitch, gswitch, bswitch, gateway1, gateway2;
		List<GameObject> gateways1, gateways2, gateways3;
		gateways1 = new List<GameObject>();
		gateways2 = new List<GameObject>();
		gateways3 = new List<GameObject>();

		gateway1 = (GameObject) Instantiate(gate, new Vector3(5.5f, 2), Quaternion.identity);
		gateways1.Add(gateway1);
		gateway2 = (GameObject) Instantiate(gate, new Vector3(-6.5f, -2), Quaternion.identity);
		gateways1.Add(gateway2);

		bswitch = (GameObject) Instantiate(switches[0], new Vector3(1, -4), Quaternion.identity);
		bswitch.GetComponent<SwitchScript>().SetTrigger(gateways1);

		gateway1 = (GameObject) Instantiate(gate, new Vector3(5.5f, -2), Quaternion.identity);
		gateways2.Add(gateway1);
		gateway2 = (GameObject) Instantiate(gate, new Vector3(-6.5f, 2), Quaternion.identity);
		gateways2.Add(gateway2);

		bswitch = (GameObject) Instantiate(switches[0], new Vector3(-1, -4), Quaternion.identity);
		bswitch.GetComponent<SwitchScript>().SetTrigger(gateways2);

		gateway1 = (GameObject) Instantiate(gate, new Vector3(-0.5f, 2), Quaternion.identity);
		gateways3.Add(gateway1);

		gswitch = (GameObject) Instantiate(switches[1], new Vector3(1, 4), Quaternion.identity);
		gswitch.GetComponent<SwitchScript>().SetTrigger(gateways3);

		rswitch = (GameObject) Instantiate(switches[2], new Vector3(-1, 4), Quaternion.identity);
		rswitch.GetComponent<SwitchScript>().SetTrigger(gateways3);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
