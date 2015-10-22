using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class ScoreBoardView : MonoBehaviour {

	public GlobalScoreBoard globalBoard;
	public Text scoresText;
	string textBuffer;

	void Update () {
		List<GlobalScoreBoard.ScoreEntry> scores = globalBoard.GetScores ();
		if (scores.Count > 0) {
			StringBuilder builder = new StringBuilder();
			foreach (GlobalScoreBoard.ScoreEntry entry in scores) {
				builder.AppendLine(entry.name + " " + entry.score.ToString());
			}
			scoresText.text = builder.ToString();
		} else { 
			scoresText.text = "Loading";
		}
	} 
}
