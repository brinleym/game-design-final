using UnityEngine;
using System.Collections;

public class KeySpawnScript : MonoBehaviour {

	private GameObject[] keyList;
	private GameObject[] switchList;

	// key spawn initialization
	void Start () 
	{
		// disable keys from start
		keyList = GameObject.FindGameObjectsWithTag("Key");
		foreach (GameObject key in keyList) {
			key.SetActive(false);
		}

		// get list of all switches
		switchList = GameObject.FindGameObjectsWithTag("Switch");

	}
	
	// internal function to enable keys when conditions are met
	private void SpawnKeys()
	{
		foreach (GameObject key in keyList) {
			key.SetActive(true);
		}	
	}

	// external function to disable all keys when leaving switch
	public void DespawnKeys()
	{
		// check if players already own keys, don't need to despawn
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		foreach (GameObject player in players) {
			PlayerController p = player.GetComponent<PlayerController> ();
			if (p.checkKey ())
				return;
		}
		
		// deactivate all keys
		foreach (GameObject key in keyList) {
			key.SetActive(false);
		}	
	}

	// external function to check all switches
	public void CheckAllSwitches()
	{

		// for each switch, get their script and check their status
		foreach (GameObject obj in switchList) {
			SwitchScript ss = obj.GetComponent<SwitchScript>();

			// if false, can return immediately since all switches need to be true
			if (ss.CheckSwitch() == false)
				return;
		}

		// if all switches are pressed, check to make sure players don't have keys yet
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		foreach (GameObject player in players) {
			PlayerController p = player.GetComponent<PlayerController>();
			if (p.checkKey())
				return;
		}

		// if all conditions passed, spawn the keys
		SpawnKeys();
	}
}
