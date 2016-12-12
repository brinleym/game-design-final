using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AllOpenGate : MonoBehaviour {

	//public GameObject gate;
	private GameObject[] allSwitches;
	private GameObject gate;
	private List<GameObject> mySwitches;

	// Use this for initialization
	void Start () {

		mySwitches = new List<GameObject>();

		// get list of all switches
		allSwitches = GameObject.FindGameObjectsWithTag("Switch");
		gate = GameObject.FindGameObjectWithTag("Gate");

		foreach (GameObject obj in allSwitches) {

			// check if switch is in first room
			if(obj.transform.position.y < 0) {
				mySwitches.Add(obj);

			}

		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	// external function to check all switches
	public void CheckAllSwitches()
	{

		// for each switch, get their script and check their status
		foreach (GameObject obj in mySwitches) {
			SwitchScript ss = obj.GetComponent<SwitchScript>();

			// if false, can return immediately since all switches need to be true
			if (ss.CheckSwitch() == false)
				return;
		}

		// if all switches are pressed, open gate
		GateScript gs = gate.GetComponent<GateScript>();
		gs.GateOpen();

	}
}
