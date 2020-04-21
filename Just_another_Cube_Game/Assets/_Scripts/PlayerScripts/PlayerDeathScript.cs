using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeathScript : MonoBehaviour {

	public 	 Text 			deathText;

	[SerializeField]
	private  float 			canRestart = 10000000000000f;
	private  Animator 		anim;
	private  float			gScale;

	[SerializeField]
	private  Vector3 		scale = new Vector3(1, 1, 1);
	private  AudioSource 	dieSound;

	void Start () 
	{
		anim = GetComponent<Animator>();
		anim.enabled = false;
		deathText.color = new Color(0, 0, 0, 0);
        dieSound = GetComponent<AudioSource>();
        dieSound.volume = MyVariableStorage.gameVolume;
		gScale = this.GetComponent<Rigidbody2D>().gravityScale;
	}
	
	void FixedUpdate () 
	{
		if (Time.time > canRestart && Input.GetKey(KeyCode.Space))
        {
            MyVariableStorage.performsRestart = false;
            anim.enabled = false;
            this.transform.position = this.GetComponent<PlayerSaveScript>().StartPos;
            this.transform.localScale = scale;
			this.GetComponent<Rigidbody2D>().gravityScale = gScale;
            this.GetComponent<PlayerProgressScript>().bestProgressText.color = new Color(0, 0, 0, 0);
            this.GetComponent<Rigidbody2D>().velocity = new Vector3(this.GetComponent<Jump2D>().playerSpeed,0,0);
            deathText.color = new Color(0, 0, 0, 0);
            canRestart = 10000000000000f;
			GameObject.Find ("Destroy").SetActive (false);
        }
	}

	void Update()
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
		MyVariableStorage.performsRestart = true;
		this.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        this.GetComponent<PlayerDeathScript>().CanRestart = Time.time + 1f;
		this.GetComponent<PlayerProgressScript>().SetBestProgress();
        anim.enabled = false;
        anim.enabled = true;
        anim.Play("PlayerDeath", -1, 0f);
        dieSound.Play();
        MyVariableStorage.attemptCount = MyVariableStorage.attemptCount + 1;
        this.GetComponent<PlayerAttemptScript>().SetAttemptText();
        //MyVariableStorage.performsRestart = true;
        deathText.color = new Color(1, 1, 1, 1);
        this.GetComponent<PlayerProgressScript>().bestProgressText.color = new Color(1, 1, 1, 1);
    }

	public float CanRestart
	{
		get { return canRestart; }
		set { canRestart = value; }
	}
}
