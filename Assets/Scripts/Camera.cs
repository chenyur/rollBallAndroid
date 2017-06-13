using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
	public GameObject player;
	public Rigidbody playerRB;
	public float speedOffsetMultiplier = 0.5f;
	public float crashThreshold = 1f;
	public float offsetChangeInFrames = 10;
	private Vector3 offset;
	private Vector3 velocityOffset;
	private float velocity;
	private float oldVelocity;

	void Start () {
		offset = transform.position - player.transform.position;
		oldVelocity = playerRB.velocity.magnitude;
	}
	
	// Update is called once per frame
	void Update () {
		velocity = playerRB.velocity.magnitude;
		if ((oldVelocity - velocity) > crashThreshold) {
			velocity = oldVelocity - oldVelocity / offsetChangeInFrames;
		}
		velocityOffset = new Vector3 (0, velocity, -velocity);
		transform.position = player.transform.position + offset + velocityOffset * speedOffsetMultiplier;
		oldVelocity = velocity;
	}
}
