using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyTurret : MonoBehaviour
{
    // How close the player can get before the turret will start to aim at them
    public float aimingDistance = 60;

    // How much closer the player can get from the aiming distance before the turret opens fire
    public float firingMargin = 10;

    private GameObject mainHousing;
    private GameObject barrelHousing;
    private GameObject projectileParent;
    public Transform playerTargetTransform;
    public ConstraintSource playerTarget;

    private enum State
    {
        Idle,
        Aiming,
        Firing
    }

    private State _activeState;

    void Start()
    {
        // Find player target
        playerTargetTransform = GameObject.FindGameObjectWithTag("PlayerTarget").transform;
        playerTarget.sourceTransform = playerTargetTransform;

        // set the different parts of the turret to variables for later use
        mainHousing = transform.GetChild(0).gameObject;
        barrelHousing = mainHousing.transform.GetChild(0).gameObject;
        projectileParent = barrelHousing.transform.GetChild(1).gameObject;        

        // Set the target for the aim and look at constraints
        playerTarget.weight = 1;
        GetComponent<AimConstraint>().AddSource(playerTarget);
        barrelHousing.GetComponent<LookAtConstraint>().AddSource(playerTarget);

        // set to idle state
        _activeState = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        if (_activeState == State.Idle)
        {
            _Idle();
        } else if (_activeState == State.Aiming)
        {
            _Aiming();
        } else if (_activeState == State.Firing)
        {
            _Firing();
        }
    }

    void enterIdle()
    {
        _activeState = State.Idle;
        GetComponent<AimConstraint>().constraintActive = false;
        barrelHousing.GetComponent<LookAtConstraint>().constraintActive = false;
    }

    void _Idle()
    {
        if (Vector3.Distance(transform.position, playerTargetTransform.position) < aimingDistance ) {
            enterAiming();
        }
    }

    void enterAiming()
    {
        _activeState = State.Aiming;
        GetComponent<AimConstraint>().constraintActive = true;
        barrelHousing.GetComponent<LookAtConstraint>().constraintActive = true;
        foreach (Transform child in projectileParent.transform)
        {
            child.GetComponent<FireProjectile>().StopFiring();
        }
    }

    void _Aiming()
    {
        if (Vector3.Distance(transform.position, playerTargetTransform.position) > aimingDistance ) 
        {
            enterAiming();
        } else if (Vector3.Distance(transform.position, playerTargetTransform.position) < (aimingDistance - firingMargin) ) {
            enterFiring();
        }
    }

    void enterFiring()
    {
        _activeState = State.Firing;
        foreach (Transform child in projectileParent.transform)
        {
            child.GetComponent<FireProjectile>().StartFiring();
        }
    }

    void _Firing()
    {
        if (Vector3.Distance(transform.position, playerTargetTransform.position) > (aimingDistance - firingMargin) )
        {
            enterAiming();
        }
    }

}