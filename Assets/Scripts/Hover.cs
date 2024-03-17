using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public float moveAmount;
    public Vector3 moveVector;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Mathf.Sin(Time.time) * moveVector * moveAmount * Time.deltaTime);
    }
}
