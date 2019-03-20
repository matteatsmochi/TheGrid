using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startPath : MonoBehaviour
{
    private DrawPath drawPath;
    void Start()
    {
        drawPath = GetComponentInParent<DrawPath>();
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "front")
        {
            //Debug.Log(c.name);
            drawPath.StartLine();
        }
    }
}
