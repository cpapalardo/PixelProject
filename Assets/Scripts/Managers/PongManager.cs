using UnityEngine;
using System.Collections;

public class PongManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
			MusicController.PlayMusic(MusicDataBase.pongTheme);			// Chama o metodo PlayMusic da classe MusicControler passando como parametro a musica a ser tocada
	}

}
