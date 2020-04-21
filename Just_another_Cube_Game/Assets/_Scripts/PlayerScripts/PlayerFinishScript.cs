using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFinishScript : MonoBehaviour {

	public Text finishText;

	void Start () 
	{
		finishText.color = new Color(0, 0, 0, 0);
	}
	
	private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("FinishingLine"))
        {
            Debug.Log("finished");
            finishText.color = new Color(1, 1, 1, 1);
            finishText.text = "Level Completed!";
            if(MyVariableStorage.hasBeenPaused || MyVariableStorage.hasBeenSaved)
            {
                finishText.text = "Level Completed! (in Practice Mode)";
            }
        }
    }
}
