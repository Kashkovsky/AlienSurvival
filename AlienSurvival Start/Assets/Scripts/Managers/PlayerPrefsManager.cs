using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";

	public static void SetMasterVolume (float volume) {
		if (volume > 0 && volume < 1) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError ("Master volume out of range");
		}
	}

	public static float GetMasterVolume () {
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}

	public static void UnlockLevel (int level) {
		if (level <= Application.levelCount - 1) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString(), 1); // 1 for true
		} else {
			Debug.LogError ("Trying to reach level out of level order");
		}
	
	}

	public static bool IsLevelUnlocked (int level) {

		if (level <= Application.levelCount - 1) {
			int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString ());
			bool isUnlocked = (levelValue == 1);
			return isUnlocked;
		} else {
			Debug.LogError ("Trying to reach level out of level order");
			return false;
		}

	}

	public static void SetDifficulty (float difficulty) {
		if (difficulty >= 1f && difficulty <= 3f) {
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError ("Difficulty out of range");
		}
	}

	public static float GetDifficulty () {
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}
}
