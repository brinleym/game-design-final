using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	private Animator doorAnim;
	private BoxCollider2D doorCollider;
	private GameObject red, green, blue;
	private AudioSource open;

	// Use this for initialization
	void Start () {
		doorAnim = GetComponent<Animator>();
		doorCollider = GetComponent<BoxCollider2D>();
		doorAnim.SetBool("keysCollected", false);
		open = GetComponent<AudioSource>();

		red = GameObject.FindGameObjectWithTag("RedLock");
		green = GameObject.FindGameObjectWithTag("GreenLock");
		blue = GameObject.FindGameObjectWithTag("BlueLock");
	}
	
	// function for locks to check the door
	public void CheckDoor()
	{
		LockScript r = (LockScript)red.GetComponent (typeof(LockScript));
		LockScript g = (LockScript)green.GetComponent (typeof(LockScript));
		LockScript b = (LockScript)blue.GetComponent (typeof(LockScript));

		// if all unlocked, open the door, disable collider and the locks
		if (r.CheckLock() && g.CheckLock() && b.CheckLock())
		{
			doorAnim.SetBool("keysCollected", true);
			open.Play(); // play sound effect
			doorCollider.enabled = false;
			red.SetActive (false);
			green.SetActive (false);
			blue.SetActive (false);
		}
	}
}
