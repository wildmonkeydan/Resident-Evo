using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabEquipment : MonoBehaviour
{
    private ObjectiveManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindFirstObjectByType<ObjectiveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            manager.BreakEquipment();
            Destroy(gameObject);
        }
    }
}
