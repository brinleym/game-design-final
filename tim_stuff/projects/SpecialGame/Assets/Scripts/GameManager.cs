using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public BoardManager boardScript;


	// Use this for initialization
	void Awake() 
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
		boardScript = GetComponent<BoardManager>();
		InitGame();	
	}

	public void GameOver()
	{
		enabled = false;
	}

	void InitGame()
	{
		boardScript.SetupScene();
	}
}
