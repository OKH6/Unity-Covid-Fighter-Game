using UnityEngine;
using UnityEngine.AI;


public class CarsMovement : MonoBehaviour
{
    public GameObject point;
    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        point = GameObject.FindGameObjectWithTag("CarDestination");

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    public void GotoNextPoint()
    {
        if (agent.isOnNavMesh)
        {
            agent.destination = point.transform.position;
        }

        
    }


    void Update()
    {
        if ((point.transform.position.x - 5 <= transform.position.x) & (transform.position.x <= point.transform.position.x+5) & (point.transform.position.z - 5 <= transform.position.z) & (transform.position.z <= point.transform.position.z + 5))
        {
            Destroy(gameObject);
        }
        
    }
}
