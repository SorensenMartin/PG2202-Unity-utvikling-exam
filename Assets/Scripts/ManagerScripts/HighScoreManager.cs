using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using JsonUtility = UnityEngine.JsonUtility;


public class HighScoreManager : MonoBehaviour
{
	public string highScoreFileName = "highscores.json";
	private List<HighScoreEntry> highScores = new List<HighScoreEntry>();

	public void SaveHighScore(string playerName, int score)
	{
		Debug.Log(playerName + " " + score);
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
			HighScoreData data = JsonUtility.FromJson<HighScoreData>(jsonData);
			highScores = data.highScores;
		}
	}

	private void SaveHighScores()
	{
		// Save high scores to file
		HighScoreData data = new HighScoreData();
		data.highScores = highScores;
		string jsonData = JsonUtility.ToJson(data);
		string filePath = Application.persistentDataPath + "/" + highScoreFileName;
		File.WriteAllText(filePath, jsonData);
		Debug.Log("Data added: " + highScores + "Filepath: " + filePath);
	}
}

[System.Serializable]
public class HighScoreData
{
	public List<HighScoreEntry> highScores = new List<HighScoreEntry>();
}





