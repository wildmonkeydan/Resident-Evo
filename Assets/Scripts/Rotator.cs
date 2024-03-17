using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed;
    public Vector3 angle;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(angle * speed * Time.deltaTime); 
    }
}
