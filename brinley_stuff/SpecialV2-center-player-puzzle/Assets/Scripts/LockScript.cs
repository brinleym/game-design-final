using UnityEngine;
using System.Collections;

public class LockScript : MonoBehaviour {

	public string color;

	private bool unlock, sound;
	private GameObject door;
	private AudioSource keyUnlock;

	// initialize unlock to false, get door object
	void Start () 
	{
		unlock = false;
		sound = true;
		door = GameObject.FindGameObjectWithTag("Door");
		keyUnlock = GetComponent<AudioSource>();
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

			// play sound effect once so it doesn't play on exit
			if (sound) {
				keyUnlock.Play();
				sound = false;
			}

			// set variable and check door
			unlock = true;
			d.CheckDoor();
		}
	}

	// revert back to lock once any player has left square
	void OnTriggerExit2D(Collider2D collider)
	{
		unlock = false;
		sound = true;  // reset sound effect var
	}
}
