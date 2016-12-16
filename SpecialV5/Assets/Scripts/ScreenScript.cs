using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScreenScript : MonoBehaviour {

	private int level;

	void Start () {
		level = SceneManager.GetActiveScene().buildIndex;
	}

	void Update () {
		if (Input.GetKey(KeyCode.Space)) {
			SceneManager.LoadScene(level+1, LoadSceneMode.Single);
		}	
	}
}
