using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {
	public  Slider volumeSlider;
	public  Slider difficultySlider;
	private Text volumeValue;
	private Text difficultyValue;
	private LevelManager levelManager;
	public MusicManager musicManager;

	void Start () {

		volumeValue = GameObject.Find ("Volume Value").GetComponent<Text> ();
		difficultyValue = GameObject.Find ("Difficulty Value").GetComponent<Text> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		musicManager = GameObject.FindObjectOfType<MusicManager> ();

		volumeSlider.value = PlayerPrefsManager.GetMasterVolume ();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty ();


	}

	void Update () {
		musicManager.SetVolume (volumeSlider.value); 
		volumeValue.text = (volumeSlider.value * 100).ToString ();
		if (difficultySlider.value == 1) {
			difficultyValue.text = "Newbie";
		} else if (difficultySlider.value == 2) {
			difficultyValue.text = "Rockie";
		} else {
			difficultyValue.text = "Hardcore";
		}
	}
	public void SaveAndExit () {
		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);
		PlayerPrefsManager.SetDifficulty (difficultySlider.value);
		levelManager.LoadLevel ("Start Menu");
	}

	public void SetDefaults () {
		volumeSlider.value = 0.5f;
		difficultySlider.value = 2;
	}
}
