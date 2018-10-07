using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager S;

	public GameObject backgroundobj;
	private AudioSource backgroundSound;

	public GameObject mainmusicobj;
	private AudioSource mainmusicSound;

	public GameObject tensecondobj;
	private AudioSource tensecondSound;

	public GameObject victoryobj;
	private AudioSource victorySound;

	public GameObject defeatedobj;
	private AudioSource defeatedSound;

	public GameObject gruntobj;
	private AudioSource gruntSound;

	public GameObject connectedobj;
	private AudioSource connectedSound;

	// Use this for initialization
	void Start () {
		S = this;
		backgroundSound = backgroundobj.GetComponent<AudioSource> ();
		mainmusicSound = mainmusicobj.GetComponent<AudioSource> ();
		tensecondSound = tensecondobj.GetComponent<AudioSource> ();
		victorySound = victoryobj.GetComponent<AudioSource> ();
		defeatedSound = defeatedobj.GetComponent<AudioSource> ();
		gruntSound = gruntobj.GetComponent<AudioSource> ();
		connectedSound = connectedobj.GetComponent<AudioSource> ();

	}

	// Update is called once per frame
	//void Update () {

	//}

	public void PlayBackgroundMusic() {
		backgroundSound.Play ();
	}

	public void StopBackgroundMusic() {
		backgroundSound.Stop ();
	}

	public void PlayMainMusic() {
		mainmusicSound.Play ();
	}

	public void StopMainMusic() {
		mainmusicSound.Stop ();
	}

	public void PlayVictory() {
		victorySound.Play ();
	}

	public void PlayDefeated() {
		defeatedSound.Play ();
	}

	public void PlayConnected() {
		connectedSound.Play ();
	}

	public void PlayTenSecond() {
		tensecondSound.Play ();
	}

	public void StopTenSecond() {
		tensecondSound.Stop ();
	}

	public void PlayGrunt() {
		gruntSound.Play ();
	}
}
