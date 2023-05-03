using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public GameObject projectile;

    public float fireRate = 0.4f;
    public float firstShotDelay = 0f;

    public float spread = 50.0f;

    public float projectileSpeed = 4000f;

    public void StartFiring()
    {
        InvokeRepeating("Fire", firstShotDelay, fireRate);
    }

    public void StopFiring()
    {
        CancelInvoke();
    }

    void Fire()
    {
        GameObject instance = Instantiate(projectile, transform.position, transform.rotation);
        instance.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(Random.Range(-spread, spread), -projectileSpeed, Random.Range(-spread, spread)));
    }

}
