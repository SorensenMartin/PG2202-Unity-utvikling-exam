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
	public Terrain EdgeTerrain;

	private float hoverHeight;
	private float hoverSpeed; 
	private Terrain terrain;

	
	void Start()
	{
		
		GetComponent<Rigidbody>().useGravity = false;

		RaycastHit hit;
		if (Physics.Raycast(transform.position, Vector3.down, out hit))
		{
			terrain = hit.collider.GetComponent<Terrain>();
			hoverHeight = hit.point.y + hoverMargin;
		}
	}

	void Update()
	{
		RaycastHit hit;
		if (Physics.Raycast(transform.position, Vector3.down, out hit))
		{
			float terrainHeight = hit.point.y;
			float targetHoverHeight = terrainHeight + hoverMargin;
			float hoverError = targetHoverHeight - hoverHeight;
			float hoverAcceleration = hoverError * hoverIncrement;
			hoverSpeed = Mathf.Clamp(hoverSpeed + hoverAcceleration, -maxHoverSpeed, maxHoverSpeed);
			hoverHeight = Mathf.Clamp(hoverHeight + hoverSpeed * Time.deltaTime, terrainHeight + hoverMargin, Mathf.Infinity);

			// Check if the terrain is the correct one
			if (hit.collider.GetComponent<Terrain>() == EdgeTerrain)
			{
				hoverSpeed = 0f;
				transform.Translate(Vector3.forward * speed * Time.deltaTime);
				Debug.Log("Cannot move forward. Wrong terrain.");
			}
		}

		float verticalInput = -Input.GetAxis("Vertical");
		transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);

		float horizontalInput = Input.GetAxis("Horizontal");
		transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);

		
		float hoverVelocity = (hoverHeight - transform.position.y) * speed * Time.deltaTime;
		transform.Translate(Vector3.up * hoverVelocity);
	}
}