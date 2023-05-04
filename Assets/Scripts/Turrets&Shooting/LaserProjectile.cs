using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : MonoBehaviour
{
    public float lifetime = 4;

    void Update()
    {
        lifetime -= Time.deltaTime;
        if ( lifetime <= 0 )
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collider) 
    {
        Destroy(gameObject);
    }
}