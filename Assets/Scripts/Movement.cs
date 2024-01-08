using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    PhysicBrain physic;
    public Vector3 force;
    void Start()
    {
        physic = GetComponent<PhysicBrain>();
    }

    void FixedUpdate()
    {
        physic.AddForce(force);
    }
}
