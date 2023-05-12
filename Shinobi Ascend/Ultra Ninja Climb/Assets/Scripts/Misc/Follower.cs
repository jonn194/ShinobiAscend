using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    void Update()
    {
        if(target !=null)
        {
            transform.position = new Vector3(transform.position.x, target.position.y + offset.y, transform.position.z);
        }
    }
}
