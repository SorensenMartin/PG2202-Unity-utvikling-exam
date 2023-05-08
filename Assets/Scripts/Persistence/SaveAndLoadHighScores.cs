using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveAndLoadHighScores : MonoBehaviour
{
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI highScoreText;
	public TMP_InputField nameInput;
	public HighScoreManager highScoreManager;
	public Player player;
	public GameObject playAgainButtons;
	public GameObject highScoreSection;

	private int score;

	public void SaveHighScore()
	{
		score = player.money;
				
		scoreText.text = "You earned: $ " + score.ToString();
		string playerName = nameInput.text;		
		highScoreManager.SaveHighScore(playerName, score);
		playAgainButtons.SetActive(true);
		highScoreSection.SetActive(false);

		Debug.Log("SaveHighScore " + playerName + " " + score );
	}

	public void LoadHighScores()
	{
		List<HighScoreEntry> highScores = highScoreManager.GetHighScores();
		int entries = 0;

		string highScoreString = "High Scores:\n";
		foreach (HighScoreEntry highScore in highScores)
		{
			if (entries >= 12)
			{
				break;
			}
			highScoreString += highScore.name + ": " + "$ " + highScore.score + "\n";
		}
		highScoreText.text = highScoreString;

		Debug.Log("LoadHighScores" + highScoreString);
	}
}
