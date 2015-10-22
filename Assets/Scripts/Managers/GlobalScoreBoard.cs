using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Parse;

public class GlobalScoreBoard : MonoBehaviour {

	public struct ScoreEntry {
		public int score;
		public string name;
	}

	private static int currentTopScore = 0;
	private static List<ScoreEntry> scores = new List<ScoreEntry>();

	public List<ScoreEntry> GetScores () {
		
		return scores;
	}

	void Awake () {

		ScoresQuery ();
	}

	void ScoresQuery () {
		var query = ParseObject.GetQuery ("playerScore")
			.WhereExists ("playerName")
				.WhereExists ("score")
				.OrderByDescending ("score")
				.Limit (5);
		var task = query.FindAsync ();
		task.ContinueWith ( (t) => {
			scores.Clear();
			foreach (ParseObject playerScore in t.Result) {
				scores.Add(new ScoreEntry () {
					score = playerScore.Get<int> ("score"),
					name = playerScore.Get<string> ("playerName")
				});		
				}
		});
	}
	public  void SetCurrentScore (int score) {
			currentTopScore = score;
	}
	
	
	
	public  void ClaimCurrentScore (string name) {
		ParseObject playerScore = new ParseObject("playerScore");
		playerScore ["playerName"] = name;
		playerScore ["score"] = currentTopScore;
		playerScore.SaveAsync ();
		
	}
	
	public bool IsHighScore (int score) {

		var topFive = scores.Take (5);
		if (topFive.Any ()) {
			return (score > topFive.Last ().score  );
		} else {
			return true; }
		
		
	}
}
