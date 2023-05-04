using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAdjuster : MonoBehaviour
{
    public float speed = 8f;
    public float close = -0.0f;
    public float far = -8f;

    private bool forwardLast = false;

    void Update()
    {
        if (forwardLast)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        } else {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        // Make the target move back and forwards so turrets will hit at different speeds
        if (gameObject.transform.localPosition.z >= close)
        {
            forwardLast = true;
        } 
        else if (gameObject.transform.localPosition.z <= far)
        {
            forwardLast = false;
        }
        
    }
}
