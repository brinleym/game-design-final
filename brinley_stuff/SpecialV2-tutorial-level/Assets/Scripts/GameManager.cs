using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public ScriptableObject[] levels;

	void Awake() 
	{
		// make sure only one instance of game
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		InitGame ();
	}

	void GameOver()
	{
		
	}

	void InitGame()
	{



	}
	void Update() {

		if(Input.GetKeyDown(KeyCode.R)) {

			Application.LoadLevel(Application.loadedLevel); // trigger restart

		}


	}
}
