using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
	public string highScoreFileName = "highscores.json";
	private List<HighScoreEntry> highScores = new List<HighScoreEntry>();

	public void SaveHighScore(string playerName, int score)
	{
		// Load existing high scores
		LoadHighScores();

		// Add new high score entry
		highScores.Add(new HighScoreEntry { name = playerName, score = score });

		// Sort high scores by score
		highScores.Sort((x, y) => y.score.CompareTo(x.score));

		// Save high scores to file
		SaveHighScores();
	}

	public List<HighScoreEntry> GetHighScores()
	{
		// Load high scores from file
		LoadHighScores();

		// Return high scores
		return highScores;
	}

	private void LoadHighScores()
	{
		// Load high scores from file
		string filePath = Application.persistentDataPath + "/" + highScoreFileName;
		if (File.Exists(filePath))
		{
			string jsonData = File.ReadAllText(filePath);
			highScores = JsonUtility.FromJson<List<HighScoreEntry>>(jsonData);
		}
	}

	private void SaveHighScores()
	{
		// Save high scores to file
		string jsonData = JsonUtility.ToJson(highScores);
		string filePath = Application.persistentDataPath + "/" + highScoreFileName;
		File.WriteAllText(filePath, jsonData);
	}
}
