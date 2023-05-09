using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
	public AudioSource spaceShipFlying;
	public AudioSource clickSoundEffect;
	public GameManager gameManager;

	public GameObject SpaceshipController;

	void Update()
	{
		//Uncomment this code if you want to use the sound effects of the spaceship

		/*if (Input.GetKeyDown(KeyCode.W) && gameManager.currentState == GameManager.GameState.Playing)
		{			
			StartCoroutine(FadeIn(spaceShipFlying, 0.5f));
		}
		if (Input.GetKeyUp(KeyCode.W))
		{
			StartCoroutine(FadeOut(spaceShipFlying, 0.5f));
		} */

		if (Input.GetKeyDown(KeyCode.Mouse0) && SpaceshipController.activeSelf != true)
		{
			clickSoundEffect.Play();
		}

	}

	// gradually fades in the sound by using a coroutine
	IEnumerator FadeIn(AudioSource audioSource, float fadeDuration)
	{
		audioSource.volume = 0f;
		audioSource.Play();

		while (audioSource.volume < 0.01f)
		{
			audioSource.volume += Time.deltaTime / fadeDuration;
			yield return null;
		}
	}

	// gradually fades out the sound by using a coroutine
	IEnumerator FadeOut(AudioSource audioSource, float duration)
	{
		float startVolume = audioSource.volume;

		while (audioSource.volume > 0)
		{
			audioSource.volume -= startVolume * Time.deltaTime / duration;
			yield return null;
		}

		audioSource.Stop();
		audioSource.volume = startVolume;
	}
}
