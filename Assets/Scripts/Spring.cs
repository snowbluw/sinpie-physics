using UnityEngine;

[RequireComponent(typeof(PhysicBrain))]
public class Spring : MonoBehaviour
{
    private PhysicBrain physic;
    private Dragable touch;
    public Transform targetPoint;

    public float stiffness = 50.0f; // SPRING_CONSTANT N/m

    public Vector3 appliedForce;

    private Vector3 equilibrium;
    private Vector3 restoringForce;
    private Vector3 displacementX;

    void Start()
    {
        physic = GetComponent<PhysicBrain>();
        touch = GetComponent<Dragable>();

        equilibrium = transform.position;
    }

    void FixedUpdate()
    {

        if (touch.IsTouched)
        {
            physic.velocity = Vector3.zero;
            displacementX = transform.position - equilibrium;
            appliedForce = (stiffness * displacementX);

            physic.AddForce(appliedForce);
        }
        else
        {
            appliedForce = Vector3.zero;
        }

        restoringForce = -(stiffness * displacementX);
        physic.AddForce(restoringForce);
    }
}
