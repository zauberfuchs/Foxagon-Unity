using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatformScript : MonoBehaviour {

	private float jumpHeight = 50;

	private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("JumpPlatform"))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(10,50);
            this.GetComponent<PlayerController>().CanJump = Time.time + 0.30f;           
        }
    }
}