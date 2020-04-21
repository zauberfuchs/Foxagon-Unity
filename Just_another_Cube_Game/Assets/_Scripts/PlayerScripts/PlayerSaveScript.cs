using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveScript : MonoBehaviour {

	private  Savepoint 	save;
	[SerializeField]
	private  Vector3 	startPos;

	void Start () 
	{
		startPos = this.GetComponent<RectTransform>().transform.position;
	}
	
	void FixedUpdate () 
	{
		if (Input.GetKeyDown(KeyCode.S))
        {
            save = new Savepoint(transform.position);
            GameObject.Find("SaveSign").GetComponent<Transform>().position = transform.position;
            MyVariableStorage.hasBeenSaved = true;
            startPos = GameObject.Find("SaveSign").GetComponent<Transform>().position;
            this.GetComponent<PlayerAttemptScript>().SetAttemptText();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            startPos = new Vector3(0, 0.5f, 0);
            GameObject.Find("SaveSign").GetComponent<Transform>().position =  new Vector3(-100, 0.5f, 0);
        }
	}

	public Vector3 StartPos{
		get { return startPos; }
		set { startPos = value; }
	}
}
