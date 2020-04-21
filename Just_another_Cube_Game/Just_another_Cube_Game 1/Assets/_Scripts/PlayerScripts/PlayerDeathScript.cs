using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeathScript : MonoBehaviour {

	public Text deathText;
	[SerializeField]
	private float canRestart = 10000000000000f;
	private Animator anim;
	[SerializeField]
	private Vector3 scale = new Vector3(1, 1, 1);
	private AudioSource dieSound;

	void Start () 
	{
		// anim = GetComponent<Animator>();
		// anim.enabled = false;
		deathText.color = new Color(0, 0, 0, 0);
        dieSound = GetComponent<AudioSource>();
        dieSound.volume = MyVariableStorage.gameVolume;
	}
	
	void FixedUpdate () 
	{
		if (Time.time > canRestart && Input.GetKey(KeyCode.Space))
        {
            this.GetComponent<PlayerController>().CanJump = Time.time + 0.20f;
            MyVariableStorage.performsRestart = false;
            this.GetComponent<PlayerCollisionScript>().Grounded = true;
            this.GetComponent<PlayerController>().HasJumped = false;
            anim.enabled = false;
            this.transform.position = this.GetComponent<PlayerSaveScript>().StartPos;
            this.transform.localScale = scale;
            this.GetComponent<Rigidbody2D>().gravityScale = 10;
            this.GetComponent<PlayerProgressScript>().bestProgressText.color = new Color(0, 0, 0, 0);
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<PlayerController>().right,0);
            deathText.color = new Color(0, 0, 0, 0);
            canRestart = 10000000000000f;
        }
	}

	void LateUpdate()
	{
		if(this.GetComponent<Rigidbody2D>().velocity.x < 1 && !MyVariableStorage.performsRestart)
		{
			PerformPlayerDeath();
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            PerformPlayerDeath();
        }
        
    }

    private void PerformPlayerDeath()
    {
    	this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        this.GetComponent<Rigidbody2D>().gravityScale = 0f;
        this.GetComponent<PlayerDeathScript>().CanRestart = Time.time + 1f;
        this.GetComponent<PlayerController>().CanJump = Time.time + 0.30f;
		this.GetComponent<PlayerProgressScript>().SetBestProgress();
        // anim.enabled = false;
        // anim.enabled = true;
        anim.Play("PlayerDeath", -1, 0f);
        dieSound.Play();
        MyVariableStorage.attemptCount = MyVariableStorage.attemptCount + 1;
        this.GetComponent<PlayerAttemptScript>().SetAttemptText();
        MyVariableStorage.performsRestart = true;
        deathText.color = new Color(1, 1, 1, 1);
        this.GetComponent<PlayerProgressScript>().bestProgressText.color = new Color(1, 1, 1, 1);
    }

	public float CanRestart
	{
		get
		{
			return canRestart;
		}
		set
		{
			canRestart = value;
		}
	}
}
