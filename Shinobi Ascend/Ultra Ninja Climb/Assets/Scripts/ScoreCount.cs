using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public MainCharacter mC;

    public Transform lastHighPos;

        
    void Update()
    {
        if(!GameManager.instance.paused)
        {
            if (mC.transform.position.y > lastHighPos.position.y && !mC.wallDetect.stopped)
            {
                float dist = mC.transform.position.y - lastHighPos.position.y;
                float savedDist = 0;

                if(savedDist < dist)
                {
                    savedDist = dist;
                }

                if (mC.movementSpeed.y > 0)
                {
                    GameManager.instance.currentScore += (int)dist;
                }
                
            }
        }
    }


    public void ResetCounter()
    {
        lastHighPos.GetComponent<Follower>().target = null;
        lastHighPos.position = new Vector3(0,-5,0);
    }
}
