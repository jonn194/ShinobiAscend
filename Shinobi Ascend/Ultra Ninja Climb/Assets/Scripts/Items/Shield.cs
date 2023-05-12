using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject shield;
    public ParticleSystem impactParticles;

    private void FixedUpdate()
    {
        if(GameManager.instance.hasShield)
        {
            ActivateShield();
        }
    }

    public void ActivateShield()
    {
        shield.SetActive(true);
    }

    public void DestroyShield()
    {
        shield.SetActive(false);
        impactParticles.Play();
    }
}
