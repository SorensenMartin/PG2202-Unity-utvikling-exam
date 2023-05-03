using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public enum GameState
	{
		Start,
		Playing,
		GameOver
	}

	public GameState currentState;
	public GameObject StartScreen;
	public GameObject EndScreen;
	public GameObject Spaceship;
	

	void Start()
	{
		Debug.Log("Start GameManager");
		currentState = GameState.Start;
		StartScreen.SetActive(true);
		Spaceship.SetActive(false);
		EndScreen.SetActive(false);
	}

	void Update()
	{
		switch (currentState)
		{
			case GameState.Start:				
				
				break;
			case GameState.Playing:
				StartScreen.SetActive(false);
				Spaceship.SetActive(true);

				break;
			case GameState.GameOver:
				// reset game				
				
				break;
		}
	}

	public void StartGame()
	{
		Debug.Log("Now Playing");
		currentState = GameState.Playing;
		StartScreen.SetActive(false);
		Spaceship.SetActive(true);
		
	}	

	public void EndGame()
	{
		currentState = GameState.GameOver;
		Spaceship.SetActive(false);
		EndScreen.SetActive(true);
	}

	public void ResetGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
