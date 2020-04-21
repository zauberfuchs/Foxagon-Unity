using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPauseScript : MonoBehaviour {

	public Text pauseText;

	private bool gamePaused;
	private float savedTimeScale;


	void Start()
	{
		pauseText.color = new Color(0, 0, 0, 0);
        AudioListener.pause = false;
	}

	private void Update() 
	{
 		if (Input.GetKeyDown(KeyCode.P) && (gamePaused == false))
    	{
        	PauseGame();
    	}
    	else if(Input.GetKeyDown(KeyCode.P) && (gamePaused == true))
    	{
        	UnPauseGame();
    	}
    }

	void PauseGame() 
    {   
        MyVariableStorage.hasBeenPaused = true;
        gamePaused = true;
        savedTimeScale = Time.timeScale;
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseText.color = new Color(1, 1, 1, 1);
        this.GetComponent<PlayerAttemptScript>().SetAttemptText();
    }
  
    void UnPauseGame() 
    {   
        gamePaused = false;
        Time.timeScale = savedTimeScale;
        AudioListener.pause = false;
        pauseText.color = new Color(0, 0, 0, 0);
    }
}
