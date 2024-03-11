using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    public float delay = 5f;

    // Start is called before the first frame update
    void Awake()
    {
        Invoke("Die", delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
