using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectButtons : MonoBehaviour {

	public void Level1() {
		if (GameManager.GM.maxLevel >= 1) {
			SceneManager.LoadScene("Backstory");
		}
	}

	public void Level2() {
		if (GameManager.GM.maxLevel >= 2) {
			SceneManager.LoadScene("Level2");
			SoundManager.S.StopMainMusic ();
			SoundManager.S.PlayBackgroundMusic ();
		}
	}

	public void Level3() {
		if (GameManager.GM.maxLevel >= 3) {
			SceneManager.LoadScene("Level3");
			SoundManager.S.StopMainMusic ();
			SoundManager.S.PlayBackgroundMusic ();
		}
	}

	public void Level4() {
		if (GameManager.GM.maxLevel >= 4) {
			SceneManager.LoadScene("Level4");
			SoundManager.S.StopMainMusic ();
			SoundManager.S.PlayBackgroundMusic ();
		}
	}

	public void Back() {
		SceneManager.LoadScene("MainMenu");
	}

}
