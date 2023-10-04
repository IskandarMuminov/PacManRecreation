using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private MoveableObj obj;
    [SerializeField] private Vector2 movement;
    [SerializeField] private Animator animator;

    private Vector3[] waypoints;
    private int currentWaypointIndex = 0;

    void Start()
    {
        waypoints = new Vector3[]
        {
            new Vector3(-3.5f, -0.5f, 0),
            new Vector3(-3.5f, 3.5f, 0),
            new Vector3(7.5f, 3.5f, 0),
            new Vector3(7.5f, -0.45f, 0)
        };

        MoveToNextWaypoint();
    }

    private void Update()
    {
        if (currentWaypointIndex >= waypoints.Length)
        {
            return; 
        }

        Vector3 currentWaypoint = waypoints[currentWaypointIndex];
        Vector3 currentPosition = obj.transform.position;

        Vector3 movementDirection = (currentWaypoint - currentPosition).normalized;

        
        animator.SetFloat("Horizontal", movementDirection.x);
        animator.SetFloat("Vertical", movementDirection.y);
    }

    private void MoveToNextWaypoint()
    {
        if (waypoints.Length == 0)
        {
            return;
        }

        Vector3 nextWaypoint = waypoints[currentWaypointIndex];
        obj.MoveTo(nextWaypoint, () =>
        {
            currentWaypointIndex++;

            
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }

            MoveToNextWaypoint();
        });
    }
}
