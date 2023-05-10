using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
	//Changeable variables for the ship
	public float speed = 10f;
    public float rotationSpeed = 100f;
    public float hoverMargin = 0.5f;
    public float hoverIncrement = 1f;
    public float maxHoverSpeed = 5f;
    public Player player;
    public float originalSpeed;
	public float boostCooldown = 10f;
	public bool canBoost = true;
    public GameObject boostButton;

	private float hoverHeight;
    private float hoverSpeed;
    private Terrain terrain;

    public GameObject DangerScreen;

    RaycastHit hit;
    
	public AudioSource boostSoundEffect;

	public ParticleSystem ps;
	public ParticleSystem ps2;

	private ParticleSystem.MainModule afterBurner1;
	private ParticleSystem.MainModule afterBurner2;

	void Start()
    {
		//Get original speed and thruster for boost upgrade
		originalSpeed = speed;		
        afterBurner1 = ps.main;
		afterBurner2 = ps2.main;
	}

    void Update()
    {
		//Raycast to find terrain and set hoverHeight for the ship
		if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
			//Ensures that the ship is flying above the gameTerrain tagged Terrain
			if (hit.collider.gameObject.tag == "Terrain")
            {
                DangerScreen.SetActive(false);
                adjustHeight();
            }
			//Activates Hazard screen and damages player if the fly over gameTerrain tagged Hazard
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

		// Returns 1 to vertical input if W is pressed, and then moving the ship forward.
		float verticalInput = Input.GetKey(KeyCode.W) ? 1 : 0;
        transform.Translate(Vector3.forward * verticalInput * -speed * Time.deltaTime);

		// Using the built in Input.GetAxis function to get the horizontal input and then rotating the ship.
		float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);

		//  Setting the hover velocity to the difference between the hover height and the current height, and then moving the ship up.
		float hoverVelocity = (hoverHeight - transform.position.y) * speed * Time.deltaTime;
        transform.Translate(Vector3.up * hoverVelocity);

		//Activates the ability to boost if boostUpgrade is true
		if (player.boostUpgrade == true)
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				StartCoroutine(SpeedBoostActivate());
			}
		}

	}

    void adjustHeight()
    {
		//Use data from raycast to assert the position of the ship
		float terrainHeight = hit.point.y;
        float targetHoverHeight = terrainHeight + hoverMargin;
        float hoverError = targetHoverHeight - hoverHeight;
        float hoverAcceleration = hoverError * hoverIncrement;
		//Ensures that the hoverspeed and hoverheight does not go over or under the max/min hover speed/height
		hoverSpeed = Mathf.Clamp(hoverSpeed + hoverAcceleration, -maxHoverSpeed, maxHoverSpeed);
        hoverHeight = Mathf.Clamp(hoverHeight + hoverSpeed * Time.deltaTime, terrainHeight + hoverMargin, Mathf.Infinity);
    }

	private IEnumerator BoostCooldownCoroutine()
	{
		//Cooldown for boost
		canBoost = false;
		yield return new WaitForSeconds(boostCooldown);
		canBoost = true;
		boostButton.SetActive(true);
	}

	private IEnumerator SpeedBoostActivate()
	{
		if (canBoost)
		{
			//Boost ability, sets speed high for 3 sec, and enlargens the particles on the afterburner
			boostButton.SetActive(false);
			boostSoundEffect.Play();
			canBoost = false;
			speed *= 3f;
			afterBurner1.startSize = new ParticleSystem.MinMaxCurve(1f, 1.2f);
			afterBurner2.startSize = new ParticleSystem.MinMaxCurve(1f, 1.2f);
			yield return new WaitForSeconds(2.5f);
			afterBurner1.startSize = new ParticleSystem.MinMaxCurve(0.3f, 0.4f);
			afterBurner2.startSize = new ParticleSystem.MinMaxCurve(0.3f, 0.4f);
            
			speed = originalSpeed;
			StartCoroutine(BoostCooldownCoroutine());			
		}
	}

	public void Reset()
	{
		// Reset the speed of the spaceship.
		speed = originalSpeed;

		// Reset the boost state
		canBoost = true;

		// Reset the particle system
		afterBurner1.startSize = new ParticleSystem.MinMaxCurve(0.3f, 0.4f);
		afterBurner2.startSize = new ParticleSystem.MinMaxCurve(0.3f, 0.4f);
	}
}