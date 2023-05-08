using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.Json;
using JsonUtility = UnityEngine.JsonUtility;

[System.Serializable]
public class HighScoreEntry
{
	public string name;
	public int score;
}
