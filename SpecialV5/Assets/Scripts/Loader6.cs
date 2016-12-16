using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Loader6 : MonoBehaviour {

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
	void Start() {
		int rows = 21;
		int cols = 30;
		// set up main room space
		for (int i = 0; i < cols; i++)
		{
			for (int j = 0; j < rows; j++)
			{

				// do nothing to leave room for door
				if (i == 14 && j == 20)
				{
				}
				// outer walls with square floor
				else if (i == 0 || i == cols - 1 || j == 0 || j == rows - 1)
				{
					if ((j == 0 && i > 3 && i < 8) || (j == 0 && i > 22 && i < 27)) {
						Instantiate(floor[0], new Vector3(i, j), Quaternion.identity);
						Instantiate(wall[0], new Vector2(i, j - 1), Quaternion.identity);
					}
					else 
						Instantiate(wall[0], new Vector3(i, j), Quaternion.identity);
				}
				else
				{
					Instantiate(floor[0], new Vector3(i, j), Quaternion.identity);
				}
			}
		}

		// fill in extra gaps
		Instantiate(wall[0], new Vector2(3, -1), Quaternion.identity);
		Instantiate(wall[0], new Vector2(8, -1), Quaternion.identity);
		Instantiate(wall[0], new Vector2(22, -1), Quaternion.identity);
		Instantiate(wall[0], new Vector2(27, -1), Quaternion.identity);


		for (int i = 0; i < cols; i++)
		{
			if (i == 5 || i == 6 || i == 14 || i == 15 || i == 24 || i == 25) { }
			else
			{
				Instantiate(wall[0], new Vector3(i, 4), Quaternion.identity);
				Instantiate(wall[0], new Vector3(i, 16), Quaternion.identity);
			}
		}
		for (int i = 0; i < 11; i++)
		{
			if (i < 5 || i > 6)
			{
				Instantiate(wall[0], new Vector3(i, 12), Quaternion.identity);
				Instantiate(wall[0], new Vector3(i, 8), Quaternion.identity);
			}
		}
		for (int i = 10; i < 20; i ++)
		{
			if (i < 14 || i > 15)
			{
				Instantiate(wall[0], new Vector3(i, 15), Quaternion.identity);
				Instantiate(wall[0], new Vector3(i, 14), Quaternion.identity);
				Instantiate(wall[0], new Vector3(i, 10), Quaternion.identity);


			}
		}
		for (int i = 19; i < cols; i++)
		{
			if (i < 24 || i > 25)
			{
				Instantiate(wall[0], new Vector3(i, 12), Quaternion.identity);
				Instantiate(wall[0], new Vector3(i, 8), Quaternion.identity);
			}
		}

		for (int j = 0; j < rows; j++)
		{
			if (j > 3 && j < 17)
			{
				Instantiate(wall[0], new Vector3(10, j), Quaternion.identity);
				Instantiate(wall[0], new Vector3(19, j), Quaternion.identity);
			}

		}
		// set up players
		Instantiate(player1, new Vector3(15, 2), Quaternion.identity);
		Instantiate(player2, new Vector3(18, 2), Quaternion.identity);
		Instantiate(player3, new Vector3(21, 2), Quaternion.identity);

		// set up keys
		Instantiate(keys[0], new Vector3(8, 13), Quaternion.identity);
		Instantiate(keys[1], new Vector3(28, 18), Quaternion.identity);
		Instantiate(keys[2], new Vector3(21, 13), Quaternion.identity);

		// set up locks
		Instantiate(locks[0], new Vector3(14, 18), Quaternion.identity);
		Instantiate(locks[1], new Vector3(13, 19), Quaternion.identity);
		Instantiate(locks[2], new Vector3(15, 19), Quaternion.identity);

		// set up door and exit
		Instantiate(door, new Vector3(14, 20.5f), Quaternion.identity);
		Instantiate(exit, new Vector3(14, 21), Quaternion.identity);

		// set up boxes
		// red boxes
		Instantiate(boxes[0], new Vector3(7, 2), Quaternion.identity);
		Instantiate(boxes[0], new Vector3(14, 8), Quaternion.identity);
		//green boxes
		Instantiate(boxes[1], new Vector3(26, 6), Quaternion.identity);
		Instantiate(boxes[1], new Vector3(22, 13), Quaternion.identity);
		Instantiate(boxes[1], new Vector3(20, 13), Quaternion.identity);
		Instantiate(boxes[1], new Vector3(21, 14), Quaternion.identity);
		Instantiate(boxes[1], new Vector3(14, 7), Quaternion.identity);

		//blue

		Instantiate(boxes[2], new Vector3(7, 13), Quaternion.identity);
		Instantiate(boxes[2], new Vector3(9, 13), Quaternion.identity);
		Instantiate(boxes[2], new Vector3(2, 10), Quaternion.identity);
		Instantiate(boxes[2], new Vector3(8, 14), Quaternion.identity);
		Instantiate(boxes[2], new Vector3(14, 6), Quaternion.identity);
		Instantiate(boxes[2], new Vector3(22, 5), Quaternion.identity);

		// set up gates and switches
		GameObject Switch, gateway;
		List<GameObject> aSwitch, bSwitch, cSwitch, dSwitch, eSwitch, f1Switch, f2Switch, f3Switch, gSwitch;
		aSwitch = new List<GameObject>();
		bSwitch = new List<GameObject>();
		cSwitch = new List<GameObject>();
		dSwitch = new List<GameObject>();
		eSwitch = new List<GameObject>();
		f1Switch = new List<GameObject>();
		f2Switch = new List<GameObject>();
		f3Switch = new List<GameObject>();
		gSwitch = new List<GameObject>();


		gateway = (GameObject)Instantiate(gate, new Vector3(5.5f, 4), Quaternion.identity);
		aSwitch.Add(gateway);
		gateway = (GameObject)Instantiate(gate, new Vector3(24.5f, 16), Quaternion.identity);
		aSwitch.Add(gateway);
		Switch = (GameObject)Instantiate(switches[1], new Vector3(21, 6), Quaternion.identity);
		Switch.GetComponent<SwitchScript>().SetTrigger(aSwitch);

		gateway = (GameObject)Instantiate(gate, new Vector3(5.5f, 8), Quaternion.identity);
		bSwitch.Add(gateway);
		gateway = (GameObject)Instantiate(gate, new Vector3(24.5f, 12), Quaternion.identity);
		bSwitch.Add(gateway);
		Switch = (GameObject)Instantiate(switches[2], new Vector3(27, 5), Quaternion.identity);
		Switch.GetComponent<SwitchScript>().SetTrigger(bSwitch);

		gateway = (GameObject)Instantiate(gate, new Vector3(5.5f, 12), Quaternion.identity);
		cSwitch.Add(gateway);
		gateway = (GameObject)Instantiate(gate, new Vector3(24.5f, 8), Quaternion.identity);
		cSwitch.Add(gateway);
		Switch = (GameObject)Instantiate(switches[0], new Vector3(8, 6), Quaternion.identity);
		Switch.GetComponent<SwitchScript>().SetTrigger(cSwitch);

		gateway = (GameObject)Instantiate(gate, new Vector3(5.5f, 16), Quaternion.identity);
		dSwitch.Add(gateway);
		gateway = (GameObject)Instantiate(gate, new Vector3(24.5f, 4), Quaternion.identity);
		dSwitch.Add(gateway);
		Switch = (GameObject)Instantiate(switches[0], new Vector3(3, 2), Quaternion.identity);
		Switch.GetComponent<SwitchScript>().SetTrigger(dSwitch);

		gateway = (GameObject)Instantiate(gate, new Vector3(14.5f, 4), Quaternion.identity);
		eSwitch.Add(gateway);
		Switch = (GameObject)Instantiate(switches[1], new Vector3(21, 10), Quaternion.identity);
		Switch.GetComponent<SwitchScript>().SetTrigger(eSwitch);

		gateway = (GameObject)Instantiate(gate, new Vector3(14.5f, 16), Quaternion.identity);
		f1Switch.Add(gateway);
		Switch = (GameObject)Instantiate(switches[0], new Vector3(12, 12), Quaternion.identity);
		Switch.GetComponent<SwitchScript>().SetTrigger(f1Switch);

		gateway = (GameObject)Instantiate(gate, new Vector3(14.5f, 15), Quaternion.identity);
		f2Switch.Add(gateway);
		Switch = (GameObject)Instantiate(switches[1], new Vector3(16, 12), Quaternion.identity);
		Switch.GetComponent<SwitchScript>().SetTrigger(f2Switch);

		gateway = (GameObject)Instantiate(gate, new Vector3(14.5f, 14), Quaternion.identity);
		f3Switch.Add(gateway);
		Switch = (GameObject)Instantiate(switches[2], new Vector3(14, 12), Quaternion.identity);
		Switch.GetComponent<SwitchScript>().SetTrigger(f3Switch);

		gateway = (GameObject)Instantiate(gate, new Vector3(14.5f, 10), Quaternion.identity);
		gSwitch.Add(gateway);
		Switch = (GameObject)Instantiate(switches[2], new Vector3(3, 9), Quaternion.identity);
		Switch.GetComponent<SwitchScript>().SetTrigger(gSwitch);
	}


}