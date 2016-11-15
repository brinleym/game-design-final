using UnityEngine;
using System.Collections;

public class Loader2 : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;

    public GameObject door, exit;
    public GameObject[] floor;
    public GameObject[] wall;
    public GameObject[] boxes;
    public GameObject[] keys;
    public GameObject[] locks;

    // Use this for initialization
    void Start()
    {
        int rows = 14;
        int cols = 17;
        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                if (i == 0 || i == cols - 1 || j == 0 || j == rows - 1)
                {
                    if (i == 8 && j == 13)
                    {
                    }
                    else if (i == 7 && j == 0)
                    {
                    }
                    else if (i == 8 && j == 0)
                    {
                    }
                    else if (i == 9 && j == 0)
                    {
                    }
                    else
                        Instantiate(wall[0], new Vector3(i, j, 0f), Quaternion.identity);
                }
                else
                    Instantiate(floor[0], new Vector3(i, j, 0f), Quaternion.identity);
            }
        }

        //Player Starting Squares (No wall to keep them enclosed)
        Instantiate(floor[0], new Vector3(7, 0, 0f), Quaternion.identity);
        Instantiate(floor[0], new Vector3(8, 0, 0f), Quaternion.identity);
        Instantiate(floor[0], new Vector3(9, 0, 0f), Quaternion.identity);



        //Walls
        for (int i = 2; i < 15; i++)
        {
            if (i == 2)
            {
                for (int j = 3; j < 10; j++)
                {
                    if (j != 7)
                    {
                        Instantiate(wall[0], new Vector3(i, j, 0f), Quaternion.identity);
                    }
                }
            }
            else if (i == 14)
            {
                for (int j = 3; j < 10; j++)
                {
                    if (j != 5)
                    {
                        Instantiate(wall[0], new Vector3(i, j, 0f), Quaternion.identity);
                    }
                }
            }
            else
            {
                Instantiate(wall[0], new Vector3(i, 2, 0f), Quaternion.identity);
                Instantiate(wall[0], new Vector3(i, 10, 0f), Quaternion.identity);
            }

        }
        for (int j = 4; j < 9; j++)
        {
            if (j == 4)
            {
                for (int i = 4; i < 13; i++)
                {
                    if (i != 10)
                    {
                        Instantiate(wall[0], new Vector3(i, j, 0f), Quaternion.identity);
                    }
                }
            }
            else if (j == 8)
            {
                for (int i = 4; i < 13; i++)
                {
                    if (i != 6)
                    {
                        Instantiate(wall[0], new Vector3(i, j, 0f), Quaternion.identity);
                    }
                }
            }
            else
            {
                Instantiate(wall[0], new Vector3(4, j, 0f), Quaternion.identity);
                Instantiate(wall[0], new Vector3(12, j, 0f), Quaternion.identity);
            }

        }
        Instantiate(boxes[0], new Vector3(15, 2, 0f), Quaternion.identity);
        Instantiate(boxes[0], new Vector3(10, 5, 0f), Quaternion.identity);
        Instantiate(boxes[0], new Vector3(7, 6, 0f), Quaternion.identity);

        Instantiate(boxes[1], new Vector3(13, 4, 0f), Quaternion.identity);
        Instantiate(boxes[1], new Vector3(3, 4, 0f), Quaternion.identity);
        Instantiate(boxes[1], new Vector3(4, 9, 0f), Quaternion.identity);
        Instantiate(boxes[1], new Vector3(12, 9, 0f), Quaternion.identity);
        Instantiate(boxes[1], new Vector3(8, 5, 0f), Quaternion.identity);
        Instantiate(boxes[1], new Vector3(8, 7, 0f), Quaternion.identity);

        Instantiate(boxes[2], new Vector3(1, 3, 0), Quaternion.identity);
        Instantiate(boxes[2], new Vector3(6, 7, 0), Quaternion.identity);
        Instantiate(boxes[2], new Vector3(9, 6, 0), Quaternion.identity);


        Instantiate(player1, new Vector3(7, 0, 0f), Quaternion.identity);
        Instantiate(player2, new Vector3(8, 0, 0f), Quaternion.identity);
        Instantiate(player3, new Vector3(9, 0, 0f), Quaternion.identity);

        Instantiate(door, new Vector3(8, 13, 0f), Quaternion.identity);
        Instantiate(exit, new Vector3(8, 13, 0), Quaternion.identity);

        Instantiate(locks[0], new Vector3(6, 12, 0f), Quaternion.identity);
        Instantiate(locks[1], new Vector3(8, 11, 0f), Quaternion.identity);
        Instantiate(locks[2], new Vector3(10, 12, 0f), Quaternion.identity);

        Instantiate(keys[0], new Vector3(8, 6, 0f), Quaternion.identity);
        Instantiate(keys[1], new Vector3(9, 5, 0f), Quaternion.identity);
        Instantiate(keys[2], new Vector3(7, 7, 0f), Quaternion.identity);
    }
}
