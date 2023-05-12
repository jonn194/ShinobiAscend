using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericRotation : MonoBehaviour
{
    public Vector3 rotationVelocity;

    void Update()
    {
        if(!GameManager.instance.paused)
        {
            Rotation();
        }
        
    }

    void Rotation()
    {
        transform.Rotate(rotationVelocity);
    }
}
