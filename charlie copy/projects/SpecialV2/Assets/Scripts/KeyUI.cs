using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeyUI : MonoBehaviour {
	Image myImageComponent;
	public Sprite haveKey;
	public Sprite noKey;
	// Use this for initialization
	void Start () {
		myImageComponent = GetComponent<Image> ();
		SetNoKey();
	}


	public void SetNoKey() //method to set our first image
	{
		myImageComponent.sprite = noKey;
	}

	public void SetHaveKey(){
		myImageComponent.sprite = haveKey;
	}
}