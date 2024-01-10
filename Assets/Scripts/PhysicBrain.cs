using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PhysicBrain : MonoBehaviour
{
    public float mass = 1.0f; // kg
    public float gravity = 9.8f;
    public Vector3 velocity; // ms^-1
    public Vector3 netForce;

    private List<Vector3> forceList = new();
    private PhysicBrain[] physicObjects;

    private const float BIG_G = 6.673e-11f;

    private void Awake()
    {
        physicObjects = FindObjectsOfType<PhysicBrain>();
    }

    private void FixedUpdate()
    {
        foreach (PhysicBrain physicObject in physicObjects)
        {
            if (physicObject != this)
            {
                Vector3 offset = this.transform.position - physicObject.transform.position;
                float rSquared = Mathf.Pow(offset.magnitude, 2f);
                float gravityMagnitude = BIG_G * this.mass * physicObject.mass / rSquared;
                Vector3 gravityFall = gravityMagnitude * offset.normalized;

                this.AddForce(-gravityFall);
            }
        }
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
