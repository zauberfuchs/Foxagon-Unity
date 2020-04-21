using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerCollisionScript : MonoBehaviour {


	private bool grounded;
	private Rigidbody2D rb;
	private BoxCollider2D currentBoxCollider;
	private Collision2D currentCollision;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
	}


	
	void OnCollisionEnter2D(Collision2D other)
    {   
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<PlayerController>().right,0);
        this.GetComponent<PlayerController>().HasJumped = false;
        transform.rotation = this.GetComponent<PlayerController>().startingRotation;

        currentBoxCollider = other.gameObject.GetComponent<BoxCollider2D>();
        currentCollision = other;

        if (other.gameObject.CompareTag("Ground") && Input.GetKey(KeyCode.Space))
        {
            grounded = true;
        }
        if (other.gameObject.CompareTag("Ground"))   
        {
            grounded = true;
            // transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            grounded = true;
            if (!Input.GetKey(KeyCode.Space))
            {
                // transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
        }
    }

   
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            grounded = false;
        }
        this.GetComponent<PlayerController>().HasRotated = false;
    }

    public bool Grounded 
    {
    	get
    	{
    		return grounded;
    	}
    	set
    	{
    		grounded = value;
    	}
    }

    public BoxCollider2D CurrentBoxCollider
    {
    	get
    	{
    		return currentBoxCollider;
    	}
    	set
    	{
    		currentBoxCollider = value;
    	}
    }

    public Collision2D CurrentCollision
    {
    	get
    	{
    		return currentCollision;
    	}
    	set
    	{
    		currentCollision = value;
    	}
    }



}
