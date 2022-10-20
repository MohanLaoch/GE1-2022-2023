using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AITank : MonoBehaviour {

    public float radius = 10;
    public int numWaypoints = 5;
    public int current = 0;
    List<Vector3> waypoints = new List<Vector3>();
    public float speed = 10;
    public Transform player;    

    public void OnDrawGizmos()
    {
        // Task 1
        // Put code here to draw the gizmos
        // Use sin and cos to calculate the positions of the waypoints 
        // You can draw gizmos using
        // Gizmos.color = Color.green;
        // Gizmos.DrawWireSphere(pos, 1);

        if (!Application.isPlaying)
        {
            float circumference = (Mathf.PI * 2.0f) / numWaypoints;

            for (int i = 0; i < numWaypoints; i++)
            {
                float waypointPosition = i * circumference;
                Vector3 position = new Vector3(Mathf.Sin(waypointPosition) * radius, 0, Mathf.Cos(waypointPosition) * radius);
                position = transform.TransformPoint(position);
                Gizmos.color = Color.cyan;
                Gizmos.DrawWireSphere(position, 1);
            }
        }
    }

    // Use this for initialization
    void Awake () 
    {
        // Task 2
        // Put code here to calculate the waypoints in a loop and 
        // Add them to the waypoints List

        float circumference = (Mathf.PI * 2.0f) / numWaypoints;

        for (int i = 0; i < numWaypoints; i++)
        {
            float waypointPosition = i * circumference;
            Vector3 position = new Vector3(Mathf.Sin(waypointPosition) * radius, 0, Mathf.Cos(waypointPosition) * radius);
            position = transform.TransformPoint(position);
            waypoints.Add(position);
        }
    }

    // Update is called once per frame
    void Update () 
    {
        // Task 3
        // Put code here to move the tank towards the next waypoint
        // When the tank reaches a waypoint you should advance to the next one

        Vector3 travelPoint = waypoints[current] - transform.position;
        if (travelPoint.magnitude < 1)
        {
            current = (current + 1) % waypoints.Count;
        }
        travelPoint.Normalize();
        transform.Translate(travelPoint * speed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(travelPoint), Time.deltaTime * 5);

        // Task 4
        // Put code here to check if the player is in front of or behine the tank

        Vector3 distanceToPlayer = player.position - transform.position;

        if (Vector3.Dot (transform.forward, distanceToPlayer) > 0)
        {
            Debug.Log("Player is infront");
        }
        else
        {
            Debug.Log("Player is behind");
        }

        // Task 5
        // Put code here to calculate if the player is inside the field of view and in range
        // You can print stuff to the screen using:
        GameManager.Log("Hello from the AI tank");

        float view = Mathf.Acos(Vector3.Dot(transform.forward, distanceToPlayer) / distanceToPlayer.magnitude) * Mathf.Rad2Deg;

        if (view < 45)
        {
            Debug.Log("Player is inside the view");
        }
        else
        {
            Debug.Log("Player is not inside the view");
        }

    }
}
