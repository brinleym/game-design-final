using UnityEngine;
using System.Collections;

public class GateScript : MonoBehaviour {

	private Animator gateAnim;
	private BoxCollider2D gateCollider;

	// Use this for initialization
	void Start () {

		gateAnim = GetComponent<Animator>();
		gateCollider = GetComponent<BoxCollider2D>();
		gateAnim.SetBool("gateOpen", false);

	}

	// external gate open function, play animation and disable collider
	public void GateOpen()
	{
		gateAnim.SetBool("gateOpen", true);
		gateCollider.enabled = false;
	}

	// external gate close function, play animation and enable collider
	public void GateClose()
	{
		gateAnim.SetBool("gateOpen", false);
		gateCollider.enabled = true;
	}
		
}
