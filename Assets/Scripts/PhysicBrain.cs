using System.Collections.Generic;
using UnityEngine;

public class PhysicBrain : MonoBehaviour
{
    public float mass = 1.0f; // kg
    public float gravity = 9.8f;
    public Vector3 velocity; // ms^-1
    public Vector3 netForce;

    private List<Vector3> forceList = new();
    private Vector3 gravityForce;

    private void Start()
    {
        gravityForce = new Vector3(0, -gravity * mass,0); 
    }

    private void FixedUpdate()
    {
        AddForce(gravityForce);

        // summing force

        netForce = Vector3.zero;

        foreach (Vector3 force in forceList)
        {
            netForce += force;
        }

        forceList = new();

        // update velocity

        Vector3 acceleration = netForce / mass;
        velocity += acceleration * Time.deltaTime;

        transform.position += velocity * Time.deltaTime;
    }

    public void AddForce(Vector3 force)
    {
        forceList.Add(force);
    }
}
