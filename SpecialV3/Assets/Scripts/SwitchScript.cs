using UnityEngine;
using System.Collections;

public class SwitchScript : MonoBehaviour {

	public string color;
	private GameObject triggerObject;
	private bool activate;

	// initialize switch activation to false
	void Start () 
	{
		activate = false;
	}

	// assign a trigger that the switch will activate
	public void SetTrigger(GameObject trigger)
	{
		triggerObject = trigger;
	}

	// function to check switch status
	public bool CheckSwitch() 
	{
		return activate;
	}
	
	// code that executes when anything has touched the switch
	void OnTriggerEnter2D(Collider2D collider)
	{
		// only deal with objects that are players or boxes
		if (/*collider.CompareTag("Player") ||*/ collider.CompareTag("Box")) {

			// if the correct player or box is on switch, activate and check switch controller
			if (collider.name.Contains(color)) {
				activate = true;

				if (triggerObject.CompareTag("KeySpawn")) {
					KeySpawnScript ks = triggerObject.GetComponent<KeySpawnScript>();
					ks.CheckAllSwitches();
				} 
				else if (triggerObject.CompareTag("Gate")) {
					GateScript gs = triggerObject.GetComponent<GateScript>();
					gs.GateOpen();
				}
			}
		}
	}

	// code that executes when anything has left the switch
	void OnTriggerExit2D(Collider2D collider)
	{
		// deactivate switch on exit
		activate = false;

		// if trigger is keyspawn, deactivate all keys
		if (triggerObject.CompareTag("KeySpawn")) {
			KeySpawnScript ks = triggerObject.GetComponent<KeySpawnScript>();
			ks.DespawnKeys();
		}
		else if (triggerObject.CompareTag("Gate")) {
			GateScript gs = triggerObject.GetComponent<GateScript>();
			gs.GateClose();
		}
	}
}
