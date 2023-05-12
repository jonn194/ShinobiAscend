using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardAnimations : MonoBehaviour
{
    public Animator anim;

    public float timeToAction;
    float _currentTimeToAction;

    public bool timed;

    private void Start()
    {
        _currentTimeToAction = timeToAction;
    }

    private void Update()
    {
        if(!GameManager.instance.paused)
        {
            if (timed)
            {
                _currentTimeToAction -= Time.deltaTime;

                if (_currentTimeToAction <= 0)
                {
                    _currentTimeToAction = timeToAction;
                    Animate();
                }
            }


            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                anim.SetBool("action", false);
            }
        }
        
    }

    public void Animate()
    {
        anim.SetBool("action", true);
    }
}
