using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


	public float TOP_BAR;
	public float RIGHT_BAR;
	public float ZOOM_BAR_IN;
	public float ZOOM_BAR_OUT;
	public int speed = 1000;
	Camera cam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		cam = this.GetComponent<Camera>();

		Vector3 cameraposition = transform.position;

		if (Input.GetKey ("d")) {
			cameraposition.x += speed;
			transform.position = cameraposition;
		} else if (Input.GetKey ("a")) {
			cameraposition.x -= speed;
			transform.position = cameraposition;
		} else if (Input.GetKey ("w")) {
			cameraposition.z += speed;
			transform.position = cameraposition;
		} else if (Input.GetKey ("s")) {
			cameraposition.z -= speed;
			transform.position = cameraposition;
		} 

		if (Input.GetAxis("Mouse ScrollWheel") > 0) {
			cam.orthographicSize -= 40f;
		}

		if(Input.GetAxis("Mouse ScrollWheel") < 0) {
			cam.orthographicSize += 40f;
		}

		if (cameraposition.x < -RIGHT_BAR) {
			cameraposition.x += speed;
			transform.position = cameraposition;
		} else if (cameraposition.x  > RIGHT_BAR) {
			cameraposition.x -= speed;
			transform.position = cameraposition;
		} else if (cameraposition.z  < -TOP_BAR) {
			cameraposition.z += speed;
			transform.position = cameraposition;
		} else if (cameraposition.z  > TOP_BAR) {
			cameraposition.z -= speed;
			transform.position = cameraposition;
		} 

		if (cam.orthographicSize < ZOOM_BAR_IN) {
			cam.orthographicSize += 10f;
		} else if (cam.orthographicSize > ZOOM_BAR_OUT) {
			cam.orthographicSize -= 10f;
		}
	}
}
