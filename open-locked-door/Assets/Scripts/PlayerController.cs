using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public string axisName;
	private Rigidbody2D rb;
	private bool hasKey = false;

	// Use this for initialization
	void Start () {

		//rb = GetComponent<Rigidbody2D> ();
	
	}

	void Update () {

		// player movement code
		transform.position += transform.right *Input.GetAxis(axisName)* speed;
	
	}

	// pick up code
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.CompareTag ("Key"))
		{
			// pick up key
			other.gameObject.SetActive (false);

			// set hasKey flag to true (so that player can open door)
			hasKey = true;
		}

		if(other.gameObject.CompareTag("Exit")) {

			if(hasKey) { // if player has key

				// open door
				other.gameObject.SetActive(false);
			}

		}
	}
}
