using UnityEngine;
using System.Collections;

public class PlayerParticleScript : MonoBehaviour
{
	private Rigidbody rb;
	private float pHight;
	private ParticleSystem particle;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		particle = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	//	pHight = GameObject.Find ("Player").GetComponent<Rigidbody2D> ().transform.position.y;
	//	if (pHight-0.6 > 0) {
	//		particle.enableEmission = false;

	//	} 
	//	else 
	//	{
	//		particle.enableEmission = true;
	//	}
		rb.transform.position = new Vector3(GameObject.Find("Player").GetComponent<Rigidbody2D>().transform.position.x-0.5f, GameObject.Find("Player").GetComponent<Rigidbody2D>().transform.position.y-0.40f, 0);


	}


		
}

