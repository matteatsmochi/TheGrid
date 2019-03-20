using System.Collections;
using UnityEngine;

public class gizmoWireSphere : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, 0.2f);
    }
}
