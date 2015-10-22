using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

	public AudioClip HurtClip;
	public AudioClip DeathClip;

	private AudioSource flyAudio;
	private AudioSource jumpAudio;
	private AudioSource healthAudio;
	

	void Awake() {
		flyAudio = GetComponents<AudioSource> ()[0];
		jumpAudio = GetComponents<AudioSource> ()[1];
		healthAudio = GetComponents<AudioSource> ()[2];
	}

	public void MovementAudio (float move, bool jump) {
		if (move != 0) {
			Play (flyAudio, true);
		} else {
			Play (flyAudio, false);
		}

		if (jump) {
			Play (jumpAudio, true);
		}
	}

	public void HealthAudio(bool death) {
		healthAudio.clip = !death ? HurtClip : DeathClip;
		Play (healthAudio, true);
		Play (flyAudio, false);
	}

	void Play(AudioSource source, bool toggle) {
		if (toggle && !source.isPlaying) {
			source.Play ();
		}
		else if (!toggle) {
			source.Stop();
		}
	}

}
