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
			position.x = position.x - 10;
			this.transform.position = position;
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			Vector2 position = this.transform.position;
			position.x = position.x + 10;
			this.transform.position = position;
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			Vector2 position = this.transform.position;
			position.y = position.y + 10;
			this.transform.position = position;
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			Vector2 position = this.transform.position;
			position.y = position.y - 10;
			this.transform.position = position;
		}

	}

	// push code
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.CompareTag ("Block"))
		{
			Vector2 position = gameObject.transform.position;
			position.y = position.y + 20;
			gameObject.transform.position = position;
		}
			
	}

}