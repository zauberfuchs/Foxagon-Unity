using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump2D : MonoBehaviour
{

    public  float                               playerSpeed;
    public  float                               jumpHeight;
    public  ParticleSystem                      ps;

    private Rigidbody2D                         rb;
    private RaycastHit2D                        hit;
    private Vector2                             vel;
    private ParticleSystem.EmissionModule       e;
    private float                               a;

    void Start()
    {
        e = ps.emission;
        rb = GetComponent<Rigidbody2D>();


    }
    // The Physics Calculations, which let's my Player Jump and Rotating
    void FixedUpdate()
    {

        // Debug.Log(GetComponent<RectTransform>().localRotation.z % 90);
        // Saving the currently Velocity from the Player into an Vector3 variable
        // Changing the Velocity in X direction by 10
        // Putting the changed Vector3 Velocity into my players Velocity
        // Makes sure no restart is being performed
        if (!MyVariableStorage.performsRestart)
        {
            Vector2 vel = rb.velocity;
            vel.x = playerSpeed;
            rb.velocity = vel;
        }
        // Using a Raycast to determine, if my Player is on the a ground
        hit = Physics2D.Raycast(transform.position, Vector2.down, GetComponent<BoxCollider2D>().size.y / 2 + 0.21f);
        if (hit.collider != null && !MyVariableStorage.performsRestart)
        {

            // Unfreezing the X and Y Rotations because we are on ground!
            rb.constraints = RigidbodyConstraints2D.None;

            // Jumps if you press the "Space" key
            if (Input.GetKey(KeyCode.Space))
            {
                // Resetting my Jump Velocity to prevent that i add another Velocity in Y direction 
                // on top of my Jump before the Gravity fully done its job
                rb.velocity = new Vector2(rb.velocity.x, 0);
                // My Jump Height
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            }



            // Cause to Strange Behaviors on ground the cube does only sets him plane to 99% the last 1% sometimes bugs.
            // so i manually set him plane
            if(transform.rotation.eulerAngles.z % 90 != 0)
            {
                Debug.Log(transform.rotation.eulerAngles.z % 90);
                if (transform.rotation.eulerAngles.z % 90 <= 1)
                {
                    Debug.Log("new z1");
                    a = -(transform.rotation.eulerAngles.z % 90);
                    transform.Rotate(0, 0, a);

                }
                else if ((transform.rotation.eulerAngles.z + 1) % 90 <= 1)
                {
                    Debug.Log("new z2");
                    a = -((transform.rotation.eulerAngles.z + 1) % 90);
                    transform.Rotate(0, 0, a);
                }
            }




        }
        else
        {
            // Letting my Cube Rotate in Vector3.back direction with speed modifier  1.135f // 2.05
            // Freezing all my Rotations in X,Y,Z Axis to prevent strange physics behavior
            
            transform.Rotate(Vector3.back * 1.535f);
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        e.enabled = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        e.enabled = false;
    }

}