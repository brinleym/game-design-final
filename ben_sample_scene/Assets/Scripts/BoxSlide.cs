using UnityEngine;
using System.Collections;

public class BoxSlide : MonoBehaviour {

    // position data
    //public float x_pos;
    //public float y_pos;

    //size data
    public float width;
    public float height;

    // Use this for initialization
    void Start () {
        width = 512 * this.transform.localScale.x;
        height = 512 * this.transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
        //x_pos = this.transform.position.x;
        //y_pos = this.transform.position.y;
    }

    void OnCollisionEnter (Collision col) {
        if (col.gameObject.tag == "Player") {
            if (col.transform.position.x > this.transform.position.x)
                this.transform.Translate(-width, 0, 0);
            else if (col.transform.position.y > this.transform.position.y)
                this.transform.Translate(0, -height, 0);
            else if (col.transform.position.x < this.transform.position.x)
                this.transform.Translate(width, 0, 0);
            else if (col.transform.position.y < this.transform.position.y)
                this.transform.Translate(0, height, 0);
        }
    }
}
