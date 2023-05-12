using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosTool : MonoBehaviour
{
    public Color color;

    public GizmoType gizmoType;

    public Vector3 dimensions;
    public Vector3 offset;

    public enum GizmoType
    {
        lineUp,
        lineSide,
        box,
        sphere
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = color;


        if (gizmoType == GizmoType.lineUp)
        {
            Gizmos.DrawLine(transform.position + offset, transform.up * dimensions.x + transform.position);
        }
        else if (gizmoType == GizmoType.lineSide)
        {
            Gizmos.DrawLine(transform.position + offset, transform.right * dimensions.x + transform.position);
        }
        else if (gizmoType == GizmoType.box)
        {
            Gizmos.DrawWireCube(transform.position + offset, dimensions); 
        }
        else if(gizmoType == GizmoType.sphere)
        {
            Gizmos.DrawWireSphere(transform.position + offset, dimensions.x);
        }
    }
}
