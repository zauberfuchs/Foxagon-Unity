﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerReturnToMenuScript : MonoBehaviour {

	
	void LateUpdate () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            MyVariableStorage.performsRestart = false;
            MyVariableStorage.attemptCount = 0;
            SceneManager.LoadScene(0);
        }
	}
}
