using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour {

	public Slider volumeSlider;
	void Start ()
	{
		volumeSlider.value = MyVariableStorage.musicVolume;
	}


	// Update is called once per frame
	void Update()
	{
   		MyVariableStorage.musicVolume = volumeSlider.value;
	}	
}