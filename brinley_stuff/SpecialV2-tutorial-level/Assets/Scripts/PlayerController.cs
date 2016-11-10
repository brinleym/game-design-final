using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public LayerMask BlockingLayer;
	public float moveTime = 0.1f;
	public KeyCode left;
	public KeyCode right;
	public KeyCode up;
	public KeyCode down;
	public KeyCode action;

	private Rigidbody2D playerRB2D;
	private BoxCollider2D playerCollider;
	private float inverseMoveTime;
	private Animator animator;

	// Use this for initialization
	void Start () 
	{
		playerRB2D = GetComponent<Rigidbody2D>();
		playerCollider = GetComponent<BoxCollider2D>();
		inverseMoveTime = 1f / moveTime;
		animator = GetComponent<Animator>();
	}

	// Update checks for key strokes from the player
	void Update () 
	{
		Vector3 newPosition = playerRB2D.position;

		// for each direction, get new position, adjust animator and check if blocked
		if (Input.GetKeyDown (left)) {
			newPosition.x = newPosition.x - 1;
			animator.SetInteger ("direction", 3);
			AttemptMove (newPosition);
		} else if (Input.GetKeyDown (right)) {
			newPosition.x = newPosition.x + 1;
			animator.SetInteger ("direction", 2);
			AttemptMove (newPosition);
		} else if (Input.GetKeyDown (up)) {
			newPosition.y = newPosition.y + 1;
			animator.SetInteger ("direction", 1);
			AttemptMove (newPosition);
		} else if (Input.GetKeyDown (down)) {
			newPosition.y = newPosition.y - 1;
			animator.SetInteger ("direction", 0);
			AttemptMove (newPosition);
		} else if (Input.GetKeyDown (action)) {
			animator.SetTrigger ("fire");
		}
	}

	private void AttemptMove(Vector3 end)
	{
		// disable own collider before casting ray
		playerCollider.enabled = false;
		RaycastHit2D hit = Physics2D.Linecast(playerRB2D.position, end, BlockingLayer);
		playerCollider.enabled = true;

		// move only if no collision
		if (hit.collider == null) {
			StartCoroutine (SmoothMovement (playerRB2D, end));
		} else { 
			// otherwise, check for collision with box
			if (hit.collider.gameObject.tag == "Box") {

				// get the box collided with and send to movement
				Rigidbody2D box = hit.collider.gameObject.GetComponent<Rigidbody2D>();
				AttemptPush (box, end);
			}
		}
	}

	private void AttemptPush(Rigidbody2D box, Vector3 end)
	{
		Vector3 newBoxPosition = box.position;

		// see which direction box was pushed from and get new possible position
		if (animator.GetInteger ("direction") == 3) {
			newBoxPosition.x = box.position.x - 1;
		} else if (animator.GetInteger ("direction") == 2) {
			newBoxPosition.x = box.position.x + 1;
		} else if (animator.GetInteger ("direction") == 1) {
			newBoxPosition.y = box.position.y + 1;
		} else if (animator.GetInteger ("direction") == 0) {
			newBoxPosition.y = box.position.y - 1;
		}

		// check if new box position is blocked
		BoxCollider2D collider = box.GetComponent<BoxCollider2D>();
		collider.enabled = false;
		RaycastHit2D boxHit = Physics2D.Linecast(box.position, newBoxPosition, BlockingLayer);
		collider.enabled = true;

		// move the box if nothing is collider
		if (boxHit.collider == null) {
			StartCoroutine (SmoothMovement (box, newBoxPosition));
		}
	}

	private IEnumerator SmoothMovement(Rigidbody2D rb, Vector3 end)
	{
		float sqrRemainingDistance = (rb.transform.position - end).sqrMagnitude;

		//While that distance is greater than a very small amount (Epsilon, almost zero):
		while(sqrRemainingDistance > float.Epsilon)
		{
			//Find a new position proportionally closer to the end, based on the moveTime
			Vector3 newPosition = Vector3.MoveTowards(rb.position, end, inverseMoveTime * Time.deltaTime);

			//Call MovePosition on attached Rigidbody2D and move it to the calculated position.
			rb.MovePosition (newPosition);

			//Recalculate the remaining distance after moving.
			sqrRemainingDistance = (rb.transform.position - end).sqrMagnitude;

			//Return and loop until sqrRemainingDistance is close enough to zero to end the function
			yield return null;
		}
	}
}
