using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using VehicleBehaviour;

public class Zombie : MonoBehaviour
{
    public float walkRadius = 50f;
    public GameObject blood;

    private NavMeshAgent agent;
    private Overseer overseer;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        overseer = FindFirstObjectByType<VehicleBehaviour.Overseer>();

        FindNewPosition();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = agent.remainingDistance; 
        if (dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0)
        {
            FindNewPosition();
        }
    }

    void FindNewPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;

        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
        Vector3 finalPosition = hit.position;

        agent.SetDestination(finalPosition);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            overseer.score += 100;
            Destroy(gameObject);
        }
    }
}
