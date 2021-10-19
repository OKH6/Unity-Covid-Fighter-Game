﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Steering : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    private NavMeshPath path;
    private float elapsed = 0.0f;
    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
        elapsed = 0.0f;
    }

    void Update()
    {
        // Update the way to the goal every second.
        elapsed += Time.deltaTime;
        if (elapsed > 1.0f)
        {
            elapsed -= 1.0f;
            NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);
            Debug.Log(path);
        }
        

        for (int i = 0; i < path.corners.Length - 1; i++)
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
    }
}
