using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndingScript : MonoBehaviour {

	public Sprite image1, image2, image3;
	private Image currentImage;
	float startTime, curTime;

	void Start () {
		currentImage = GetComponent<Image>();
		currentImage.sprite = image1;
		startTime = Time.time;
	}

	void Update()
	{
		curTime = Time.time;
		if (curTime - startTime > 6)
			currentImage.sprite = image3;
		else if (curTime - startTime > 3)
			currentImage.sprite = image2;
	}
}
