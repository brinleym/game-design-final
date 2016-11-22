using UnityEngine;
using System.Collections;

public class WalkThroughGate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// if player has key and matches color, then unlock
	void OnTriggerEnter2D(Collider2D collider)
	{

		Debug.Log("player near gate!");
		Debug.Log(collider.gameObject.name);

		// if gate open

		// move player up 2 spaces
		Rigidbody2D playerRB2D = collider.GetComponent<Rigidbody2D>();

		Vector3 newPosition = playerRB2D.position;
		newPosition.y = newPosition.y + 1.7f;
		collider.transform.position = newPosition;

		wait();

		newPosition = playerRB2D.position;
		newPosition.y = newPosition.y - 0.2f;
		collider.transform.position = newPosition;

		//collider.GetComponent<PlayerController>().AttemptMove(newPosition);


	}

	IEnumerator wait() {
		print(Time.time);
		yield return new WaitForSeconds(0.5f);
		print(Time.time);
	}
}
