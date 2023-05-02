using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	public Button startButton;
	public GameManager gameManager;

	void Start()
	{
		Debug.Log("Start UIController");
		startButton.onClick.AddListener(gameManager.StartGame);
	}

}

