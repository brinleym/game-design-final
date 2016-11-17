using UnityEngine;
using System.Collections;

public class Player : MovingObject {

	// Use this for initialization
	protected override void Start () 
	{
		base.Start();
	}
	
	// Update is called once per frame
	private void Update () 
	{
		int horizontal = 0;
		int vertical = 0;

		horizontal = (int) (Input.GetAxisRaw ("Horizontal"));
		vertical = (int) (Input.GetAxisRaw ("Vertical"));

		if(horizontal != 0)
		{
			vertical = 0;
		}

		//Check if we have a non-zero value for horizontal or vertical
		if(horizontal != 0 || vertical != 0)
		{
			//Call AttemptMove passing in the generic parameter Wall, since that is what Player may interact with if they encounter one (by attacking it)
			//Pass in horizontal and vertical as parameters to specify the direction to move Player in.
			AttemptMove<Box> (horizontal, vertical);
		}
	}
		
	protected override void AttemptMove <T> (int xDir, int yDir)
	{
		base.AttemptMove <T> (xDir, yDir);
		RaycastHit2D hit;

		//If Move returns true, meaning Player was able to move into an empty space.
		if (Move (xDir, yDir, out hit)) 
		{
			//Call RandomizeSfx of SoundManager to play the move sound, passing in two audio clips to choose from.
		}
	}
		
	// if cannot move, implement box push mechanics here
	protected override void OnCantMove <T> (T component)
	{

	}


	//OnTriggerEnter2D is sent when another object enters a trigger collider attached to this object (2D physics only).
	private void OnTriggerEnter2D (Collider2D other)
	{
		//Check if the tag of the trigger collided with is key
		if(other.tag == "Key")
		{
			other.gameObject.SetActive (false);
		}

	}

}
