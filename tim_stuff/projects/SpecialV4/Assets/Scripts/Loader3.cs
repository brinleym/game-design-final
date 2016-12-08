using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	public GameObject[] switches;
	public GameObject keySpawn;

	// Use this for initialization
	void Start () {

		int cols = 13;
		int rows = 13;

		// set up main room space
		for (int i = 0; i < cols; i++) {
			for (int j = 0; j < rows; j++) {

				// do nothing to leave room for door
				if (i == 6 && j == 12){
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
		Instantiate(player1, new Vector3(4, 1), Quaternion.identity);
		Instantiate(player2, new Vector3(6, 1), Quaternion.identity);
		Instantiate(player3, new Vector3(8, 1), Quaternion.identity);

		// set up keys
		Instantiate(keys[0], new Vector3(1, 11), Quaternion.identity);
		Instantiate(keys[1], new Vector3(6, 11), Quaternion.identity);
		Instantiate(keys[2], new Vector3(11, 11), Quaternion.identity);

		// set up locks
		Instantiate(locks[0], new Vector3(5, 11), Quaternion.identity);
		Instantiate(locks[1], new Vector3(6, 10), Quaternion.identity);
		Instantiate(locks[2], new Vector3(7, 11), Quaternion.identity);

		// set up door and exit
		Instantiate(door, new Vector3(6, 12.5f), Quaternion.identity);
		Instantiate(exit, new Vector3(6, 13), Quaternion.identity);

		List<GameObject> kspawns;
		kspawns = new List<GameObject>();

		// keyspawn as switch controller
		GameObject kspawn = Instantiate(keySpawn);

		kspawns.Add(kspawn);

		// set up each set of colored switch, all assigned to keyspawn
		GameObject rswitch;
		for (int i = 4; i <= 8; i++) {
			rswitch = (GameObject) Instantiate(switches[0], new Vector3(i, 3), Quaternion.identity);
			rswitch.GetComponent<SwitchScript>().SetTrigger(kspawns);
		}

		GameObject gswitch = (GameObject) Instantiate(switches[1], new Vector3(3, 4), Quaternion.identity);
		gswitch.GetComponent<SwitchScript>().SetTrigger(kspawns);
		for (int i = 4; i <= 5; i++) {
			for (int j = 7; j <= 8; j++) {
				gswitch = (GameObject) Instantiate(switches[1], new Vector3(i, j), Quaternion.identity);
				gswitch.GetComponent<SwitchScript>().SetTrigger(kspawns);
			} 
		}

		GameObject bswitch = (GameObject) Instantiate(switches[2], new Vector3(9, 4), Quaternion.identity);
		bswitch.GetComponent<SwitchScript>().SetTrigger(kspawns);
		for (int i = 7; i <= 8; i++) {
			for (int j = 7; j <= 8; j++) {
				bswitch = (GameObject) Instantiate(switches[2], new Vector3(i, j), Quaternion.identity);
				bswitch.GetComponent<SwitchScript>().SetTrigger(kspawns);
			} 
		}
			
		// set up boxes
		Instantiate(boxes[0], new Vector3(2, 10), Quaternion.identity);
		Instantiate(boxes[0], new Vector3(10, 8), Quaternion.identity);
		Instantiate(boxes[0], new Vector3(6, 5), Quaternion.identity);
		Instantiate(boxes[0], new Vector3(2, 2), Quaternion.identity);
		Instantiate(boxes[0], new Vector3(10, 4), Quaternion.identity);

		Instantiate(boxes[1], new Vector3(2, 3), Quaternion.identity);
		Instantiate(boxes[1], new Vector3(2, 9), Quaternion.identity);
		Instantiate(boxes[1], new Vector3(5, 5), Quaternion.identity);
		Instantiate(boxes[1], new Vector3(10, 10), Quaternion.identity);
		Instantiate(boxes[1], new Vector3(10, 2), Quaternion.identity);

		Instantiate(boxes[2], new Vector3(2, 4), Quaternion.identity);
		Instantiate(boxes[2], new Vector3(2, 8), Quaternion.identity);
		Instantiate(boxes[2], new Vector3(7, 5), Quaternion.identity);
		Instantiate(boxes[2], new Vector3(10, 3), Quaternion.identity);
		Instantiate(boxes[2], new Vector3(10, 9), Quaternion.identity);
	}

}
