using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VehicleBehaviour;

public class Bumbper : MonoBehaviour
{
    public int newClearance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Mathf.Sin(Time.time) * Vector3.up * 0.05f * Time.deltaTime);
        transform.eulerAngles += new Vector3(0, 120f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            other.gameObject.GetComponent<Keyring>().clearance = newClearance;
            Destroy(gameObject);
        }
    }
}
