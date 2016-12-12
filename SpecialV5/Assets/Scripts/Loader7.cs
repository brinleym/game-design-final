using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Loader7 : MonoBehaviour {

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
	public GameObject gateOpener;
	public GameObject keySpawn;


	// Use this for initialization
	void Start () {

		for (int i = -cols; i <= cols; i++)
		{
			for (int j = -rows; j <= rows; j++)
			{
				// outer walls
				if (i == -cols || i == cols || j == -rows || j == rows || j == 8 || j == -8) {

					if((i == 0 && j == 9) || (i == 0 && j == 8)) {
						// leave room for door!
					}
					else
						Instantiate(wall, new Vector3(i, j), Quaternion.identity);

				}

				// inner walls
				if(j == 0 && i != 0)
					Instantiate(wall, new Vector3(i, j), Quaternion.identity);
				if(i == -3 && (j <= -4 && j >= -7))
					Instantiate(wall, new Vector3(i, j), Quaternion.identity);
				if(i == -2 && j == -7)
					Instantiate(wall, new Vector3(i, j), Quaternion.identity);
				if(i == -1 && j == -7)
					Instantiate(wall, new Vector3(i, j), Quaternion.identity);
				if(i == 2 && j == -1)
					Instantiate(wall, new Vector3(i, j), Quaternion.identity);
				if(i == 3 && j == -1)
					Instantiate(wall, new Vector3(i, j), Quaternion.identity);
				if(i == 3 && j == -2)
					Instantiate(wall, new Vector3(i, j), Quaternion.identity);
				
				// floor
				Instantiate(floor, new Vector3(i, j, 0f), Quaternion.identity);
			}
	
		}

		// door
		Instantiate (door, new Vector3 (0, 8.5f, 0f), Quaternion.identity);
		Instantiate (exit, new Vector3 (0, 9, 0f), Quaternion.identity);

		// set up players
		Instantiate(players[0], new Vector3(0, -4), Quaternion.identity);
		Instantiate(players[1], new Vector3(1, -1), Quaternion.identity);
		Instantiate(players[2], new Vector3(-2, -2), Quaternion.identity);

		// set up keys
		Instantiate(keys[0], new Vector3(-1, 1), Quaternion.identity);
		Instantiate(keys[1], new Vector3(0, 1), Quaternion.identity);
		Instantiate(keys[2], new Vector3(1, 1), Quaternion.identity);

		// set up locks
		Instantiate(locks[0], new Vector3(-1, 7), Quaternion.identity);
		Instantiate(locks[1], new Vector3(0, 7), Quaternion.identity);
		Instantiate(locks[2], new Vector3(1, 7), Quaternion.identity);


		/////////////////////////////////////////////////////////////
		////////////////////////// Room 1 ///////////////////////////
		/////////////////////////////////////////////////////////////

		// set up boxes
		Instantiate(boxes[0], new Vector3(0, -3), Quaternion.identity);
		Instantiate(boxes[0], new Vector3(-1, -3), Quaternion.identity);
		Instantiate(boxes[0], new Vector3(0, -6), Quaternion.identity);

		Instantiate(boxes[1], new Vector3(-1, -5), Quaternion.identity);
		Instantiate(boxes[1], new Vector3(1, -4), Quaternion.identity);
		Instantiate(boxes[1], new Vector3(2, -4), Quaternion.identity);

		Instantiate(boxes[2], new Vector3(-1, -4), Quaternion.identity);
		Instantiate(boxes[2], new Vector3(2, -5), Quaternion.identity);
		Instantiate(boxes[2], new Vector3(1, -6), Quaternion.identity);

		// set up gate
		Instantiate(gate, new Vector3(0, 0), Quaternion.identity);

		// gateOpen as switch controller
		GameObject gateOpen = Instantiate(gateOpener);
	
		// set up gates and switches
		GameObject rswitch, gswitch, bswitch;

		List<GameObject> gateways1;
		gateways1 = new List<GameObject>();

		gateways1.Add(gateOpen);
	
		bswitch = (GameObject) Instantiate(switches[0], new Vector3(1, -5), Quaternion.identity);
		bswitch.GetComponent<SwitchScript>().SetTrigger(gateways1);
		bswitch = (GameObject) Instantiate(switches[0], new Vector3(0, -5), Quaternion.identity);
		bswitch.GetComponent<SwitchScript>().SetTrigger(gateways1);
		bswitch = (GameObject) Instantiate(switches[0], new Vector3(2, -2), Quaternion.identity);
		bswitch.GetComponent<SwitchScript>().SetTrigger(gateways1);

		gswitch = (GameObject) Instantiate(switches[1], new Vector3(-1, -4), Quaternion.identity);
		gswitch.GetComponent<SwitchScript>().SetTrigger(gateways1);
		gswitch = (GameObject) Instantiate(switches[1], new Vector3(-2, -4), Quaternion.identity);
		gswitch.GetComponent<SwitchScript>().SetTrigger(gateways1);
		gswitch = (GameObject) Instantiate(switches[1], new Vector3(2, -6), Quaternion.identity);
		gswitch.GetComponent<SwitchScript>().SetTrigger(gateways1);

		rswitch = (GameObject) Instantiate(switches[2], new Vector3(-2, -2), Quaternion.identity);
		rswitch.GetComponent<SwitchScript>().SetTrigger(gateways1);
		rswitch = (GameObject) Instantiate(switches[2], new Vector3(-2, -3), Quaternion.identity);
		rswitch.GetComponent<SwitchScript>().SetTrigger(gateways1);
		rswitch = (GameObject) Instantiate(switches[2], new Vector3(0, -3), Quaternion.identity);
		rswitch.GetComponent<SwitchScript>().SetTrigger(gateways1);

		/////////////////////////////////////////////////////////////
		////////////////////////// Room 2 ///////////////////////////
		/////////////////////////////////////////////////////////////

		// set up boxes
		Instantiate(boxes[0], new Vector3(0, 6), Quaternion.identity);
		Instantiate(boxes[0], new Vector3(0, 5), Quaternion.identity);
		Instantiate(boxes[0], new Vector3(-2, 3), Quaternion.identity);

		Instantiate(boxes[1], new Vector3(-2, 6), Quaternion.identity);
		Instantiate(boxes[1], new Vector3(-2, 5), Quaternion.identity);
		Instantiate(boxes[1], new Vector3(2, 3), Quaternion.identity);

		Instantiate(boxes[2], new Vector3(2, 6), Quaternion.identity);
		Instantiate(boxes[2], new Vector3(2, 5), Quaternion.identity);
		Instantiate(boxes[2], new Vector3(0, 2), Quaternion.identity);

		List<GameObject> kspawns;
		kspawns = new List<GameObject>();

		// keyspawn as switch controller
		GameObject kspawn = Instantiate(keySpawn);

		kspawns.Add(kspawn);

		bswitch = (GameObject) Instantiate(switches[0], new Vector3(-2, 6), Quaternion.identity);
		bswitch.GetComponent<SwitchScript>().SetTrigger(kspawns);
		bswitch = (GameObject) Instantiate(switches[0], new Vector3(-2, 5), Quaternion.identity);
		bswitch.GetComponent<SwitchScript>().SetTrigger(kspawns);
		bswitch = (GameObject) Instantiate(switches[0], new Vector3(2, 3), Quaternion.identity);
		bswitch.GetComponent<SwitchScript>().SetTrigger(kspawns);

		gswitch = (GameObject) Instantiate(switches[1], new Vector3(2, 6), Quaternion.identity);
		gswitch.GetComponent<SwitchScript>().SetTrigger(kspawns);
		gswitch = (GameObject) Instantiate(switches[1], new Vector3(2, 5), Quaternion.identity);
		gswitch.GetComponent<SwitchScript>().SetTrigger(kspawns);
		gswitch = (GameObject) Instantiate(switches[1], new Vector3(0, 3), Quaternion.identity);
		gswitch.GetComponent<SwitchScript>().SetTrigger(kspawns);

		rswitch = (GameObject) Instantiate(switches[2], new Vector3(0, 6), Quaternion.identity);
		rswitch.GetComponent<SwitchScript>().SetTrigger(kspawns);
		rswitch = (GameObject) Instantiate(switches[2], new Vector3(0, 5), Quaternion.identity);
		rswitch.GetComponent<SwitchScript>().SetTrigger(kspawns);
		rswitch = (GameObject) Instantiate(switches[2], new Vector3(-2, 3), Quaternion.identity);
		rswitch.GetComponent<SwitchScript>().SetTrigger(kspawns);


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
