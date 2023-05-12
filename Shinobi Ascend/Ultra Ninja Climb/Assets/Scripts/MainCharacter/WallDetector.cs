using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    public Follower scorePoint;

    public bool stopped;
    public bool wall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == K.LAYER_FLOOR)
        {
            stopped = true;
            wall = false;
        }
        else if (collision.gameObject.layer == K.LAYER_WALL)
        {
            stopped = true;
            wall = true;

            if(scorePoint.transform.position.y < transform.position.y)
            {
                scorePoint.transform.position = transform.position;
                scorePoint.offset = new Vector3(0, transform.position.y, 0) - collision.gameObject.transform.position;
                scorePoint.target = collision.gameObject.transform;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == K.LAYER_FLOOR || collision.gameObject.layer == K.LAYER_WALL)
        {
            stopped = false;
            wall = false;
        }
    }
}
