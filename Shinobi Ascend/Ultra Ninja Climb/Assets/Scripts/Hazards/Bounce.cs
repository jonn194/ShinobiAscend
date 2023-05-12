using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public Vector2 backstepDirection;

    public HazardAnimations animations;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!GameManager.instance.paused)
        {
            if (other.gameObject.layer == K.LAYER_MAINCHAR)
            {
                if(animations != null)
                {
                    animations.Animate();
                }
                

                MainCharacter mC = other.GetComponent<MainCharacter>();

                mC.StopCharacter();

                if (transform.rotation.y == 0)
                {
                    mC.MoveCharacter(backstepDirection);
                }
                else
                {
                    mC.MoveCharacter(-backstepDirection);
                }

                if (mC.transform.rotation.y != transform.rotation.y)
                {
                    mC.CharacterFlip();
                }
            }
        }
    }
}
