using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTilt : MonoBehaviour
{
	public float horizontalTiltAmount;
	public float smoothTime;

	private Quaternion previousRotation;

	void Start()
	{
		
		previousRotation = transform.parent.localRotation;
	}

	void Update()
	{
		// Get the horizontal rotation speed of the controller
		Quaternion currentRotation = transform.parent.localRotation;
		Quaternion rotationChange = currentRotation * Quaternion.Inverse(previousRotation);
		Vector3 rotationSpeed = rotationChange.eulerAngles;
		// Make it tilt if you press the Horizontal buttons A or D, negative or positive to feed the
		// horizontalTiltAmount variable, or 0 if its let go steadying the ship.
		float horizontalInput = Input.GetAxis("Horizontal");
		float horizontalTilt = horizontalInput * horizontalTiltAmount;
		Quaternion targetRotation = Quaternion.Euler(0f, 0f, horizontalTilt);
		//Slerp ensures smooth rotations
		transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * smoothTime);

		previousRotation = currentRotation;
	}
}
