using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhysicBrain))]
public class Spring : MonoBehaviour
{
    private PhysicBrain physic;
    public Transform targetPoint;

    public float thickness = 50.0f; // SPRING_CONSTANT N/m

    public Vector3 force;

    private Vector3 equilibrium;

    void Start()
    {
        physic = GetComponent<PhysicBrain>();

        equilibrium = transform.position;
    }

    void FixedUpdate()
    {
        Vector3 springDisplacement = force / thickness;

        physic.AddForce(-springDisplacement);
    }
}
