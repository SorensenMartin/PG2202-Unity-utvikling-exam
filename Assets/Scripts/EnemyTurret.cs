using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyTurret : MonoBehaviour
{

    public Transform playerTarget;
    public float triggerDistance = 60;
    private GameObject mainHousing;
    private GameObject barrelHousing;

    // Start is called before the first frame update
    void Start()
    {
        // get the barrel housing game object
        mainHousing = transform.GetChild(0).gameObject;
        barrelHousing = mainHousing.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, playerTarget.position) < triggerDistance ) {
            GetComponent<AimConstraint>().constraintActive = true;
            barrelHousing.GetComponent<AimConstraint>().constraintActive = true;

            
        } else {
            GetComponent<AimConstraint>().constraintActive = false;
            barrelHousing.GetComponent<AimConstraint>().constraintActive = false;
        }
    }
}