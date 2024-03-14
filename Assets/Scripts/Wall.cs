using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VehicleBehaviour;

public class Wall : MonoBehaviour
{
    public Mesh broke;
    public AudioClip brokeClip;
    public int clearance = 0; 
    public GameObject block;
    
    private TextMeshProUGUI hintText; 
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
        hintText = GameObject.Find("HintText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (other.gameObject.GetComponent<Keyring>().clearance >= clearance)
            {
                mf.mesh = broke;
                mr.materials[1] = mr.material;
                asource.PlayOneShot(brokeClip);
                Destroy(box);
                Destroy(block);
            }
            else
            {
                hintText.text = "You need a " + (clearance == 1 ? "blue" : "red") + " bumper";
                Invoke("ResetHint", 4f);
            }
        }
    }

    void ResetHint()
    {
        hintText.text = "";
    }
}
