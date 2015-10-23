using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter = 2f;
	

	void Start () {
		if (Application.loadedLevel == 0) {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}

	void Update() {
		if (Input.GetButtonDown ("Cancel")) {
			LoadLevel("Options");
		}
	}

	public void LoadLevel (string name) {
		Application.LoadLevel (name);
	}

	public void LoadNextLevel () {
		Application.LoadLevel (Application.loadedLevel +1);
	}
	public void Quit () {
		Application.Quit ();
	}
}
