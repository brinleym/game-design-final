using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb2D;               //The Rigidbody2D component attached to this object.
	private float inverseMoveTime;          //Used to make movement more efficient.
	public LayerMask BlockingLayer;

	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{
		// variables for current position and potential new position
		Vector2 position = this.transform.position;
		Vector2 new_post = position;

		if (Input.GetKeyDown(KeyCode.A))
		{
			new_post.x = new_post.x - 1;
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			new_post.x = new_post.x + 1;
		}
		else if (Input.GetKeyDown(KeyCode.W))
		{
			new_post.y = new_post.y + 1;
		}
		else if (Input.GetKeyDown(KeyCode.S))
		{
			new_post.y = new_post.y - 1;
		}
			
		this.transform.position = new_post;

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