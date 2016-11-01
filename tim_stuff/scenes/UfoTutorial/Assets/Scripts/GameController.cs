using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject player;
	public Vector2 playerInitPos;
	public GameObject player2;
	public Vector2 player2InitPos;
	public GameObject player3;
	public Vector2 player3InitPos;

	// Use this for initialization
	void Start () {

		//spawn players
		Vector2 playerSpawnPosition = playerInitPos;
		Vector2 player2SpawnPosition = player2InitPos;
		Vector2 player3SpawnPosition = player3InitPos;
		Quaternion spawnRotation = Quaternion.identity;

		Instantiate (player, playerSpawnPosition, spawnRotation);
		Instantiate (player2, player2SpawnPosition, spawnRotation);
		Instantiate (player3, player3SpawnPosition, spawnRotation);

	}

	// Update is called once per frame
	void Update () {

	}
}
