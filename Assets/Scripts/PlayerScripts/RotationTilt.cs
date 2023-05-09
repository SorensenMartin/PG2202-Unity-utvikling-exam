using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTilt : MonoBehaviour
{

    public float horisontalTiltAmount = 20f;
    public float verticalTiltAmount = 20f;

    private Quaternion previousRotation;
    private float previousHeight;

    void Start()
    {
        previousRotation = transform.parent.localRotation;
        previousHeight = transform.parent.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horisontal rotation speed of the controller
        Quaternion currentRotation = transform.parent.localRotation;
        Quaternion rotationChange = currentRotation * Quaternion.Inverse(previousRotation);
        Vector3 rotationSpeed = rotationChange.eulerAngles;

        float currentHeight = transform.parent.position.y;
        float heightChange = (currentHeight - previousHeight);

        transform.localRotation = Quaternion.Euler(heightChange * verticalTiltAmount, 0f, rotationSpeed.y * horisontalTiltAmount);
        previousRotation = currentRotation;
        previousHeight = currentHeight;
    }
}
