using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public LayerMask BlockingLayer;
	public float moveTime = 0.1f;

	private Rigidbody2D rb2D;
	private BoxCollider2D boxCollider;
	private float inverseMoveTime;
	private Animator animator;

	// Use this for initialization
	void Start () 
	{
		rb2D = GetComponent<Rigidbody2D>();
		boxCollider = GetComponent<BoxCollider2D>();
		inverseMoveTime = 1f / moveTime;
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () 
	{
		// variables for current position and potential new position
		Vector3 newPosition = rb2D.position;

		if (Input.GetKeyDown(KeyCode.A))
		{
			newPosition.x = newPosition.x - 1;
			animator.SetInteger("direction", 3);
			AttemptMove(newPosition);
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			newPosition.x = newPosition.x + 1;
			animator.SetInteger("direction", 2);
			AttemptMove(newPosition);
		}
		else if (Input.GetKeyDown(KeyCode.W))
		{
			newPosition.y = newPosition.y + 1;
			animator.SetInteger("direction", 1);
			AttemptMove(newPosition);
		}
		else if (Input.GetKeyDown(KeyCode.S))
		{
			newPosition.y = newPosition.y - 1;
			animator.SetInteger("direction", 0);
			AttemptMove(newPosition);
		}
	}

	private void AttemptMove(Vector3 end)
	{
		// disable own collider before casting ray
		boxCollider.enabled = false;
		RaycastHit2D hit = Physics2D.Linecast(rb2D.position, end, BlockingLayer);
		boxCollider.enabled = true;

		// move only if no collision
		if (hit.collider == null) {
			StartCoroutine (SmoothMovement (end));
		}
	}

	private IEnumerator SmoothMovement(Vector3 end)
	{
		float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

		//While that distance is greater than a very small amount (Epsilon, almost zero):
		while(sqrRemainingDistance > float.Epsilon)
		{
			//Find a new position proportionally closer to the end, based on the moveTime
			Vector3 newPosition = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);

			//Call MovePosition on attached Rigidbody2D and move it to the calculated position.
			rb2D.MovePosition (newPosition);

			//Recalculate the remaining distance after moving.
			sqrRemainingDistance = (transform.position - end).sqrMagnitude;

			//Return and loop until sqrRemainingDistance is close enough to zero to end the function
			yield return null;
		}
	}
}
