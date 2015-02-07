using UnityEngine;
using System.Collections;

public class GravityPlayer : Actor {

	public GameObject planet;
	bool grounded = false;
	float gravityAccel = 9.81f;
	public float moveForce = 10f;

	void Awake () {
	
	}
	
	void Start () {
	
	}

	void Update() {
		Vector3 vectorToPlanetCenter = planet.transform.position - transform.position;
		// Make capsule upright
		// Rotate to make y axis point in the opposite direction of vectorToPlanetCenter
		transform.rotation = (Quaternion.LookRotation(-vectorToPlanetCenter));
		transform.eulerAngles += new Vector3(90, 0, 0);
	}

	void FixedUpdate() {
		// Fall towards planet
		Vector3 vectorToPlanetCenter = planet.transform.position - transform.position;
		if (!grounded) {
			rigidbody.AddForce(vectorToPlanetCenter * gravityAccel);
		}

		if (ActionMaster.GetAction(ActionCode.MoveForward)) {
			rigidbody.AddForce(transform.forward * moveForce);
		} else if (ActionMaster.GetAction(ActionCode.MoveBackward)) {
			rigidbody.AddForce(-transform.forward * moveForce);
		}
		if (ActionMaster.GetAction(ActionCode.StrafeLeft)) {
			rigidbody.AddForce(-transform.right * moveForce);
		} else if (ActionMaster.GetAction(ActionCode.StrafeRight)) {
			rigidbody.AddForce(transform.right * moveForce);
		}
		if (ActionMaster.GetAction(ActionCode.Jump)) {
			rigidbody.AddForce(transform.up * moveForce);
		}
		rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, 2f);
	}
}
