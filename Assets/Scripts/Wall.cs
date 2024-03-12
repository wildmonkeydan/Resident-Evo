using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Mesh broke;

    private BoxCollider box;
    private MeshFilter mr;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider>();
        mr = GetComponent<MeshFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            mr.mesh = broke;
            Destroy(box);
        }
    }
}
