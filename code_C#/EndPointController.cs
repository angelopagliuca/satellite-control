using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPointController : MonoBehaviour {

	public int type = 0;
	public int orientation = 0;

	public float delay = 1f;

	private float upTime = 0f;
	private float rightTime = 0f;
	private float downTime = 0f;
	private float leftTime = 0f;

	private bool win = false;
	private bool victorySound = true;

	public GameObject winPanel;

	private int connection = 0;
		
	// Use this for initialization
	void Start () {
		winPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		upTime -= Time.deltaTime;
		downTime -= Time.deltaTime;
		leftTime -= Time.deltaTime;
		rightTime -= Time.deltaTime;

		switch (type) {
		case 0:
			if (orientation == 0 || orientation == 2) {
				if (downTime > 0f && upTime > 0f) {
					win = true;
				} else {
					win = false;
				}

			} else if (orientation == 1 || orientation == 3) {
				if (leftTime > 0f && rightTime > 0f) {
					win = true;
				} else {
					win = false;
				}
			}
			break;

		case 1:
			if (orientation == 0) {
				if (upTime > 0f && rightTime > 0f) {
					win = true;
				} else {
					win = false;
				}
			} else if (orientation == 1) {
				if (downTime > 0f && rightTime > 0f) {
					win = true;
				} else {
					win = false;
				}
			} else if (orientation == 2) {
				if (downTime > 0f && leftTime > 0f) {
					win = true;
				} else {
					win = false;
				}
			} else if (orientation == 3) {
				if (upTime > 0f && leftTime > 0f) {
					win = true;
				} else {
					win = false;
				}
			}
			break;

		case 2:			
			if (orientation == 0) {
				if (downTime > 0f && upTime > 0f && rightTime > 0f) {
					win = true;
				} else {
					win = false;
				}
				
			} else if (orientation == 1) {
				if (downTime > 0f && leftTime > 0f && rightTime > 0f) {
					win = true;
				} else {
					win = false;
				}
			} else if (orientation == 2) {
				if (downTime > 0f && upTime > 0f && leftTime > 0f) {
					win = true;
				} else {
					win = false;
				}
				
			} else if (orientation == 3) {
				if (upTime > 0f && leftTime > 0f && rightTime > 0f) {
					win = true;
				} else {
					win = false;
				}
			}
			break;

		case 3:			
			if (orientation == 0 || orientation == 1 || orientation == 2 || orientation == 3) {
				if (downTime > 0f && upTime > 0f && leftTime > 0f && rightTime > 0f) {
					win = true;
				} else {
					win = false;
				}
			} 
			break;
		}

		if (win && victorySound) {

			string currentScene = SceneManager.GetActiveScene().name;
			if (currentScene == "Level1") {
				GameManager.GM.maxLevel = 2;
			} else if (currentScene == "Level2") {
				GameManager.GM.maxLevel = 3;
			} else if (currentScene == "Level3") {
				GameManager.GM.maxLevel = 4;
			} else if (currentScene == "Level4") {
				GameManager.GM.maxLevel = 4;
			}

			winPanel.SetActive (true);
			SoundManager.S.StopBackgroundMusic ();
			SoundManager.S.StopTenSecond ();
			SoundManager.S.PlayVictory ();
			Time.timeScale = 0;
			victorySound = false;
		}
	}

	public void NextLevel () {
		string currentScene = SceneManager.GetActiveScene().name;
		if (currentScene == "Level1") {
			SceneManager.LoadScene("Level2");
			SoundManager.S.PlayBackgroundMusic ();
		} else if (currentScene == "Level2") {
			SceneManager.LoadScene("Level3");
			SoundManager.S.PlayBackgroundMusic ();
		} else if (currentScene == "Level3") {
			SceneManager.LoadScene("Level4");
			SoundManager.S.PlayBackgroundMusic ();
		} else if (currentScene == "Level4") {
			SceneManager.LoadScene("MainMenu");
			SoundManager.S.PlayBackgroundMusic ();
		}
	}

	public void exit2MainMenu() {
		SceneManager.LoadScene("MainMenu");
		SoundManager.S.StopBackgroundMusic ();
		SoundManager.S.PlayMainMusic ();
	}

	public void HandleCollision(Transform collided) { 

		switch (type) {
		case 0:
			if (orientation == 0 || orientation == 2) {
				if (collided.position.z + 20f < transform.position.z) {
					downTime = delay;
				} else if (collided.position.z - 20f > transform.position.z) {
					upTime = delay;
				}

			} else if (orientation == 1 || orientation == 3) {
				if (collided.position.x - 20f > transform.position.x) {
					rightTime = delay;
				} else if (collided.position.x + 20f < transform.position.x) {
					leftTime = delay;
				}
			}
			break;

		case 1:
			if (orientation == 0) {
				if (collided.position.z - 20f > transform.position.z) {
					upTime = delay;
				} else if (collided.position.x - 20f > transform.position.x) {
					rightTime = delay;
				}
			} else if (orientation == 1) {
				if (collided.position.x - 20f > transform.position.x) {
					rightTime = delay;
				} else if (collided.position.z + 20f < transform.position.z) {
					downTime = delay;
				}
			} else if (orientation == 2) {
				if (collided.position.z + 20f < transform.position.z) {
					downTime = delay;
				} else if (collided.position.x + 20f < transform.position.x) {
					leftTime = delay;
				}
			} else if (orientation == 3) {
				if (collided.position.x + 20f < transform.position.x) {
					leftTime = delay;
				} else if (collided.position.z - 20f > transform.position.z) {
					upTime = delay;
				}
			}
			break;

		case 2:			
			if (orientation == 0) {
				if (collided.position.z - 20f > transform.position.z) {
					upTime = delay;


				} else if (collided.position.z + 20f < transform.position.z) {
					downTime = delay;


				} else if (collided.position.x - 20f > transform.position.x) {
					rightTime = delay;

				}
			} else if (orientation == 1) {
				if (collided.position.x - 20f > transform.position.x) {
					rightTime = delay;



				} else if (collided.position.x + 20f < transform.position.x) {
					leftTime = delay;


				} else if (collided.position.z + 20f < transform.position.z) {
					downTime = delay;

				}
			} else if (orientation == 2) {
				if (collided.position.z - 20f > transform.position.z) {

					upTime = delay;

				} else if (collided.position.z + 20f < transform.position.z) {

					downTime = delay;

				} else if (collided.position.x + 20f < transform.position.x) {

					leftTime = delay;

				}
			} else if (orientation == 3) {
				if (collided.position.x - 20f > transform.position.x) {

					rightTime = delay;

				} else if (collided.position.x + 20f < transform.position.x) {

					leftTime = delay;

				} else if (collided.position.z - 20f > transform.position.z) {

					upTime = delay;

				}
			}
			break;

		case 3:			
			if (orientation == 0 || orientation == 1 || orientation == 2 || orientation == 3) {
				if (collided.position.z - 20f > transform.position.z) {

					upTime = delay;

				} else if (collided.position.z + 20f < transform.position.z) {

					downTime = delay;

				} else if (collided.position.x - 20f > transform.position.x) {

					rightTime = delay;

				} else if (collided.position.x + 20f < transform.position.x) {

					leftTime = delay;
				}
			} 
			break;
		}
	}
}
