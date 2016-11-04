using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		// player movement code (working)
		//transform.position += transform.right *Input.GetAxis(axisName)* speed;
		if (Input.GetKeyDown(KeyCode.A))
		{
			Vector2 position = this.transform.position;
			position.x = position.x - 1;
			this.transform.position = position;
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			Vector2 position = this.transform.position;
			position.x = position.x + 1;
			this.transform.position = position;
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			Vector2 position = this.transform.position;
			position.y = position.y + 1;
			this.transform.position = position;
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			Vector2 position = this.transform.position;
			position.y = position.y - 1;
			this.transform.position = position;
		}

	}
		
//	void OnCollisionEnter2D (Collision2D col) {
//
//		Debug.Log("collision occurred!");
//
//		Collider2D collider = col.collider;
//		if(col.gameObject.CompareTag("Block"))
//		{
//			//Destroy(col.gameObject);
//			ContactPoint2D contact = col.contacts[0];
//			Vector3 contactPos = contact.point;
//			Vector3 center = collider.bounds.center;
//
//			bool right = contactPos.x > center.x;
//
//			if(right) {
//
//				Debug.Log("collided from right!");
//
//			}
//			bool top = contactPos.y > center.y;
//		}
//	}
}