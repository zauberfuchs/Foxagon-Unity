using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControllerUnderlay : MonoBehaviour 
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
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * speed, 0f);
			rb.transform.position = new Vector3(GameObject.Find("Player").GetComponent<PlayerController>().transform.position.x + 6, -8.75f, -0.000001f);
        }
    }
}
