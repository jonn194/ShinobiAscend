using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharAnimatorCtrl : MonoBehaviour
{
    public Animator anim;

    public void OnFloor(bool value)
    {
        anim.SetBool("onFloor", value);
    }

    public void OnWall(bool value)
    {
        anim.SetBool("onWall", value);
    }

    public void Jumping(bool value)
    {
        anim.SetBool("jumping", value);
    }

    public void Damaged(bool value)
    {
        anim.SetBool("damaged", value);
    }
}
