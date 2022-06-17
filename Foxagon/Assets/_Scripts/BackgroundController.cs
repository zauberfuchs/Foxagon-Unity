using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

   // public   GameObject  player;

    public      float       speed = 0;
    public      float       xOffset;
    public      float       yOffset;
    public      float       zOffset;
    public      Rigidbody2D playerRB;

	public      string 	    SortingLayerName;

    private     float       increment = 0.001f;


    private     Rigidbody   rb;

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

            if(SortingLayerName == "Background_Moon" && (transform.position.y - GameObject.Find("Player").GetComponent<Rigidbody2D>().transform.position.y) <= 8.5)
            {
                rb.transform.position = new Vector3(GameObject.Find("Player").GetComponent<Rigidbody2D>().transform.position.x + xOffset
                    , transform.position.y + increment
                    , zOffset);
            }else if (SortingLayerName == "Background_Moon" && (transform.position.y - GameObject.Find("Player").GetComponent<Rigidbody2D>().transform.position.y) > 8.5)
            {
                rb.transform.position = new Vector3(GameObject.Find("Player").GetComponent<Rigidbody2D>().transform.position.x + xOffset
                    , transform.position.y - increment
                    , zOffset);
            }
            else
            {
                rb.transform.position = new Vector3(GameObject.Find("Player").GetComponent<Rigidbody2D>().transform.position.x + xOffset, yOffset, zOffset);
            }

        }
    }
}