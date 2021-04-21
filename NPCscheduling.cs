using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NPCscheduling : MonoBehaviour
{
    public Transform[] points;
    public Transform[] ConvoPoint;
    private int navPoints = 0;
    private int convoPoint = 0;
    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = points[navPoints].position;
        navPoints = (navPoints + 1) % points.Length;

    }
   
    void Update()
    {
        

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GoToNextPoint();

    }

    void GoToNextPoint()
    {
        if (points.Length == 0)
            return;

        agent.destination = points[navPoints].position;

        navPoints = (navPoints + 1) % points.Length;
    }
}
