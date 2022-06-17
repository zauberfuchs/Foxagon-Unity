using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatformScript : MonoBehaviour {

	private float jumpHeight = 30;

	private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("JumpPlatform"))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(10,jumpHeight,0);
        }
    }
}