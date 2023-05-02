using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
	public GameManager gamemanager;

	public void StartGame()
	{
		gamemanager.currentState = GameManager.GameState.Playing;
	}	
}
