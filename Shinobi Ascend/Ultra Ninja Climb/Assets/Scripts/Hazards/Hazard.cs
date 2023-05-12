using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public bool hasDamage;

    public Vector2 backstepDirection;
    public bool destroyable;

    public GameObject destructionParticle;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!GameManager.instance.paused)
        {
            if (other.gameObject.layer == K.LAYER_MAINCHAR && hasDamage)
            {
                MainCharacter mC = other.GetComponent<MainCharacter>();

                if (!mC.damaged)
                {
                    mC.TakeDamage(transform.rotation.y, backstepDirection, !destroyable);
                }

                if (destroyable)
                {
                    Destruction();
                }

            }
            else if (other.gameObject.layer == K.LAYER_WALL && destroyable)
            {
                Destruction();
            }
        }
    }

    public void Destruction()
    {
        Instantiate(destructionParticle, transform.position, Quaternion.identity, transform.parent);

        Destroy(this.gameObject);
    }
}
