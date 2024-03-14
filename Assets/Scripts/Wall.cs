using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Mesh broke;
    public AudioClip brokeClip;

    private BoxCollider box;
    private MeshFilter mf;
    private MeshRenderer mr;
    private AudioSource asource;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider>();
        mf = GetComponent<MeshFilter>();
        mr = GetComponent<MeshRenderer>();
        asource = GetComponent<AudioSource>();
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
            asource.PlayOneShot(brokeClip);
            Destroy(box);
        }
    }
}
