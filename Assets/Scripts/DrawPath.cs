using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPath : MonoBehaviour
{
    private DrawLine drawLine;

    public List<Transform> waypoints;
    
    void Awake()
    {
        drawLine = GetComponentInChildren<DrawLine>();
    }

    void Start()
    {
        drawLine.front.gameObject.SetActive(true);
        drawLine.front.transform.position = new Vector3(waypoints[0].position.x, waypoints[0].position.y + 10, waypoints[0].position.z);
        
        drawLine.start.gameObject.SetActive(true);
        drawLine.start.transform.position = waypoints[0].position;
    }

    public void StartLine()
    {
        drawLine.PopulateWaypoints(waypoints);
    }

    
    
}
