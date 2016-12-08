using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScript : MonoBehaviour {

	public Sprite noKey, haveKey;
	private Image currentImage;

	// initialize each level with a light key (not having key)
	void Start () {
		currentImage = GetComponent<Image>();
		currentImage.sprite = noKey;
	}

	// change the key image to have a key when picked up
	public void ObtainKey()
	{
		currentImage.sprite = haveKey;
	}
}
