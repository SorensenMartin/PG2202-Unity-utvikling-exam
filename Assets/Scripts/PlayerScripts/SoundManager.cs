using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public AudioClip myClip;
	public AudioSource mySource;

	void Start()
	{
		mySource.clip = myClip;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			mySource.Play();
		}
	}
}
