using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringVisual : MonoBehaviour
{
    private LineRenderer line;
    public Transform pointA,pointB;
    public Transform springView;

    private Vector3[] positions = new Vector3[2];

    void Start()
    {
        gameObject.AddComponent<LineRenderer>();

        line = GetComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.startWidth = 0.2f;
        line.endWidth = 0.2f;
        line.loop = true;

    }

    // Update is called once per frame
    void Update()
    {
        positions[0] = pointA.position;
        positions[1] = pointB.position;
        line.positionCount = positions.Length;
        line.SetPositions(positions);
    }
}
