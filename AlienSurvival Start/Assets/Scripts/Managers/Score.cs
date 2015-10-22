 using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;


public class Score : MonoBehaviour {
	private Text text;
	public int score = 0;
	private LevelManager levelManager;

	private GlobalScoreBoard globalBoard;
	public Text scoreText;
	public Text topScore;

	void Start () {

		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		globalBoard = GameObject.FindObjectOfType<GlobalScoreBoard> ();

	}

	void Update () {
		if (scoreText) {
			scoreText.text = score.ToString ();
			print ("Current "  + score);
		}
		topScore.text = globalBoard.GetScores ().Count() > 0 ? "TOP SCORE: " + globalBoard.GetScores ().Last ().score.ToString () : "";
	}

	public void Add (int addScore) {
		score += addScore;
	}

	public void GameOver () {
		globalBoard.SetCurrentScore (score);
	
		if (globalBoard.IsHighScore (score)) {
		
			levelManager.LoadLevel ("Name");
		} 
	}
}
