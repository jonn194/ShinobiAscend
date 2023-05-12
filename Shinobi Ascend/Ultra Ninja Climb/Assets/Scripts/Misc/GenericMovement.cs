using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericMovement : MonoBehaviour
{
    public float speed;

    Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(!GameManager.instance.paused)
        {
            Move();
        }
    }

    void Move()
    {
        _rb.transform.position += transform.right * speed * Time.deltaTime;
    }
}
