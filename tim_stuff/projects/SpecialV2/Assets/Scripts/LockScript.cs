using UnityEngine;
using System.Collections;

public class LockScript : MonoBehaviour {

	public string color;
	private bool unlock;
	private GameObject door;

	// initialize unlock to false, get door object
	void Start () 
	{
		unlock = false;
		door = GameObject.FindGameObjectWithTag("Door");
	}

	// function to check a lock status
	public bool CheckLock() 
	{
		return unlock;
	}

	// if player has key and matches color, then unlock
	void OnTriggerEnter2D(Collider2D collider)
	{
		// get the player's script who entered the square
		PlayerController p = collider.gameObject.GetComponent<PlayerController>();
		DoorController d = (DoorController) door.GetComponent(typeof(DoorController));

		// set unlock to true if player has keys and matches color
		if (p.checkKey () && p.colorPower.Contains(color)) {
			unlock = true;
			d.CheckDoor();
		}
	}

	// revert back to lock once any player has left square
	void OnTriggerExit2D(Collider2D collider)
	{
		unlock = false;
	}
}
