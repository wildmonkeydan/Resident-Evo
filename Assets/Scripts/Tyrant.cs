using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using VehicleBehaviour;

public class Tyrant : MonoBehaviour
{
    public GameObject blood;

    private WheelVehicle car;
    private NavMeshAgent agent;
    private int health = 100;
    private Overseer overseer;
    private ObjectiveManager objectiveManager;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        car = GameObject.Find("Car02").GetComponent<WheelVehicle>();
        overseer = FindFirstObjectByType<Overseer>();
        objectiveManager = FindFirstObjectByType<ObjectiveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(car.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            health -= (int)collision.impulse.magnitude / 100;

            Debug.Log(health);

            if (health < 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    Instantiate(blood, transform.position, Quaternion.identity);
                }

                car.fuel = 1f;
                overseer.score += 1000;
                objectiveManager.ChangeObjective(3);
                Destroy(gameObject);
            }
        }
    }
}
