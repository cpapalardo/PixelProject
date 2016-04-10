using UnityEngine;
using System.Collections;

public class EventsController : MonoBehaviour {

	public GameObject heart;
	public static bool checkHeart = false;

	// Use this for initialization
	void Start () {
		heart.SetActive (checkHeart);
	}
	
	// Update is called once per frame
	void Update () {
		if (!checkHeart)
			secondsPassedHeart ();
		else {
			if(!SoundController.IsPlaying() && heart.activeSelf)
				SoundController.PlaySound (SoundDatabase.heartBeat);
		}
	}

	public void secondsPassedHeart(){
		if (Time.time >= 4f) {
			heart.SetActive (true);
			checkHeart = true;
			SoundController.PlaySound (SoundDatabase.heartAppears);
		}
	}


}
