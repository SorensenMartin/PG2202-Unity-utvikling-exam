using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform gameCamera;
    public float cameraZoomSpeed = 2;

    public float maxCameraDistance = 20;

    private float cameraDistance = 4;
    private Vector2 cameraRotation;



    // Start is called before the first frame update
    void Start()
    {
        
        resetCameraRotation();
    }

    // Update is called once per frame
    void Update()
    {
        // Reset camera if middle mouse button is pressed
        if (Input.GetKeyDown(KeyCode.Mouse2)){
            resetCameraRotation();
        }

        // only rotate if right mouse buttun is pressed
        if (Input.GetKey(KeyCode.Mouse1))
        {
            // Gets the movement of the mouse    
            cameraRotation.x += Input.GetAxis("Mouse X");
            cameraRotation.y += Input.GetAxis("Mouse Y");
            // Rotate this object based on mouse movement
            transform.localRotation = Quaternion.Euler(cameraRotation.y, cameraRotation.x, 0);
        }

        cameraDistance -= Input.GetAxis("Mouse ScrollWheel") * cameraZoomSpeed;
        cameraDistance = Mathf.Clamp(cameraDistance, 1, maxCameraDistance);
        gameCamera.localPosition = new Vector3(0, 0, cameraDistance);
    }

    void resetCameraRotation()
    {
        cameraRotation.x = 0;
        cameraRotation.y = -30;
        transform.localRotation = Quaternion.Euler(cameraRotation.y, cameraRotation.x, 0);
    }
}
