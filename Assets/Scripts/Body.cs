using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public Vector3 velocityVector; //average velocity

    void FixedUpdate()
    {
        transform.position += velocityVector * Time.fixedDeltaTime;
    }
}
