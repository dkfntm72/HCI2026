using UnityEngine;
using UnityEngine.AI;

public class ZonbieController : MonoBehaviour
{
    public GameObject destinationFolder;
    Transform[] destinations;
    int destinationIndex;
    NavMeshAgent nav;
    bool isArrived = false;
    float minDistanse = 1f;

    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        destinations = destinationFolder.GetComponentsInChildren<Transform>();
        destinationIndex = Random.Range(1, destinations.Length);
    }
    private void Update()
    {
        if (Arrived())
        {
            destinationIndex = Random.Range(1, destinations.Length);
        }
        nav.SetDestination(destinations[destinationIndex].position); 
    }
    bool Arrived()
    {
        if (Vector3.Distance(transform.position, destinations[destinationIndex].position) < minDistanse)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
