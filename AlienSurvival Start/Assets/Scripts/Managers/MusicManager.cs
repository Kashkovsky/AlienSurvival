using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	public AudioClip[] musicChangeArray;

	AudioSource player;

	void Awake() {
		DontDestroyOnLoad(gameObject);

	}
	void Start () {
		player = gameObject.GetComponent<AudioSource> ();
		player.clip = musicChangeArray [0];
		player.volume = PlayerPrefsManager.GetMasterVolume ();
		player.Play ();
	}
	void OnLevelWasLoaded (int level) {
		AudioClip currentSound =  musicChangeArray [level];
		if (currentSound) {
			player.clip = currentSound;
			player.loop = true;
			player.Play ();
		}
	}

	public void SetVolume (float vol) {
		player.volume = vol;
	}
}
