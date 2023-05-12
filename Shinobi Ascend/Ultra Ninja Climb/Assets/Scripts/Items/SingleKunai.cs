using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleKunai : MonoBehaviour
{
    public float movementSpeed;
    public GameObject target;


    public GameObject kunaiImpact;
    public Kunais k;

    private void Update()
    {
        MoveKunai();
    }

    void MoveKunai()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == K.LAYER_HAZARD || collision.gameObject.layer == K.LAYER_WALL)
        {
            if (collision.gameObject.layer == K.LAYER_HAZARD)
            {
                Destroy(collision.gameObject);
            }

            Instantiate(kunaiImpact, transform.position, Quaternion.identity);
            k.DestroyKunai(this);
        }
    }
}
