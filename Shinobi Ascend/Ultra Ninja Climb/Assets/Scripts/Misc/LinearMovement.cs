using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    public float speed;

    Rigidbody2D _rb;

    public bool change;
    public float changeDistance;

    bool _changeAvaileable = true;
    Vector3 _originalPos;

    public List<Transform> targets = new List<Transform>();
    public int _currentTarget;

    private void Start()
    {
        _originalPos = transform.localPosition;
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(!GameManager.instance.paused)
        {
            Move();

            if (change)
            {
                ChangeDirection();
            }
        }
        
    }

    void Move()
    {
        _rb.transform.position = Vector3.Lerp(transform.position, targets[_currentTarget].position, speed * Time.deltaTime);
    }

    void ChangeDirection()
    {
        float auxDist = Vector3.Distance(transform.position, targets[_currentTarget].position);

        if(auxDist <= changeDistance && _changeAvaileable)
        {
            if(_currentTarget < targets.Count -1)
            {
                _currentTarget++;
            }
            else
            {
                _currentTarget = 0;
            }

            _changeAvaileable = false;
            StartCoroutine(EnableChange());
        }
    }

    IEnumerator EnableChange()
    {
        yield return new WaitForSeconds(1);
        _changeAvaileable = true;
    }
}
