using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : MonoBehaviour
{
    public float lifetime = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if ( lifetime <= 0 )
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) {
        Destroy(gameObject);
    }
}
