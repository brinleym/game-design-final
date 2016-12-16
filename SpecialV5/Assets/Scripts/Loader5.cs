using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Loader5 : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;

	public GameObject door, exit;
	public GameObject[] floor;
	public GameObject[] wall;
	public GameObject[] boxes;
	public GameObject[] keys;
	public GameObject[] locks;
	public GameObject[] switches;
	public GameObject gate;

	// Use this for initialization
	void Start () 
	{
		int cols = 19;
		int rows = 13;

		// set up main room space
		for (int i = 0; i < cols; i++) {
			for (int j = 0; j < rows; j++) {

				// do nothing to leave room for door
				if (i == 9 && j == 12) {
				}
				// outer walls with square floor
				else if (i == 0 || i == cols - 1 || j == 0 || j == rows - 1) {
					Instantiate(wall[0], new Vector3(i, j), Quaternion.identity);
				} else {
					Instantiate(floor[0], new Vector3(i, j), Quaternion.identity);
				}
			}
		}

		for (int i = 1; i < cols; i++) {
			if (i == 3 || i == 4 || i == 8 || i == 9 || i == 15 || i == 16) {
			}
			else 	
				Instantiate(wall[0], new Vector3(i, 4), Quaternion.identity);
		}

		for (int i = 1; i < cols; i++) {
			if (i == 2 || i == 3 || i == 9 || i == 10 || i == 14 || i == 15) {
			}
			else 	
				Instantiate(wall[0], new Vector3(i, 8), Quaternion.identity);
		}

		for (int j = 1; j < 8; j++) {
			Instantiate(wall[0], new Vector3(6, j), Quaternion.identity);
			Instantiate(wall[0], new Vector3(12, j), Quaternion.identity);
		}

		// set up players
		Instantiate(player1, new Vector3(3, 1), Quaternion.identity);
		Instantiate(player2, new Vector3(9, 1), Quaternion.identity);
		Instantiate(player3, new Vector3(15, 1), Quaternion.identity);

		// set up keys
		Instantiate(keys[0], new Vector3(15, 2), Quaternion.identity);
		Instantiate(keys[1], new Vector3(3, 2), Quaternion.identity);
		Instantiate(keys[2], new Vector3(9, 3), Quaternion.identity);

		// set up locks
		Instantiate(locks[0], new Vector3(8, 11), Quaternion.identity);
		Instantiate(locks[1], new Vector3(9, 10), Quaternion.identity);
		Instantiate(locks[2], new Vector3(10, 11), Quaternion.identity);

		// set up door and exit
		Instantiate (door, new Vector3(9, 12.5f), Quaternion.identity);
		Instantiate (exit, new Vector3(9, 13), Quaternion.identity);

		// set up boxes
		Instantiate(boxes[0], new Vector3(3, 6), Quaternion.identity);
		Instantiate(boxes[1], new Vector3(9, 2), Quaternion.identity);
		Instantiate(boxes[2], new Vector3(15, 6), Quaternion.identity);

		// set up gates and switches
		GameObject rswitch, gswitch, bswitch, gateway;
		List<GameObject> gateways1, gateways2, gateways3, gateways4, gateways5, gateways6;
		gateways1 = new List<GameObject>();
		gateways2 = new List<GameObject>();
		gateways3 = new List<GameObject>();
		gateways4 = new List<GameObject>();
		gateways5 = new List<GameObject>();
		gateways6 = new List<GameObject>();

		gateway = (GameObject) Instantiate(gate, new Vector3(3.5f, 4), Quaternion.identity);
		gateways1.Add(gateway);
		gswitch = (GameObject) Instantiate(switches[1], new Vector3(8, 2), Quaternion.identity);
		gswitch.GetComponent<SwitchScript>().SetTrigger(gateways1);


		gateway = (GameObject) Instantiate(gate, new Vector3(14.5f, 8), Quaternion.identity);
		gateways2.Add(gateway);
		gswitch = (GameObject) Instantiate(switches[1], new Vector3(10, 2), Quaternion.identity);
		gswitch.GetComponent<SwitchScript>().SetTrigger(gateways2);

		gateway = (GameObject) Instantiate(gate, new Vector3(15.5f, 4), Quaternion.identity);
		gateways3.Add(gateway);
		rswitch = (GameObject) Instantiate(switches[0], new Vector3(4, 6), Quaternion.identity);
		rswitch.GetComponent<SwitchScript>().SetTrigger(gateways3);

		gateway = (GameObject) Instantiate(gate, new Vector3(9.5f, 8), Quaternion.identity);
		gateways4.Add(gateway);
		rswitch = (GameObject) Instantiate(switches[0], new Vector3(2, 6), Quaternion.identity);
		rswitch.GetComponent<SwitchScript>().SetTrigger(gateways4);

		gateway = (GameObject) Instantiate(gate, new Vector3(8.5f, 4), Quaternion.identity);
		gateways5.Add(gateway);
		bswitch = (GameObject) Instantiate(switches[2], new Vector3(16, 6), Quaternion.identity);
		bswitch.GetComponent<SwitchScript>().SetTrigger(gateways5);

		gateway = (GameObject) Instantiate(gate, new Vector3(2.5f, 8), Quaternion.identity);
		gateways6.Add(gateway);
		bswitch = (GameObject) Instantiate(switches[2], new Vector3(14, 6), Quaternion.identity);
		bswitch.GetComponent<SwitchScript>().SetTrigger(gateways6);

	}

}
