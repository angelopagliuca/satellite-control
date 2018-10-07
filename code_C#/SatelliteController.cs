using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SatelliteController : MonoBehaviour {
	
	public int type = 0;
	public int orientation = 0;
	public Transform particlePrefab;
	private bool rotating;
	private float rotation;
	private int rotateSpeed = 120;

	public Material Type0Neutral;
	public Material Type0Pull1;
	public Material Type0Pull2;
	public Material Type0Surprised;
	public Material Type1Neutral;
	public Material Type1Pull1;
	public Material Type1Pull2;
	public Material Type1Surprised;
	public Material Type2Neutral;
	public Material Type2Pull1;
	public Material Type2Pull2;
	public Material Type2Surprised;
	public Material Type3Neutral;
	public Material Type3Pull1;
	public Material Type3Pull2;
	public Material Type3Surprised;


	// Use this for initialization
	void Start () {
		transform.Rotate(90 * orientation * Vector3.up);
		rotating = false;

		switch (type) {
		case 0:
			gameObject.transform.GetChild (0).GetComponent<Renderer> ().material = Type0Neutral;
			break;

		case 1:
			gameObject.transform.GetChild (0).GetComponent<Renderer> ().material = Type1Neutral;
			break;

		case 2:			
			gameObject.transform.GetChild (0).GetComponent<Renderer> ().material = Type2Neutral;
			break;

		case 3:			
			gameObject.transform.GetChild (0).GetComponent<Renderer> ().material = Type3Neutral;
			break;
		}

	}
	// Update is called once per frame
	void Update () {
		
		if (rotating) {
			rotation -= Time.deltaTime * rotateSpeed;
			transform.Rotate (Time.deltaTime * rotateSpeed * Vector3.up); 

			switch (type) {
			case 0:

				if (rotation < 0f) {
					gameObject.transform.GetChild (0).GetComponent<Renderer> ().material = Type0Neutral;
					transform.Rotate (rotation * Vector3.up);
					rotating = false;
				} else if (rotation < 50f) {
					gameObject.transform.GetChild (0).GetComponent<Renderer> ().material = Type0Pull2;
				} else if (rotation < 70f) {
					gameObject.transform.GetChild (0).GetComponent<Renderer> ().material = Type0Pull1;
				} else if (rotation < 80f) {
					gameObject.transform.GetChild (0).GetComponent<Renderer> ().material = Type0Surprised;
				} 


				break;

			case 1:
				if (rotation < 0f) {
					gameObject.transform.GetChild (0).GetComponent<Renderer> ().material = Type1Neutral;
					transform.Rotate (rotation * Vector3.up);
					rotating = false;
				} else if (rotation < 50f) {
					gameObject.transform.GetChild (0).GetComponent<Renderer> ().material = Type1Pull2;
				} else if (rotation < 70f) {
					gameObject.transform.GetChild (0).GetComponent<Renderer> ().material = Type1Pull1;
				} else if (rotation < 80f) {
					gameObject.transform.GetChild (0).GetComponent<Renderer> ().material = Type1Surprised;
				}
				break;

			case 2:			
				if (rotation < 0f) {
					gameObject.transform.GetChild (0).GetComponent<Renderer> ().material = Type2Neutral;
					transform.Rotate (rotation * Vector3.up);
					rotating = false;
				} else if (rotation < 50f) {
					gameObject.transform.GetChild (0).GetComponent<Renderer> ().material = Type2Pull2;
				} else if (rotation < 70f) {
					gameObject.transform.GetChild (0).GetComponent<Renderer> ().material = Type2Pull1;
				} else if (rotation < 80f) {
					gameObject.transform.GetChild (0).GetComponent<Renderer> ().material = Type2Surprised;
				}
				break;

			case 3:		
				if (rotation < 0f) {
					gameObject.transform.GetChild (0).GetComponent<Renderer> ().material = Type3Neutral;
					transform.Rotate (rotation * Vector3.up);
					rotating = false;
				} else if (rotation < 50f) {
					gameObject.transform.GetChild (0).GetComponent<Renderer> ().material = Type3Pull2;
				} else if (rotation < 70f) {
					gameObject.transform.GetChild (0).GetComponent<Renderer> ().material = Type3Pull1;
				} else if (rotation < 80f) {
					gameObject.transform.GetChild (0).GetComponent<Renderer> ().material = Type3Surprised;
				} 
				break;
			} 
		}
	}

	void OnMouseDown () {
		if (!rotating) {
			Rotate();
			SoundManager.S.PlayGrunt();
		}
	}

	private void Rotate () {
		orientation = (orientation + 1) % 4;
		rotating = true;
		rotation = 90f;
	}

	public void HandleCollision(Transform collided) { 
		if (rotating) {
			return;
		}
		switch (type) {
		case 0:
			if (orientation == 0 || orientation == 2) {
				if (collided.position.z + 20f < transform.position.z) {
					Transform particle = Instantiate(particlePrefab, transform.position + (100f * Vector3.forward), Quaternion.identity);
					ParticleMovement PScript = (ParticleMovement)particle.gameObject.GetComponent <ParticleMovement> ();
					PScript.velocity = new Vector3 (0, 0, 100);
					Rigidbody rb = (Rigidbody) particle.GetComponent<Rigidbody>();
					rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				} else if (collided.position.z - 20f > transform.position.z) {
					Transform particle = Instantiate(particlePrefab, transform.position - (100f * Vector3.forward), Quaternion.identity);
					ParticleMovement PScript = (ParticleMovement)particle.gameObject.GetComponent <ParticleMovement> ();
					PScript.velocity = new Vector3 (0, 0, -100);
					Rigidbody rb = (Rigidbody) particle.GetComponent<Rigidbody>();
					rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				}
			} else if (orientation == 1 || orientation == 3) {
				if (collided.position.x - 20f > transform.position.x) {
					Transform particle = Instantiate(particlePrefab, transform.position - (100f * Vector3.right), Quaternion.identity);
					ParticleMovement PScript = (ParticleMovement)particle.gameObject.GetComponent <ParticleMovement>();
					PScript.velocity = new Vector3(-100, 0, 0);
					Rigidbody rb = (Rigidbody) particle.GetComponent<Rigidbody>();
					rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				} else if (collided.position.x + 20f < transform.position.x) {
					Transform particle = Instantiate(particlePrefab, transform.position + (100f * Vector3.right), Quaternion.identity);
					ParticleMovement PScript = (ParticleMovement)particle.gameObject.GetComponent <ParticleMovement> ();
					PScript.velocity = new Vector3 (100, 0, 0);
					Rigidbody rb = (Rigidbody) particle.GetComponent<Rigidbody>();
					rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				}
			}
			break;
		case 1:
			if (orientation == 0) {
				if (collided.position.z - 20f > transform.position.z) {
					Transform particle = Instantiate(particlePrefab, transform.position + (100f * Vector3.right), Quaternion.identity);
					ParticleMovement PScript = (ParticleMovement)particle.gameObject.GetComponent <ParticleMovement> ();
					PScript.velocity = new Vector3 (100, 0, 0);
					Rigidbody rb = (Rigidbody) particle.GetComponent<Rigidbody>();
					rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				} else if (collided.position.x - 20f > transform.position.x) {
					Transform particle = Instantiate(particlePrefab, transform.position + (100f * Vector3.forward), Quaternion.identity);
					ParticleMovement PScript = (ParticleMovement)particle.gameObject.GetComponent <ParticleMovement> ();
					PScript.velocity = new Vector3 (0, 0, 100);
					Rigidbody rb = (Rigidbody) particle.GetComponent<Rigidbody>();
					rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				}
			} else if (orientation == 1) {
				if (collided.position.x - 20f > transform.position.x) {
					Transform particle = Instantiate(particlePrefab, transform.position - (100f * Vector3.forward), Quaternion.identity);
					ParticleMovement PScript = (ParticleMovement)particle.gameObject.GetComponent <ParticleMovement>();
					PScript.velocity = new Vector3(0, 0, -100);
					Rigidbody rb = (Rigidbody) particle.GetComponent<Rigidbody>();
					rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				} else if (collided.position.z + 20f < transform.position.z) {
					Transform particle = Instantiate(particlePrefab, transform.position + (100f * Vector3.right), Quaternion.identity);
					ParticleMovement PScript = (ParticleMovement)particle.gameObject.GetComponent <ParticleMovement> ();
					PScript.velocity = new Vector3 (100, 0, 0);
					Rigidbody rb = (Rigidbody) particle.GetComponent<Rigidbody>();
					rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				}
			} else if (orientation == 2) {
				if (collided.position.z + 20f < transform.position.z) {
					Transform particle = Instantiate(particlePrefab, transform.position - (100f * Vector3.right), Quaternion.identity);
					ParticleMovement PScript = (ParticleMovement)particle.gameObject.GetComponent <ParticleMovement>();
					PScript.velocity = new Vector3(-100, 0, 0);
					Rigidbody rb = (Rigidbody) particle.GetComponent<Rigidbody>();
					rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				} else if (collided.position.x + 20f < transform.position.x) {
					Transform particle = Instantiate(particlePrefab, transform.position - (100f * Vector3.forward), Quaternion.identity);
					ParticleMovement PScript = (ParticleMovement)particle.gameObject.GetComponent <ParticleMovement> ();
					PScript.velocity = new Vector3 (0, 0, -100);
					Rigidbody rb = (Rigidbody) particle.GetComponent<Rigidbody>();
					rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				}
			} else if (orientation == 3) {
				if (collided.position.x + 20f < transform.position.x) {
					Transform particle = Instantiate(particlePrefab, transform.position + (100f * Vector3.forward), Quaternion.identity);
					ParticleMovement PScript = (ParticleMovement)particle.gameObject.GetComponent <ParticleMovement>();
					PScript.velocity = new Vector3(0, 0, 100);
					Rigidbody rb = (Rigidbody) particle.GetComponent<Rigidbody>();
					rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				} else if (collided.position.z - 20f > transform.position.z) {
					Transform particle = Instantiate(particlePrefab, transform.position - (100f * Vector3.right), Quaternion.identity);
					ParticleMovement PScript = (ParticleMovement)particle.gameObject.GetComponent <ParticleMovement> ();
					PScript.velocity = new Vector3 (-100, 0, 0);
					Rigidbody rb = (Rigidbody) particle.GetComponent<Rigidbody>();
					rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				}
			}
			break;
		case 2:			
			if (orientation == 0) {
				if (collided.position.z - 20f > transform.position.z) {

					Transform particle0 = Instantiate(particlePrefab, transform.position + (100f * Vector3.right), Quaternion.identity);
					ParticleMovement PScript0 = (ParticleMovement)particle0.gameObject.GetComponent <ParticleMovement>();
					PScript0.velocity = new Vector3(100, 0, 0);
					Rigidbody rb0 = (Rigidbody) particle0.GetComponent<Rigidbody>();
					rb0.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

					Transform particle1 = Instantiate(particlePrefab, transform.position - (100f * Vector3.forward), Quaternion.identity);
					ParticleMovement PScript1 = (ParticleMovement)particle1.gameObject.GetComponent <ParticleMovement>();
					PScript1.velocity = new Vector3(0, 0, -100);
					Rigidbody rb1 = (Rigidbody) particle1.GetComponent<Rigidbody>();
					rb1.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				} else if (collided.position.z + 20f < transform.position.z) {

					Transform particle0 = Instantiate(particlePrefab, transform.position + (100f * Vector3.right), Quaternion.identity);
					ParticleMovement PScript0 = (ParticleMovement)particle0.gameObject.GetComponent <ParticleMovement>();
					PScript0.velocity = new Vector3(100, 0, 0);
					Rigidbody rb0 = (Rigidbody) particle0.GetComponent<Rigidbody>();
					rb0.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

					Transform particle1 = Instantiate(particlePrefab, transform.position + (100f * Vector3.forward), Quaternion.identity);
					ParticleMovement PScript1 = (ParticleMovement)particle1.gameObject.GetComponent <ParticleMovement>();
					PScript1.velocity = new Vector3(0, 0, 100);
					Rigidbody rb1 = (Rigidbody) particle1.GetComponent<Rigidbody>();
					rb1.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				} else if (collided.position.x - 20f > transform.position.x) {

					Transform particle0 = Instantiate(particlePrefab, transform.position + (100f * Vector3.forward), Quaternion.identity);
					ParticleMovement PScript0 = (ParticleMovement)particle0.gameObject.GetComponent <ParticleMovement>();
					PScript0.velocity = new Vector3(0, 0, 100);
					Rigidbody rb0 = (Rigidbody) particle0.GetComponent<Rigidbody>();
					rb0.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

					Transform particle1 = Instantiate(particlePrefab, transform.position - (100f * Vector3.forward), Quaternion.identity);
					ParticleMovement PScript1 = (ParticleMovement)particle1.gameObject.GetComponent <ParticleMovement>();
					PScript1.velocity = new Vector3(0, 0, -100);
					Rigidbody rb1 = (Rigidbody) particle1.GetComponent<Rigidbody>();
					rb1.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				}
			} else if (orientation == 1) {
				if (collided.position.x - 20f > transform.position.x) {

					Transform particle0 = Instantiate(particlePrefab, transform.position - (100f * Vector3.right), Quaternion.identity);
					ParticleMovement PScript0 = (ParticleMovement)particle0.gameObject.GetComponent <ParticleMovement>();
					PScript0.velocity = new Vector3(-100, 0, 0);
					Rigidbody rb0 = (Rigidbody) particle0.GetComponent<Rigidbody>();
					rb0.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

					Transform particle1 = Instantiate(particlePrefab, transform.position - (100f * Vector3.forward), Quaternion.identity);
					ParticleMovement PScript1 = (ParticleMovement)particle1.gameObject.GetComponent <ParticleMovement>();
					PScript1.velocity = new Vector3(0, 0, -100);
					Rigidbody rb1 = (Rigidbody) particle1.GetComponent<Rigidbody>();
					rb1.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				} else if (collided.position.x + 20f < transform.position.x) {

					Transform particle0 = Instantiate(particlePrefab, transform.position + (100f * Vector3.right), Quaternion.identity);
					ParticleMovement PScript0 = (ParticleMovement)particle0.gameObject.GetComponent <ParticleMovement>();
					PScript0.velocity = new Vector3(100, 0, 0);
					Rigidbody rb0 = (Rigidbody) particle0.GetComponent<Rigidbody>();
					rb0.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

					Transform particle1 = Instantiate(particlePrefab, transform.position - (100f * Vector3.forward), Quaternion.identity);
					ParticleMovement PScript1 = (ParticleMovement)particle1.gameObject.GetComponent <ParticleMovement>();
					PScript1.velocity = new Vector3(0, 0, -100);
					Rigidbody rb1 = (Rigidbody) particle1.GetComponent<Rigidbody>();
					rb1.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				} else if (collided.position.z + 20f < transform.position.z) {

					Transform particle0 = Instantiate(particlePrefab, transform.position + (100f * Vector3.right), Quaternion.identity);
					ParticleMovement PScript0 = (ParticleMovement)particle0.gameObject.GetComponent <ParticleMovement>();
					PScript0.velocity = new Vector3(100, 0, 0);
					Rigidbody rb0 = (Rigidbody) particle0.GetComponent<Rigidbody>();
					rb0.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

					Transform particle1 = Instantiate(particlePrefab, transform.position - (100f * Vector3.right), Quaternion.identity);
					ParticleMovement PScript1 = (ParticleMovement)particle1.gameObject.GetComponent <ParticleMovement>();
					PScript1.velocity = new Vector3(-100, 0, 0);
					Rigidbody rb1 = (Rigidbody) particle1.GetComponent<Rigidbody>();
					rb1.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				}
			} else if (orientation == 2) {
				if (collided.position.z - 20f > transform.position.z) {

					Transform particle0 = Instantiate(particlePrefab, transform.position - (100f * Vector3.right), Quaternion.identity);
					ParticleMovement PScript0 = (ParticleMovement)particle0.gameObject.GetComponent <ParticleMovement>();
					PScript0.velocity = new Vector3(-100, 0, 0);
					Rigidbody rb0 = (Rigidbody) particle0.GetComponent<Rigidbody>();
					rb0.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

					Transform particle1 = Instantiate(particlePrefab, transform.position - (100f * Vector3.forward), Quaternion.identity);
					ParticleMovement PScript1 = (ParticleMovement)particle1.gameObject.GetComponent <ParticleMovement>();
					PScript1.velocity = new Vector3(0, 0, -100);
					Rigidbody rb1 = (Rigidbody) particle1.GetComponent<Rigidbody>();
					rb1.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				} else if (collided.position.z + 20f < transform.position.z) {

					Transform particle0 = Instantiate(particlePrefab, transform.position - (100f * Vector3.right), Quaternion.identity);
					ParticleMovement PScript0 = (ParticleMovement)particle0.gameObject.GetComponent <ParticleMovement>();
					PScript0.velocity = new Vector3(-100, 0, 0);
					Rigidbody rb0 = (Rigidbody) particle0.GetComponent<Rigidbody>();
					rb0.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

					Transform particle1 = Instantiate(particlePrefab, transform.position + (100f * Vector3.forward), Quaternion.identity);
					ParticleMovement PScript1 = (ParticleMovement)particle1.gameObject.GetComponent <ParticleMovement>();
					PScript1.velocity = new Vector3(0, 0, 100);
					Rigidbody rb1 = (Rigidbody) particle1.GetComponent<Rigidbody>();
					rb1.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				} else if (collided.position.x + 20f < transform.position.x) {

					Transform particle0 = Instantiate(particlePrefab, transform.position + (100f * Vector3.forward), Quaternion.identity);
					ParticleMovement PScript0 = (ParticleMovement)particle0.gameObject.GetComponent <ParticleMovement>();
					PScript0.velocity = new Vector3(0, 0, 100);
					Rigidbody rb0 = (Rigidbody) particle0.GetComponent<Rigidbody>();
					rb0.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

					Transform particle1 = Instantiate(particlePrefab, transform.position - (100f * Vector3.forward), Quaternion.identity);
					ParticleMovement PScript1 = (ParticleMovement)particle1.gameObject.GetComponent <ParticleMovement>();
					PScript1.velocity = new Vector3(0, 0, -100);
					Rigidbody rb1 = (Rigidbody) particle1.GetComponent<Rigidbody>();
					rb1.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				}
			} else if (orientation == 3) {
				if (collided.position.x - 20f > transform.position.x) {

					Transform particle0 = Instantiate(particlePrefab, transform.position - (100f * Vector3.right), Quaternion.identity);
					ParticleMovement PScript0 = (ParticleMovement)particle0.gameObject.GetComponent <ParticleMovement>();
					PScript0.velocity = new Vector3(-100, 0, 0);
					Rigidbody rb0 = (Rigidbody) particle0.GetComponent<Rigidbody>();
					rb0.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

					Transform particle1 = Instantiate(particlePrefab, transform.position + (100f * Vector3.forward), Quaternion.identity);
					ParticleMovement PScript1 = (ParticleMovement)particle1.gameObject.GetComponent <ParticleMovement>();
					PScript1.velocity = new Vector3(0, 0, 100);
					Rigidbody rb1 = (Rigidbody) particle1.GetComponent<Rigidbody>();
					rb1.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				} else if (collided.position.x + 20f < transform.position.x) {

					Transform particle0 = Instantiate(particlePrefab, transform.position + (100f * Vector3.right), Quaternion.identity);
					ParticleMovement PScript0 = (ParticleMovement)particle0.gameObject.GetComponent <ParticleMovement>();
					PScript0.velocity = new Vector3(100, 0, 0);
					Rigidbody rb0 = (Rigidbody) particle0.GetComponent<Rigidbody>();
					rb0.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

					Transform particle1 = Instantiate(particlePrefab, transform.position + (100f * Vector3.forward), Quaternion.identity);
					ParticleMovement PScript1 = (ParticleMovement)particle1.gameObject.GetComponent <ParticleMovement>();
					PScript1.velocity = new Vector3(0, 0, 100);
					Rigidbody rb1 = (Rigidbody) particle1.GetComponent<Rigidbody>();
					rb1.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				} else if (collided.position.z - 20f > transform.position.z) {

					Transform particle0 = Instantiate(particlePrefab, transform.position + (100f * Vector3.right), Quaternion.identity);
					ParticleMovement PScript0 = (ParticleMovement)particle0.gameObject.GetComponent <ParticleMovement>();
					PScript0.velocity = new Vector3(100, 0, 0);
					Rigidbody rb0 = (Rigidbody) particle0.GetComponent<Rigidbody>();
					rb0.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

					Transform particle1 = Instantiate(particlePrefab, transform.position - (100f * Vector3.right), Quaternion.identity);
					ParticleMovement PScript1 = (ParticleMovement)particle1.gameObject.GetComponent <ParticleMovement>();
					PScript1.velocity = new Vector3(-100, 0, 0);
					Rigidbody rb1 = (Rigidbody) particle1.GetComponent<Rigidbody>();
					rb1.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				}
			}
			break;
		case 3:			
			if (orientation == 0 || orientation == 1 || orientation == 2 || orientation == 3) {
				if (collided.position.z - 20f > transform.position.z) {
					
					Transform particle0 = Instantiate(particlePrefab, transform.position + (100f * Vector3.right), Quaternion.identity);
					ParticleMovement PScript0 = (ParticleMovement)particle0.gameObject.GetComponent <ParticleMovement> ();
					PScript0.velocity = new Vector3 (100, 0, 0);
					Rigidbody rb0 = (Rigidbody) particle0.GetComponent<Rigidbody>();
					rb0.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

					Transform particle1 = Instantiate(particlePrefab, transform.position - (100f * Vector3.right), Quaternion.identity);
					ParticleMovement PScript1 = (ParticleMovement)particle1.gameObject.GetComponent <ParticleMovement> ();
					PScript1.velocity = new Vector3 (-100, 0, 0);
					Rigidbody rb1 = (Rigidbody) particle1.GetComponent<Rigidbody>();
					rb1.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

					Transform particle2 = Instantiate(particlePrefab, transform.position - (100f * Vector3.forward), Quaternion.identity);
					ParticleMovement PScript2 = (ParticleMovement)particle2.gameObject.GetComponent <ParticleMovement> ();
					PScript2.velocity = new Vector3 (0, 0, -100);
					Rigidbody rb2 = (Rigidbody) particle2.GetComponent<Rigidbody>();
					rb2.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				} else if (collided.position.z + 20f < transform.position.z) {
					
					Transform particle0 = Instantiate(particlePrefab, transform.position + (100f * Vector3.right), Quaternion.identity);
					ParticleMovement PScript0 = (ParticleMovement)particle0.gameObject.GetComponent <ParticleMovement> ();
					PScript0.velocity = new Vector3 (100, 0, 0);
					Rigidbody rb0 = (Rigidbody) particle0.GetComponent<Rigidbody>();
					rb0.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

					Transform particle1 = Instantiate(particlePrefab, transform.position - (100f * Vector3.right), Quaternion.identity);
					ParticleMovement PScript1 = (ParticleMovement)particle1.gameObject.GetComponent <ParticleMovement> ();
					PScript1.velocity = new Vector3 (-100, 0, 0);
					Rigidbody rb1 = (Rigidbody) particle1.GetComponent<Rigidbody>();
					rb1.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

					Transform particle2 = Instantiate(particlePrefab, transform.position + (100f * Vector3.forward), Quaternion.identity);
					ParticleMovement PScript2 = (ParticleMovement)particle2.gameObject.GetComponent <ParticleMovement> ();
					PScript2.velocity = new Vector3 (0, 0, 100);
					Rigidbody rb2 = (Rigidbody) particle2.GetComponent<Rigidbody>();
					rb2.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				} else if (collided.position.x - 20f > transform.position.x) {
					
					Transform particle0 = Instantiate(particlePrefab, transform.position + (100f * Vector3.forward), Quaternion.identity);
					ParticleMovement PScript0 = (ParticleMovement)particle0.gameObject.GetComponent <ParticleMovement> ();
					PScript0.velocity = new Vector3 (0, 0, 100);
					Rigidbody rb0 = (Rigidbody) particle0.GetComponent<Rigidbody>();
					rb0.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

					Transform particle1 = Instantiate(particlePrefab, transform.position - (100f * Vector3.forward), Quaternion.identity);
					ParticleMovement PScript1 = (ParticleMovement)particle1.gameObject.GetComponent <ParticleMovement> ();
					PScript1.velocity = new Vector3 (0, 0, -100);
					Rigidbody rb1 = (Rigidbody) particle1.GetComponent<Rigidbody>();
					rb1.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

					Transform particle2 = Instantiate(particlePrefab, transform.position - (100f * Vector3.right), Quaternion.identity);
					ParticleMovement PScript2 = (ParticleMovement)particle2.gameObject.GetComponent <ParticleMovement> ();
					PScript2.velocity = new Vector3 (-100, 0, 0);
					Rigidbody rb2 = (Rigidbody) particle2.GetComponent<Rigidbody>();
					rb2.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

				} else if (collided.position.x + 20f < transform.position.x) {

					Transform particle0 = Instantiate(particlePrefab, transform.position + (100f * Vector3.right), Quaternion.identity);
					ParticleMovement PScript0 = (ParticleMovement)particle0.gameObject.GetComponent <ParticleMovement> ();
					PScript0.velocity = new Vector3 (100, 0, 0);
					Rigidbody rb0 = (Rigidbody) particle0.GetComponent<Rigidbody>();
					rb0.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

					Transform particle1 = Instantiate(particlePrefab, transform.position - (100f * Vector3.forward), Quaternion.identity);
					ParticleMovement PScript1 = (ParticleMovement)particle1.gameObject.GetComponent <ParticleMovement> ();
					PScript1.velocity = new Vector3 (0, 0, -100);
					Rigidbody rb1 = (Rigidbody) particle1.GetComponent<Rigidbody>();
					rb1.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

					Transform particle2 = Instantiate(particlePrefab, transform.position + (100f * Vector3.forward), Quaternion.identity);
					ParticleMovement PScript2 = (ParticleMovement)particle2.gameObject.GetComponent <ParticleMovement> ();
					PScript2.velocity = new Vector3 (0, 0, 100);
					Rigidbody rb2 = (Rigidbody) particle2.GetComponent<Rigidbody>();
					rb2.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
				}
			} 
			break;
		}
	}
}
