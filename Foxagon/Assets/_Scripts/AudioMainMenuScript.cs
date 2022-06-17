using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioMainMenuScript : MonoBehaviour {

	// Use this for initialization
	private  AudioSource   mainMenuMusic;


	void Start () {
		mainMenuMusic = GetComponent<AudioSource>();
		mainMenuMusic.volume = MyVariableStorage.musicVolume;
	}
	
	// Update is called once per frame
	void Update () {
		mainMenuMusic.volume = MyVariableStorage.musicVolume;
	}
}
