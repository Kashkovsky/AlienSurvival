 using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NameEntry : MonoBehaviour {
	public InputField field;
	public Button submit;

	private GlobalScoreBoard globalBoard;
	private LevelManager levelManager;
	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();

		globalBoard = GameObject.FindObjectOfType<GlobalScoreBoard> ();
		submit.onClick.AddListener (OnSubmitName);
		  
	}

	void OnSubmitName () {

		globalBoard.ClaimCurrentScore (field.text);
		levelManager.LoadLevel ("Score");
	}

}
