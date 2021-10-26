using UnityEngine;
using UnityEngine.AI;

public class WayPointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;

    int m_CurrentWaypointsIndex;

    // Start is called before the first frame update
    void Start()
    {

        navMeshAgent.SetDestination(waypoints[0].position);
        
    }

    // Update is called once per frame
    void Update()
    {

        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {

            m_CurrentWaypointsIndex = (m_CurrentWaypointsIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointsIndex].position);

        }
        
    }

}
