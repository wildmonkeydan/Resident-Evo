using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Mesh broke;

    private BoxCollider box;
    private MeshFilter mf;
    private MeshRenderer mr;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider>();
        mf = GetComponent<MeshFilter>();
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            mf.mesh = broke;
            mr.materials[1] = mr.material;
            Destroy(box);
        }
    }
}
