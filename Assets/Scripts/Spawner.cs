using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obj;
    public int size;
    void Start()
    {
        for (int i = 0; i < size; i++)
        {
            Instantiate(obj, new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-3.0f, 3.0f), Random.Range(-5.0f, 5.0f)), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
