using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCController : MonoBehaviour
{
    public Transform targetTR;
    NavMeshAgent nav;
    


    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        nav.SetDestination(targetTR.position);
    }
}
