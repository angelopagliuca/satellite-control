using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {

	public void LevelSelect() {
		SceneManager.LoadScene("LevelSelect");
	}

	public void QuitGame() {
		Application.Quit();
	}
}
