using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttemptScript : MonoBehaviour {

	public Text attemptText;

	void Start () 
	{
		SetAttemptText();
	}

	public void SetAttemptText()
    {
        if(MyVariableStorage.hasBeenPaused || MyVariableStorage.hasBeenSaved)
        {
            attemptText.text = "Practice Mode";
        }else{
            attemptText.text = "Attempts: " + MyVariableStorage.attemptCount.ToString();
        }
    }
}
