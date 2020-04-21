using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

   // public   GameObject  player;

    public   float       speed = 0;
    public   float       xOffset;
    public   float       yOffset;
    public   float       zOffset;


	public   string 	 SortingLayerName;


    private  Rigidbody   rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<Renderer>().sortingLayerName = SortingLayerName;
    }

    void LateUpdate()
    {
        if (GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * speed, 0f);
            rb.transform.position = new Vector3(GameObject.Find("Player").GetComponent<Rigidbody2D>().transform.position.x + xOffset, yOffset, zOffset);
        }
    }
}