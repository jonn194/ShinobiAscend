using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteEmpty : MonoBehaviour
{
    private void FixedUpdate()
    {
        if(transform.childCount == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
