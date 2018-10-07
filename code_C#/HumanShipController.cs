using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanShipController : MonoBehaviour {

	public GameObject interceptedPanel = null;

	// Use this for initialization
	void Start () {
		interceptedPanel.SetActive(false);
	}
	
	public void HandleCollision () {
		Time.timeScale = 0;
		interceptedPanel.SetActive(true);
		SoundManager.S.StopBackgroundMusic ();
		SoundManager.S.StopTenSecond ();
		SoundManager.S.PlayDefeated ();
	}
}
