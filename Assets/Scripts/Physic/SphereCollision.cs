using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SphereCollision : MonoBehaviour
{
    private List<GameObject> objs = new();

    void Start()
    {
        objs = FindObjectsOfType<GameObject>().ToList();
    }

    void FixedUpdate()
    {
        foreach (GameObject obj in objs)
        {
            if (obj != this.gameObject)
            {
                Debug.Log("Detect Collision");
            }
        }
    }
}
