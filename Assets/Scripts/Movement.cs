using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class Movement : MonoBehaviour {
	// Update is called once per frame

	private Rigidbody rb;
	public float speed = 1;
	public float bounceHeight = 50;
	public float drag = 1f;
	public float crashThreshold = 1f;
	public AudioSource bounceAudio;


	float oldVelocity;

	void Start() {
		rb = GetComponent<Rigidbody> ();
		oldVelocity = rb.velocity.magnitude;
		bounceAudio = GetComponent<AudioSource>();
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit(); 
		}

		Vector3 bounce = new Vector3 (0.0f, bounceHeight, 0.0f);

		rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

		if ((oldVelocity - rb.velocity.magnitude) > crashThreshold) {
			print ("bounced!");
			rb.AddForce (bounce);
			bounceAudio.Play ();
			Handheld.Vibrate ();
		}
		oldVelocity = rb.velocity.magnitude;
	}
	void FixedUpdate () {
		float moveHorizontal = Input.acceleration.x;
		float moveVertical = Input.acceleration.y;

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}
}
