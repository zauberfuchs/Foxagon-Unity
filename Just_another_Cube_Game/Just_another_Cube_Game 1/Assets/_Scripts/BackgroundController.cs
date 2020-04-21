using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

    public GameObject player;

    private Rigidbody rb;
    public float speed = 0;

    //    public float right;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * speed, 0f);
            rb.transform.position = new Vector3(GameObject.Find("Player").GetComponent<PlayerController>().transform.position.x + 6, 5.5f, 0.1f);
        }
    }
}