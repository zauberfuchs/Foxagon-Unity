using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float right;
    public float force;

    private Rigidbody2D rigidBody2D;
    private PlayerCollisionScript playerCollision;

    [SerializeField]
    private float canJump = 0.0f;
    private float rotationTime = 0f;
    
    private Animator anim;

    private bool hasRotated;
    private bool hasJumped;
    private bool rotate;

    private Collision2D currentCollision;
    private BoxCollider2D currentBoxCollider;
    // private float previousPosX = 0;

         private float spincount;
         private float jumpCount;
         private float degree;
         private float spinspeed;
         [HideInInspector]
         public Quaternion startingRotation;


        
    void Start ()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        playerCollision = GetComponent<PlayerCollisionScript>();
        // anim = GetComponent<Animator>();
        //anim.enabled = false;
        MyVariableStorage.performsRestart = false;
         startingRotation = this.transform.rotation;
        // endRotation = new GameObject();


        jumpCount = 0;
        spincount = 0;
        degree = 0;
        spinspeed = 10;
    }
                  
        




    public bool HasJumped 
    {
        get{
            return hasJumped;
        }
        set {
            hasJumped = value;
        }
    }

   public bool HasRotated
   {
        get
        {
            return hasRotated;
        }
        set
        {
            hasRotated = value;
        }
    }

    public float CanJump 
	{
		get {
			return canJump;
		}
		set {
			canJump = value;
		}
	}

    void FixedUpdate()
    {   
        Movement();
        Jump();
        Rotate();
    }

    void Movement ()
    {
        if(!MyVariableStorage.performsRestart)
        {
            rigidBody2D.velocity = new Vector2(right,rigidBody2D.velocity.y);
        }
    }

    void Jump () 
    {
        if (Input.GetKey(KeyCode.Space) && (playerCollision.Grounded == true) && Time.time > canJump && !MyVariableStorage.performsRestart)
        {
            rigidBody2D.velocity = new Vector2(right, force);
            canJump = Time.time + 0.30f;
            hasJumped = true;
            // transform.rotation = startingRotation;
            degree = 180;
        }
    }


    void Rotate()
    {  
       if (hasJumped && spincount < degree) {
                 transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, degree), 500 * Time.deltaTime);
              // transform.rotation = transform.Rotate();
                 spincount += 1;
             } else {
                 spincount = 0;
             }
    }
































































































    // void Jump () 
    // {
    //     if (Input.GetKey(KeyCode.Space) && (playerCollision.Grounded == true) && Time.time > canJump && !MyVariableStorage.performsRestart)
    //     {
    //         rigidBody2D.velocity = new Vector2(right, force);
    //         // transform.rotation = Vector3.Lerp(Vector3.zero, Vector3.up, rotationTime);
    //         // anim.Play("PlayerRotate", -1, 0);
    //         // RotateLeft();
    //         // transform.RotateAround(transform.position, Vector3.back, 500);

    //         // StopAllCoroutines();
    //         // StartCoroutine(Rotate(180));
    //         // Rotate();
    //         canJump = Time.time + 0.30f;
    //         hasJumped = true;

    //         // transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 1800), spinspeed * Time.deltaTime);

    //     }
    // }


    // void DoABarrelRoll()
    // {
    //     if ((playerCollision.CurrentCollision.transform.position.x + 
    //         (playerCollision.CurrentBoxCollider.size.x / 2) + 0.5 < rigidBody2D.transform.position.x) && 
    //         (playerCollision.CurrentCollision.gameObject.CompareTag("Ground")) && 
    //         (rigidBody2D.velocity.y < 0) &&
    //         (!Input.GetKey(KeyCode.Space)) &&
    //         (hasJumped == false) &&
    //         (hasRotated == false))
    //     {   
    //         anim.Play("PlayerFall", -1, 0);
    //         hasRotated = true;
    //     }
    // }


    // void RotateLeft()
    // {
    // Quaternion oldRotation = transform.rotation;
    // transform.Rotate(0,0,80);
    // Quaternion newRotation= transform.rotation;
   
    // for (float t = 0.0f; t <= 100; t += Time.deltaTime)
    //     {
    //         transform.rotation = Quaternion.Slerp(oldRotation, newRotation, t);
    //         yield return null;
    //     }
   
    // transform.rotation = newRotation; // To make it come out at exactly 90 degrees
           
    // }
    // private Quaternion startingRotation;
    // public float speed = 10;

    // IEnumerator Rotate(float rotationAmount)
    // {
    //     Quaternion finalRotation = Quaternion.Euler( 0, 0, rotationAmount ) * startingRotation;

    //     while(this.transform.rotation != finalRotation){
    //         this.transform.rotation = Quaternion.Lerp(this.transform.rotation, finalRotation, Time.deltaTime*speed);
    //         yield return 0;
    //     }
    // }



    // void Rotate()
    // {  
    //    if (hasJumped && spincount < 499) {
    //              transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 180), 900 * Time.deltaTime);
    //              spincount += 500;
    //          } else {
    //              spincount = 0;

    //          }

    // }



}
