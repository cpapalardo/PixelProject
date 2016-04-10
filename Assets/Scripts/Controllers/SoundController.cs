using UnityEngine;
using System.Collections;

public enum SoundDatabase{
	heartAppears,
	heartBeat,
	miss,
}

public class SoundController : MonoBehaviour {

	public AudioClip seHeartAppears;
	public AudioClip seHeartBeat;
	public AudioClip seMiss;

	public static SoundController instance;

	void Awake(){
		instance = this;
	}
	
	public static void PlaySound(SoundDatabase currentSound){
		switch (currentSound) {
		case SoundDatabase.heartAppears:
			instance.GetComponent<AudioSource> ().PlayOneShot (instance.seHeartAppears);
			break;
		case SoundDatabase.heartBeat:
			instance.GetComponent<AudioSource> ().PlayOneShot(instance.seHeartBeat);
			break;
		case SoundDatabase.miss:
			instance.GetComponent<AudioSource> ().PlayOneShot (instance.seMiss);
			break;
		}
	}

	public static void StopSound(){
		instance.GetComponent<AudioSource> ().Stop ();
	}

	public static void ManageSoundEffects(){
		AudioSource audio = instance.GetComponent<AudioSource> ();
		if (audio.mute)
			audio.mute = false;
		else
			audio.mute = true;
	}

	public static bool IsPlaying(){
		return instance.GetComponent<AudioSource> ().isPlaying;
	}
}
