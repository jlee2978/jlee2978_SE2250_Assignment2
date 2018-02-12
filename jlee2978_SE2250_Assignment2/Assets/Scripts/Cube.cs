using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {
    private int points = 0;

    private Vector3[] vectors = new Vector3[8];
    private Color[] color = new Color[2];

	// Use this for initialization
	void Start () {
        color[0] = Color.yellow;
        color[1] = Color.gray;

        // positions of pickup object
        vectors[0] = new Vector3(3, 1.02f, 0);
        vectors[1] = new Vector3(3, 1.02f, 2);
        vectors[2] = new Vector3(0, 1.02f, 4);
        vectors[3] = new Vector3(-3, 1.02f, 2);
        vectors[4] = new Vector3(-1, 1.02f, 0);
        vectors[5] = new Vector3(-3, 1.02f, -2);
        vectors[6] = new Vector3(0, 1.02f, -4);
        vectors[7] = new Vector3(2, 1.02f, -3);
    }

    // Update is called once per frame
    /*void Update () {
		
	}*/
    public void setUp(int i)
    {
        switch (i)
        {
            case 1:
            case 3:
            case 5:
            case 7:
                setPoints(100);
                break;
            case 0:
            case 2:
            case 4:
            case 6:
                setPoints(500);
                break;
        }
    }

    public void setPoints(int points)
    {
        this.points = points;
    }

    public int getPoints()
    {
        return this.points;
    }
}
