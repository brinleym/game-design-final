using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour {

	private int level;

	// Use this for initialization
	void Start () {
		level = 0;
	}

	// load next level on exiting (this is still buggy!)
	void OnTriggerEnter2D(Collider2D collider)
	{
		level += 1;
		SceneManager.LoadScene(level);
	}
}
