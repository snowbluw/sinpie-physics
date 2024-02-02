using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PhysicBrain : MonoBehaviour
{
    public float mass = 1.0f;
    public Vector3 velocity;
    public Vector3 netForce;
    private BoxCollider bx;

    private List<Vector3> forces = new();
    private List<PhysicBrain> physicObjects = new();

    #region Gravity
    private const float BIG_G = 6.673e-11f;

    public bool useGravity = true;
    public enum GravityMode { Realistic, GoDown }
    public GravityMode gravityMode;
    public float gravity = 9.8f;
    #endregion

    public float Mass { get { return mass; } set { mass = value; } }

    private void Update()
    {
        physicObjects = FindObjectsOfType<PhysicBrain>().ToList();
    }

    private void FixedUpdate()
    {
        // calculate gravity
        CalculateGravity(gravityMode);

        // summing force
        netForce = Vector3.zero;

        foreach (Vector3 force in forces)
        {
            netForce += force;
        }

        forces.Clear();

        // update velocity
        Vector3 acceleration = netForce / mass;
        velocity += acceleration * Time.deltaTime;

        transform.position += velocity * Time.deltaTime;
    }

    private void CalculateGravity(GravityMode mode)
    {
        if (!useGravity) { return; }

        if (gravityMode == GravityMode.Realistic)
        {
            foreach (PhysicBrain physicObject in physicObjects)
            {
                if (physicObject != this)
                {
                    Vector3 offset = this.transform.position - physicObject.transform.position;
                    float rSquared = Mathf.Pow(offset.magnitude, 2f);
                    float gravityMagnitude = BIG_G * this.mass * physicObject.mass / rSquared;
                    Vector3 gravityForceReal = gravityMagnitude * offset.normalized;

                    this.AddForce(-gravityForceReal); //gravity force
                }
            }
        }
        else
        {
            Vector3 gravityForceGoDown = new (0, gravity * mass, 0);
            AddForce(-gravityForceGoDown);
        }
    }

    public void AddForce(Vector3 force)
    {
        forces.Add(force);
    }


}
