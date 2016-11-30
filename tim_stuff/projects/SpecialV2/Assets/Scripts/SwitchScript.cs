using UnityEngine;
using System.Collections;

public class SwitchScript : MonoBehaviour {

	public string color;
	private bool activate;
	private SwitchCheckScript script;

	// initialize switch activation to false
	void Start () {
		activate = false;
		script = (SwitchCheckScript) GameObject.Find("KeySpawn").GetComponent(typeof(SwitchCheckScript));
	}

	// function to check switch status
	public bool CheckSwitch() 
	{
		return activate;
	}
	
	// code that executes when anything has touched the switch
	void OnTriggerEnter2D(Collider2D collider)
	{
		// get whatever has touched the switch
		Rigidbody2D rb2d = collider.gameObject.GetComponent<Rigidbody2D>();

		// activate only if correct color player or box is on switch
		if (rb2d.name.Contains(color)) {
			activate = true;
			script.CheckAllSwitches(); // check all other switches
		}
	}

	// code that executes when anything has left the switch
	void OnTriggerExit2D(Collider2D collider)
	{
		activate = false;
	}
}
