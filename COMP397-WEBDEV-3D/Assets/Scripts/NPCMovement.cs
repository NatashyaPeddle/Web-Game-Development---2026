using KBCore.Refs;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(NavMeshAgent))]

public class NPCMovement : MonoBehaviour
{
    [SerializeField, Self] private NavMeshAgent agent;
    [SerializeField] private List<GameObject> waypoints = new List<GameObject>();
    private Vector3 destination;
    private int index;

    private void OnValidate() => this.ValidateRefs();///assigns propert component
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint").ToList();
        if (waypoints.Count < 0) return; //if theres no waypoints
        agent.destination = destination = waypoints[index].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Count < 0) return; //if theres no waypoints
        if (Vector3.Distance(transform.position, destination) < 1f)
        {
            index= (index + 1) % waypoints.Count;
            destination = waypoints[index].transform.position;
            agent.destination = destination;
        }


    }
}
