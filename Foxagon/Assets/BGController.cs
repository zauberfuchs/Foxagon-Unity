using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour {

	public   GameObject  player;

	public   float       speed = 0;
	public   float       xOffset;
	public   float       yOffset;
	public   float       zOffset;


	public   string 	 SortingLayerName;
	public   int 		 SortingLayerId;


	void LateUpdate()
	{
		if (GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.x > 0)
		{
			GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * speed, 0f);
			transform.position = new Vector3(GameObject.Find("Player").GetComponent<Rigidbody2D>().transform.position.x + xOffset, yOffset, zOffset);
		}
	}
}
