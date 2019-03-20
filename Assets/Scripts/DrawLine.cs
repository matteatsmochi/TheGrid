using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public float counter;
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
        //testing to make sure all the waypoints can be drawn. Works!
        //if(drawing) {
        //    lineRenderer.SetPosition(0, waypoints[0]);
        //    for(int i = 0; i < waypoints.Count; i++) {
        //        lineRenderer.positionCount++;
        //        Vector3 p = waypoints[i];
        //        lineRenderer.SetPosition(i, p);
        //    }
        //}
        //return;

        if (drawing)
        {
            counter += (lineDrawSpeed) * Time.deltaTime;

            if(counter <= dist)
            {   //counter starts at 0, so this is block is evaluated right off the start
                lineRenderer.SetPosition(currentWaypoint+1, Vector3.Lerp(waypoints[currentWaypoint], waypoints[currentWaypoint + 1], counter/dist)); //lerp works on [0,1], counter is [0,dist] so you have to normalize it
                //currentWaypoint+1, we offset by 1 because you already have currentWaypoint (0) set on the first iteration

                front.transform.position = waypoints[currentWaypoint + 1];

            } 
            else
            {
                if(waypoints.Count > lineRenderer.positionCount) 
                {
                    NextWaypoint();
                    counter = 0;
                    dist = Vector3.Distance(waypoints[currentWaypoint], waypoints[currentWaypoint + 1]);
                } 
                else 
                {
                    drawing = false;
                }
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

            lineRenderer.positionCount = 1;             //setting the first waypoint immediately once we know where the waypoints are
            lineRenderer.SetPosition(0, waypoints[0]);
            lineRenderer.positionCount++;
            dist = Vector3.Distance(waypoints[0], waypoints[1]);
            drawing = true;
            populated = true;


        }

    }

    void NextWaypoint()
    {
        lineRenderer.positionCount++;

        currentWaypoint++;
        front.transform.position = waypoints[currentWaypoint];


        if(currentWaypoint == 0)
        {
            lineRenderer.SetPosition(currentWaypoint+1, waypoints[0]);
        }
        else
        {
            lineRenderer.SetPosition(currentWaypoint+1, waypoints[currentWaypoint - 1]);
        }
    }
}
