using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_moon : MonoBehaviour 
{

	

    public GameObject player;

    private Rigidbody rb;
    public float speed = 0;

    //    public float right;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


        if (GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.x > 0)
        {
             rb.transform.position = new Vector3(GameObject.Find("Player").GetComponent<PlayerController>().transform.position.x +5, 8f, 2);
        }
    }
}