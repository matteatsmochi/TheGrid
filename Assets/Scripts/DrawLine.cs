using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private float counter;
    private float dist;
    private int currentWaypoint = 0;
    private bool drawing;
    private bool populated;
    public List<Vector3> waypoints;

    public GameObject front;
    public GameObject start;
    public float lineDrawSpeed = 1f;

    void Awake()
    {
        drawing = false;
        lineRenderer = GetComponent<LineRenderer>();
        
        lineRenderer.startWidth = 0.15f;
        lineRenderer.endWidth = 0.15f;
    }

    

    void Update()
    {
        if (drawing)
        {
            if (counter <= dist)
            {
                counter += (lineDrawSpeed) * Time.deltaTime;
                lineRenderer.SetPosition(currentWaypoint, Vector3.Lerp(waypoints[currentWaypoint], waypoints[currentWaypoint + 1], counter));
                front.transform.position = waypoints[currentWaypoint + 1];
            }
            else
            {
                if (waypoints.Count > lineRenderer.positionCount + 1)
                {
                    NextWaypoint();
                    counter = 0;
                    dist = Vector3.Distance(waypoints[currentWaypoint], waypoints[currentWaypoint + 1]);
                }
                    else drawing = false;
            }
        }
        
    }

    public void PopulateWaypoints(List<Transform> wp)
    {
        if (!populated)
        {
            for (int i = 0; i < wp.Count; i++)
            {
                waypoints.Add(wp[i].position);
            }

            lineRenderer.positionCount = 1;
            lineRenderer.SetPosition(0, waypoints[0]);
            dist = Vector3.Distance(waypoints[0], waypoints[1]);
            drawing = true;
            populated = true;
        }

    }

    void NextWaypoint()
    {
        lineRenderer.positionCount++;

        currentWaypoint++;
        
        if (currentWaypoint == 0)
        {
            lineRenderer.SetPosition(currentWaypoint, waypoints[0]);
        }
        else
        {
            lineRenderer.SetPosition(currentWaypoint, waypoints[currentWaypoint - 1]);
        }
    }
}
