using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    private GameObject[] cube = null;
    public GameObject pickup;

    public float speed;

    private Rigidbody rb;

    public Text scoreText;
    private int score;

    // Use this for initialization
    void Start () {
        Vector3[] vectors = new Vector3[8];
        Color[] color = new Color[2];

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

        rb = GetComponent<Rigidbody>();
        score = 0;
        SetScoreText();

        cube = new GameObject[8];

        for (int i = 0; i < 8; i++)
        {
            cube[i] = GameObject.Instantiate(pickup);
            cube[i].transform.position = vectors[i];
            cube[i].GetComponent<Renderer>().material.color = color[i % 2];

            cube[i].gameObject.SetActive(true);

            var cubeScript = cube[i].GetComponent<Cube>();

            cubeScript.setUp(i);
        }
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider collect)
    {
        if (collect.gameObject.CompareTag("Pickup"))
        {
            collect.gameObject.SetActive(false);
            score += collect.gameObject.GetComponent<Cube>().getPoints();        
            SetScoreText();
        }
    }

    void SetScoreText()
    {
        scoreText.text = "SCORE: " + score.ToString();
    }
}
