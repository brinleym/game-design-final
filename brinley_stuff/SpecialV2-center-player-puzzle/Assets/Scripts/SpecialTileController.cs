using UnityEngine;
using System.Collections;

public class SpecialTileController : MonoBehaviour {

	public string color;
	public int gate_num;

	private GameObject[] gates;

	// Use this for initialization
	void Start () {

		gates = GameObject.FindGameObjectsWithTag("Gate" + gate_num);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// if player has key and matches color, then unlock
	void OnTriggerEnter2D(Collider2D collider)
	{

		Debug.Log("something on me!");
		Debug.Log(collider.gameObject.name);

		if(collider.gameObject.name.ToLower().Contains(color)) {
			Debug.Log("blue box on me!");
			if(color == "blue") {
				gates[0].GetComponent<Animator>().Play ("Gate_Open");
				gates[1].GetComponent<Animator>().Play ("Gate_Open");
			}
			else {
				gates[0].GetComponent<Animator>().Play ("Gate_Open");
			}
		}
		

	}
}
