using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VehicleBehaviour;

public class LabEquipment : MonoBehaviour
{
    public AudioClip destroy;
    private ObjectiveManager manager;
    private WheelVehicle car;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindFirstObjectByType<ObjectiveManager>();
        car = GameObject.Find("Car02").GetComponent<WheelVehicle>();
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
            car.engineSource.PlayOneShot(destroy, 0.5f);
            Destroy(gameObject);
        }
    }
}
