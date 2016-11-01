using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // player movement code (working)
        //transform.position += transform.right *Input.GetAxis(axisName)* speed;
        if (Input.GetKeyDown(KeyCode.A))
        {
            //			Vector3 position = this.transform.position;
            //			position.x--;
            //			this.transform.position = position;
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 position = this.transform.position;
            position.x++;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Vector3 position = this.transform.position;
            position.y++;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 position = this.transform.position;
            position.y--;
            this.transform.position = position;
        }

    }
}
