using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransmitterManager : MonoBehaviour {

	public GameObject particlePrefab;
	private float timer;
	public float delay = .2f;

	public float timerEnd = 90.0f;
	private int time = 90;
	public bool gameOver = false;

	public Text timeText;

	public GameObject losePanel;

	private bool isPaused = false;
	private bool musicOn = true;
	private bool playTimer = true;

	// Use this for initialization
	void Start () {
		timer = delay;
		losePanel.SetActive (false);
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {

		PauseManager();
		ThemeMusicManager();

		timeText.text = "Time = " + time;
		time = (int)timerEnd;
		timerEnd -= Time.deltaTime;

		TimeOver ();

		if (isPaused == false) timer -= Time.deltaTime;

		if (timer <= 0) {
			GameObject particle = Instantiate (particlePrefab, transform.position + (100f * Vector3.forward), Quaternion.identity);
			ParticleMovement PScript = (ParticleMovement)particle.gameObject.GetComponent <ParticleMovement> ();
			PScript.velocity = new Vector3 (0, 0, 100);
			Rigidbody rb = (Rigidbody) particle.GetComponent<Rigidbody>();
			rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
			timer = delay;
		}
	}

	void TimeOver () {
		if (timerEnd < 1 && playTimer == false) {
			gameOver = true;
			Time.timeScale = 0;
			losePanel.SetActive (true);
			SoundManager.S.StopBackgroundMusic ();
			SoundManager.S.PlayDefeated ();
			playTimer = true;
		} else if (2 < timerEnd && timerEnd < 12 && playTimer == true) {
			SoundManager.S.StopBackgroundMusic ();
			SoundManager.S.PlayTenSecond ();
			playTimer = false;
		}
	}

	public void Retry () {
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		SoundManager.S.PlayBackgroundMusic ();
	}

	public void exit2MainMenu() {
		SceneManager.LoadScene("MainMenu");
		SoundManager.S.PlayMainMusic ();
	}

	void PauseManager () {
		if (Input.GetKeyDown ("space")) {
			if (isPaused == true) {
				Time.timeScale = 1;
				isPaused = false;
			} else {
				Time.timeScale = 0;
				isPaused = true;
			}
		}
	}

	void ThemeMusicManager() {

		if (Input.GetKeyDown ("space")) {
			musicOn = !musicOn;

			if (musicOn == false) {
				SoundManager.S.StopBackgroundMusic ();
			}

			if (musicOn == true) {
				SoundManager.S.PlayBackgroundMusic ();
			}

		}
	}
}
