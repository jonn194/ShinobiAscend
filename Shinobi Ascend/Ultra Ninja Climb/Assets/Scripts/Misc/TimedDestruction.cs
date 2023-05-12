using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestruction : MonoBehaviour
{
    public float destructionTime;
    
    
    void Update()
    {
        destructionTime -= Time.deltaTime;

        if(destructionTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
