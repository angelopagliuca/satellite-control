using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DirectionsButton: MonoBehaviour {
	public void StartGame() {
		SceneManager.LoadScene("Level1");
		SoundManager.S.StopMainMusic ();
		SoundManager.S.PlayBackgroundMusic ();
	}
}