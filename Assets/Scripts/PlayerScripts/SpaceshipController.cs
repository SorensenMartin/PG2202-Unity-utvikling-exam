using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 100f;
    public float hoverMargin = 0.5f;
    public float hoverIncrement = 1f;
    public float maxHoverSpeed = 5f;
    public Player player;

    private float hoverHeight;
    private float hoverSpeed;
    private Terrain terrain;

    public GameObject DangerScreen;

    RaycastHit hit;

    void Start()
    {
        /*
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            terrain = hit.collider.GetComponent<Terrain>();
            hoverHeight = hit.point.y + hoverMargin;
        }*/
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {

            if (hit.collider.gameObject.tag == "Terrain")
            {
                DangerScreen.SetActive(false);
                adjustHeight();
            }
            else if (hit.collider.gameObject.tag == "Hazard")
            {
                adjustHeight();
                DangerScreen.SetActive(true);
                if (Time.frameCount % 400 == 0)
                {
                    player.health -= 1;
                    if (player.health <= 0)
                    {
                        player.gameManager.EndGame();
                        DangerScreen.SetActive(false);
                    }
                }
            }

        }
        // if nothing is detected airplane rapidly moves up (to prevent bug where airplane could clip through map)
        else
        {
            transform.Translate(Vector3.up * 10);
        }


        float verticalInput = Input.GetKey(KeyCode.W) ? 1 : 0;
        transform.Translate(Vector3.forward * verticalInput * -speed * Time.deltaTime);

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);

        float hoverVelocity = (hoverHeight - transform.position.y) * speed * Time.deltaTime;
        transform.Translate(Vector3.up * hoverVelocity);
    }

    void adjustHeight()
    {
        float terrainHeight = hit.point.y;
        float targetHoverHeight = terrainHeight + hoverMargin;
        float hoverError = targetHoverHeight - hoverHeight;
        float hoverAcceleration = hoverError * hoverIncrement;
        hoverSpeed = Mathf.Clamp(hoverSpeed + hoverAcceleration, -maxHoverSpeed, maxHoverSpeed);
        hoverHeight = Mathf.Clamp(hoverHeight + hoverSpeed * Time.deltaTime, terrainHeight + hoverMargin, Mathf.Infinity);
    }
}