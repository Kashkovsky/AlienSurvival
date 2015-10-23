using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	private Text text;
	public int score = 0;

	public Text scoreText;
	public Text topScore;
	
	void Update () {
		scoreText.text = score.ToString ();
	}
	
	public void Add (int addScore) {
		score += addScore;
	}
}
