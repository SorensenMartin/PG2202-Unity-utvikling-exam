using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PirateFighter : MonoBehaviour
{
    // How close the player can get before the fighter will start to chase them
    public float ChasingDistance = 70f;
    // How much closer the player can get from the Chasing distance before the turret opens fire
    public float firingMargin = 30f;

    public float PullBackDistance = 10f;

    public float patrolDistance = 100f;
    public float giveUpDistance = 200;
    public float baseSpeed = 10f;

    public float hoverMargin = 5f;
    public float hoverIncrement = 1f;
    public float maxHoverSpeed = 5f;

    private float hoverHeight;
    private float hoverSpeed;

    private float hoverVelocity;

    RaycastHit hit;

    private GameObject origin;
    private GameObject fighterMesh;

    private GameObject projectileParent;
    public Transform playerTargetTransform;
    public ConstraintSource playerTarget;

    private enum State
    {
        Patrolling,
        Chasing,
        Firing,
        PullBack,
        ReturnToOrigin
    }

    private State _activeState;

    void Start()
    {

        // Find player target
        playerTargetTransform = GameObject.FindGameObjectWithTag("PlayerTarget").transform;
        playerTarget.sourceTransform = playerTargetTransform;

        // set the different parts of the turret to variables for later use
        origin = transform.parent.gameObject;
        fighterMesh = transform.GetChild(0).gameObject;
        projectileParent = fighterMesh.transform.GetChild(0).gameObject;

        // Set the target for the look at constraints
        playerTarget.weight = 1;
        GetComponent<LookAtConstraint>().AddSource(playerTarget);

        // set to Patrolling state
        _activeState = State.Patrolling;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            adjustHeight();
        }
        //
        hoverVelocity = (hoverHeight - transform.position.y) * baseSpeed * Time.deltaTime;
        transform.Translate(Vector3.up * hoverVelocity);

        // make the pirate return to origin and if the player is too far away, but only if in another state than patrolling
        if (_activeState != State.Patrolling)
        {
            if (Vector3.Distance(origin.transform.position, playerTargetTransform.position) > giveUpDistance)
            {
                enterReturnToOrigin();
            }
        }

        if (_activeState == State.Patrolling)
        {
            _Patrolling();
        }
        else if (_activeState == State.Chasing)
        {
            _Chasing();
        }
        else if (_activeState == State.Firing)
        {
            _Firing();
        }
        else if (_activeState == State.PullBack)
        {
            _PullBack();
        }
        else if (_activeState == State.ReturnToOrigin)
        {
            _ReturnToOrigin();
        }
    }

    // --- State enters ---

    void enterPatrolling()
    {
        _activeState = State.Patrolling;
        GetComponent<LookAtConstraint>().constraintActive = false;
        GetComponent<AimConstraint>().constraintActive = false;
    }

    void enterChasing()
    {
        _activeState = State.Chasing;
        GetComponent<LookAtConstraint>().constraintActive = true;
        GetComponent<AimConstraint>().constraintActive = false;
        foreach (Transform child in projectileParent.transform)
        {
            child.GetComponent<FireProjectile>().StopFiring();
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
    void enterPullBack()
    {
        _activeState = State.PullBack;
        GetComponent<LookAtConstraint>().constraintActive = false;
        foreach (Transform child in projectileParent.transform)
        {
            child.GetComponent<FireProjectile>().StopFiring();
        }
    }
    void enterReturnToOrigin()
    {
        _activeState = State.ReturnToOrigin;
        GetComponent<AimConstraint>().constraintActive = true;
        foreach (Transform child in projectileParent.transform)
        {
            child.GetComponent<FireProjectile>().StopFiring();
        }
    }

    // --- States ---
    void _Patrolling()
    {
        transform.Translate(Vector3.forward * -baseSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, playerTargetTransform.position) < ChasingDistance)
        {
            enterChasing();
        }
        else if (Vector3.Distance(transform.position, origin.transform.position) > patrolDistance)
        {
            enterReturnToOrigin();
        }
    }
    void _Chasing()
    {
        transform.Translate(Vector3.forward * (-baseSpeed * 1.5f) * Time.deltaTime);
        if (Vector3.Distance(transform.position, playerTargetTransform.position) > ChasingDistance)
        {
            enterPatrolling();
        }
        else if (Vector3.Distance(transform.position, playerTargetTransform.position) < (ChasingDistance - firingMargin))
        {
            enterFiring();
        }
    }
    void _Firing()
    {
        transform.Translate(Vector3.forward * (-baseSpeed * 1.2f) * Time.deltaTime);

        if (Vector3.Distance(transform.position, playerTargetTransform.position) > (ChasingDistance - firingMargin))
        {
            enterChasing();
        }
        else if (Vector3.Distance(transform.position, playerTargetTransform.position) < (PullBackDistance))
        {
            enterPullBack();
        }
    }
    void _PullBack()
    {
        transform.Translate(Vector3.forward * (-baseSpeed * 1.2f) * Time.deltaTime);
        if (Vector3.Distance(transform.position, playerTargetTransform.position) > (ChasingDistance - firingMargin))
        {
            enterChasing();
        }
    }
    void _ReturnToOrigin()
    {
        transform.Translate(Vector3.forward * -baseSpeed * Time.deltaTime);
        // make the pirate return go back to chasing if player comes close to origin again
        if (Vector3.Distance(origin.transform.position, playerTargetTransform.position) < giveUpDistance)
        {
            enterChasing();
        }
        else if (Vector3.Distance(origin.transform.position, transform.position) < patrolDistance)
        {
            enterPatrolling();
        }

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
