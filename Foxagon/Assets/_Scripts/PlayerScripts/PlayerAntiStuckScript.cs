using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private float platformYCord;

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.CompareTag("Ground"))
		{
			platformYCord = other.gameObject.GetComponent<Transform>().position.y;
		}
	}
}
