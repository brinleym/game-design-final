using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public LayerMask BlockingLayer, KeyLayer;
	public float moveTime = 0.05f;
	public KeyCode left, right, up, down, action, restart;
	public string colorPower;
	public AudioSource[] sounds;
	public GameObject hitBox;

	private Rigidbody2D playerRB2D;
	private BoxCollider2D playerCollider;
	private float inverseMoveTime;
	private Animator animator;
	private float lastTime;
	private bool haveKey;

	// Use this for initialization
	void Start () 
	{
		playerRB2D = GetComponent<Rigidbody2D>();
		playerCollider = GetComponent<BoxCollider2D>();
		inverseMoveTime = 1f / moveTime;
		animator = GetComponent<Animator>();
		lastTime = Time.time;
		haveKey = false;
	}

	// Update checks for key strokes from the player
	void Update () 
	{
		Vector3 newPosition = playerRB2D.position;

		// for each direction, get new position, adjust animator and check if blocked
		if (Input.GetKey(left) && (Time.time - lastTime > 0.15f)) {
			newPosition.x = newPosition.x - 1;
			animator.SetInteger ("direction", 3);
			AttemptMove (newPosition);
		} else if (Input.GetKey(right) && (Time.time - lastTime > 0.15f)) {
			newPosition.x = newPosition.x + 1;
			animator.SetInteger ("direction", 2);
			AttemptMove (newPosition);
		} else if (Input.GetKey(up) && (Time.time - lastTime > 0.15f)) {
			newPosition.y = newPosition.y + 1;
			animator.SetInteger ("direction", 1);
			AttemptMove (newPosition);
		} else if (Input.GetKey(down) && (Time.time - lastTime > 0.15f)) {
			newPosition.y = newPosition.y - 1;
			animator.SetInteger ("direction", 0);
			AttemptMove (newPosition);
		} else if (Input.GetKeyDown (action)) {
			animator.SetTrigger ("ability");
		}

		// restart room
		else if (Input.GetKeyDown(restart)) {
			int scene = SceneManager.GetActiveScene().buildIndex;
			SceneManager.LoadScene (scene, LoadSceneMode.Single);
		}

	}

	// function for a player trying to move to position 'end'
	private void AttemptMove(Vector3 end)
	{
		// disable own collider before casting ray
		playerCollider.enabled = false;
		RaycastHit2D hit = Physics2D.Linecast(playerRB2D.position, end, BlockingLayer);
		playerCollider.enabled = true;

		// move only if no collision
		if (hit.collider == null) {

			// check for key and move
			playerCollider.enabled = false;
			hit = Physics2D.Linecast(playerRB2D.position, end, KeyLayer);
			playerCollider.enabled = true;

			// create temp hitbox before movement to prevent other player collision (disable when done)
			GameObject tempHitBox = (GameObject) Instantiate(hitBox, end, Quaternion.identity);
			StartCoroutine(SmoothMovement (playerRB2D, end));
			Destroy (tempHitBox, moveTime);

			// pick up key if collided and is of correct color
			if (hit.collider != null && hit.collider.name.Contains(colorPower)) {

				// play sound effect, remove key, set player's haveKey variable
				AudioSource source = hit.collider.GetComponent<AudioSource>();
				AudioClip clip = source.clip;
				source.Play();
				Destroy (hit.collider.gameObject, clip.length);
				haveKey = true;

				// notify UI that key has been picked up
				//UIScript ui = GameObject.Find("Canvas/" + colorPower).GetComponent<UIScript>();
				//ui.ObtainKey();
			}
		} 
		// otherwise, check for collision with boxes and doors
		else { 
			if (hit.collider.gameObject.tag == "Box") {

				// get the box collided with and send to AttemptPush if matching color
				Rigidbody2D box = hit.collider.gameObject.GetComponent<Rigidbody2D>();
				if (box.name.Contains(colorPower))
					AttemptPush(box, end);
			} 
		}

		// update the time variable
		lastTime = Time.time;
	}

	// function that takes a box and attempts to push it to position 'end'
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
			box.GetComponent<AudioSource>().Play(); // play sound effect from box
		}
	}

	// function to see if a player has picked up their key
	public bool checkKey()
	{
		return haveKey;
	}

	// function from RogueLike2D to create smooth movement of characters
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
