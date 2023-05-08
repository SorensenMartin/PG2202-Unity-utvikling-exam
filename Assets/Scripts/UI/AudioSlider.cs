using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
	public Slider audioSlider; 	

	private void Start()
	{
		audioSlider.value = AudioListener.volume;
	}

	public void SetAudioVolume()
	{
		AudioListener.volume = audioSlider.value;
	}
}
