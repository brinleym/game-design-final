using UnityEngine;
using System.Collections;

public class SwitchCheckScript : MonoBehaviour {

	private Vector3 currentPos;

	// no keys are released initially
	void Start () 
	{
		Transform t = GetComponent<Transform>();
		currentPos = new Vector3(t.position.x, t.position.y);
	}

	// function that checks if every switch has been pressed
	public void CheckAllSwitches()
	{
		// get all switches that are on the board
		GameObject[] objects = GameObject.FindGameObjectsWithTag("Switch");

		// for each switch, get their script and check their status
		foreach (GameObject obj in objects) {
			SwitchScript ss = obj.GetComponent<SwitchScript>();

			// if false, can return immediately since all switches need to be pressed
			if (ss.CheckSwitch() == false)
				return;
		}

		// if reached the end, then release keys


	}
}
