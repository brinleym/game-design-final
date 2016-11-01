using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public string axisName;

	private Rigidbody2D rb;
	private bool hasKey = false;
	private float move_horiz = 0.0f;
	private float move_vert = 0.0f;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
	
	}

	void Update () {

		// player movement code (working)
		//transform.position += transform.right *Input.GetAxis(axisName)* speed;
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			Vector3 position = this.transform.position;
			position.x--;
			this.transform.position = position;
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			Vector3 position = this.transform.position;
			position.x++;
			this.transform.position = position;
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			Vector3 position = this.transform.position;
			position.y++;
			this.transform.position = position;
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			Vector3 position = this.transform.position;
			position.y--;
			this.transform.position = position;
		}



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
