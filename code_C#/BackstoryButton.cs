using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackstoryButton : MonoBehaviour {
	public void Next() {
		SceneManager.LoadScene("Directions");
	}
}