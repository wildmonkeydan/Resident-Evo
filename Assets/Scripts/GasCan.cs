using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VehicleBehaviour;

public class GasCan : MonoBehaviour
{
    public AudioClip refuel;

    private WheelVehicle car;
    private float timer;
    private Vector3 initialPos;

    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("Car02").GetComponent<WheelVehicle>();
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        transform.position = transform.position + (Mathf.Sin(Time.time) * Vector3.up * 0.05f * Time.deltaTime);
        transform.eulerAngles += new Vector3(0, 120f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(car != null)
            {
                car.fuel = 1f;
                car.engineSource.PlayOneShot(refuel, 1f);
                Destroy(gameObject);
            }
        }
    }
}
