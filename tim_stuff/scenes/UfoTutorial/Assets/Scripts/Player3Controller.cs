using UnityEngine;
using System.Collections;

public class Player3Controller : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.J))
        {
            			Vector3 position = this.transform.position;
            			position.x--;
            			this.transform.position = position;
            
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Vector3 position = this.transform.position;
            position.x++;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Vector3 position = this.transform.position;
            position.y++;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Vector3 position = this.transform.position;
            position.y--;
            this.transform.position = position;
        }

    }
}
