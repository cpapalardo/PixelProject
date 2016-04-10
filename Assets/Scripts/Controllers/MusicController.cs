using UnityEngine;
using System.Collections;

public enum MusicDataBase{
	pongTheme,
	snakeTheme
}

public class MusicController : MonoBehaviour {

	public AudioClip musicPongTheme;

	public AudioSource audioSource;

	public static MusicController instance;

	void Awake(){
		instance = this;
	}

	public static void PlayMusic(MusicDataBase currentSong){
		switch (currentSong) {
		case MusicDataBase.pongTheme:
			instance.GetComponent<AudioSource> ().clip = instance.musicPongTheme;
			break;
		}
		instance.GetComponent<AudioSource> ().Play ();
	}

	public static void ManageBackGroundMusic(){
		AudioSource audio = instance.GetComponent<AudioSource> ();
		if (audio.isPlaying)
			audio.Stop ();
		else
			audio.Play ();
	}
}
