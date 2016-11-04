using UnityEngine;
using System.Collections;

public class PushBlock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D col) {

		Debug.Log("collision occurred!");

		Collider2D collider = col.collider;
		if(col.gameObject.CompareTag("Player"))
		{
			//Destroy(col.gameObject);
			ContactPoint2D contact = col.contacts[0];
			Vector3 contactPos = contact.point;
			Vector3 center = collider.bounds.center;

			bool right = contactPos.x > center.x;

			if(right) {

				Debug.Log("collided from right!");

			}
			bool top = contactPos.y > center.y;
		}
	}
}
