using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMovement : MonoBehaviour {
	
	public float speed;
	public Vector3 velocity;

	public GameObject particle;

	// Use this for initialization
	void Start () {
		velocity.x *= speed;
		velocity.z *= speed;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(velocity * Time.deltaTime);
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Satellite") {
			GameObject sat = col.collider.gameObject;
			SatelliteController SScript = (SatelliteController)sat.gameObject.GetComponent <SatelliteController> ();
			SScript.HandleCollision (transform);
			Destroy (particle);

		} else if (col.gameObject.tag == "EndPoint") {
			GameObject end = col.collider.gameObject;
			EndPointController EPScript = (EndPointController)end.gameObject.GetComponent <EndPointController> ();
			EPScript.HandleCollision (transform);
			Destroy (particle);

		} else if (col.gameObject.tag == "Particle") {
			Physics.IgnoreCollision (col.gameObject.GetComponent<Collider> (), GetComponent<Collider> ());

		} else if (col.gameObject.tag == "Wall") {
			Destroy (particle);

		} else if (col.gameObject.tag == "Block") {
			GameObject ship = col.collider.gameObject;
			HumanShipController HScript = (HumanShipController)ship.gameObject.GetComponent<HumanShipController>();
			HScript.HandleCollision();
			Destroy (particle);
		} else if (col.gameObject.tag == "Asteroid") {
			Destroy (particle);
		}
	}

	public void SetVelocity (Vector3 velocityGiven) {
		velocity = velocityGiven;
		print (velocity.z);
		velocity.x *= speed;
		velocity.z *= speed;
	}
}
