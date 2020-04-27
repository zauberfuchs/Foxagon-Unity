using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump2D : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] public float               playerSpeed;
    [SerializeField] float                      playerJumpHeight;

    [Header("Trail")]
    [SerializeField] ParticleSystem             trailParticleSystem;

    private Rigidbody2D                         playerRigidbody;
    private BoxCollider2D                       playerCollider;
    private LayerMask                           tileMap;

    private RaycastHit2D                        hit;
    private bool                                isGrounded { get; set; }
    private bool                                isJumping { get; set; }
    private bool                                jumpInput;
    private Vector2                             vel;
    private ParticleSystem.EmissionModule       particleSystemEmissionModule;
    private Vector3                             unroundedRotation;

    void Start()
    {
        particleSystemEmissionModule = trailParticleSystem.emission;
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        tileMap = LayerMask.GetMask("Tilemap");

    }

    void Update()
    {
        var keyboard = Keyboard.current;
        if (!isJumping && isGrounded && .spaceKey.wasPressedThisFrame)
            jumpInput = true;

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
            Vector2 vel = playerRigidbody.velocity;
            vel.x = playerSpeed;
            playerRigidbody.velocity = vel;
        }
        if(playerCollider.IsTouchingLayers(tileMap) && !MyVariableStorage.performsRestart)
        // Using a Raycast to determine, if my Player is on the a ground
        //hit = Physics2D.Raycast(transform.position, Vector2.down, GetComponent<BoxCollider2D>().size.y / 2 + 0.21f);
        //Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y + 0.21f, 0));
        //if (hit.collider != null && !MyVariableStorage.performsRestart)
        {
            isGrounded = true;
            isJumping = playerRigidbody.velocity.y > 0.0f ? true : false;
            // Unfreezing the X and Y Rotations because we are on ground!
            playerRigidbody.constraints = RigidbodyConstraints2D.None;

            // Jumps if you press the "Space" key
            if (Input.GetKey(KeyCode.Space) && !isJumping)
            {
                // Resetting my Jump Velocity to prevent that i add another Velocity in Y direction 
                // on top of my Jump before the Gravity fully done its job
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0);
                // My Jump Height
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, playerJumpHeight);
                isJumping = true;
                isGrounded = false;
            }



            // Cause to Strange Behaviors on ground the cube does only sets him plane to 99% the last 1% sometimes bugs.
            // so i manually set him plane


            if (transform.rotation.eulerAngles.z % 90 != 0)
            {
                unroundedRotation = transform.rotation.eulerAngles;
                unroundedRotation.z = Mathf.Round(unroundedRotation.z);
                transform.eulerAngles = unroundedRotation;
                //if (transform.rotation.eulerAngles.z % 90 <= 1)
                //{
                //    a = -(transform.rotation.eulerAngles.z % 90);
                //    transform.Rotate(0, 0, a);
                //    transform.rotation.eulerAngles.z = 2f;
                //}
                //else if ((transform.rotation.eulerAngles.z + 1) % 90 <= 1)
                //{
                //    a = -((transform.rotation.eulerAngles.z + 1) % 90);
                //    transform.Rotate(0, 0, a);
                //}
            }


        }
        else
        {
            // Letting my Cube Rotate in Vector3.back direction with speed modifier  1.135f // 2.05
            // Freezing all my Rotations in X,Y,Z Axis to prevent strange physics behavior
            
            transform.Rotate(Vector3.back * 1.535f);
            playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void updateVelocity()
    {

    }

    private void updateJump()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        particleSystemEmissionModule.enabled = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        particleSystemEmissionModule.enabled = false;
    }

}