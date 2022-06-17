using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSoundVolume : MonoBehaviour {

	public Slider volumeSlider;
	void Start ()
	{
		volumeSlider.value = MyVariableStorage.gameVolume;
	}

	// Update is called once per frame
	void Update()
	{
   		MyVariableStorage.gameVolume = volumeSlider.value;
	}
}
