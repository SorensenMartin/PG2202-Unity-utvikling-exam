using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float speed = 10f; // Adjust this to change the ship's movement speed
    public float rotationSpeed = 100f; // Adjust this to change the ship's rotation speed
    public float hoverMargin = 0.5f; // Adjust this to change the ship's hover margin
    public float hoverIncrement = 1f; // Adjust this to change the amount by which the hover height is increased/decreased
    public float maxHoverSpeed = 5f; // Adjust this to change the maximum speed at which the hover height can change

    private float hoverHeight; // The current hover height of the ship
    private float hoverSpeed; // The current speed at which the hover height is changing

    // Start is called before the first frame update
    void Start()
    {
        // Disable gravity so that the ship maintains its altitude
        GetComponent<Rigidbody>().useGravity = false;

        // Set initial hover height to the current altitude of the ship
        hoverHeight = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Update hover height based on input
        if (Input.GetKey(KeyCode.Space))
        {
            hoverSpeed += hoverIncrement * Time.deltaTime;
            hoverSpeed = Mathf.Clamp(hoverSpeed, 0f, maxHoverSpeed);
            hoverHeight += hoverSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            hoverSpeed -= hoverIncrement * Time.deltaTime;
            hoverSpeed = Mathf.Clamp(hoverSpeed, -maxHoverSpeed, 0f);
            hoverHeight += hoverSpeed * Time.deltaTime;
        }
        else
        {
            hoverSpeed = 0f;
        }

        // Keep ship at hover height plus margin
        float hoverInput = 0f;
        if (transform.position.y > hoverHeight + hoverMargin)
        {
            hoverInput = -1f;
        }
        else if (transform.position.y < hoverHeight - hoverMargin)
        {
            hoverInput = 1f;
        }

        // Move forward/backward
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);

        // Rotate left/right
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);

        // Move up/down
        float hoverVelocity = hoverInput * speed * Time.deltaTime;
        transform.Translate(Vector3.up * hoverVelocity);
    }
}