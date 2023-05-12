using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampantDeath : MonoBehaviour
{
    public MainCharacter mainChar;
    public AreasManager areasMan;

    Rigidbody2D _rb;

    public float riseSpeed;

    Vector3 _originalPos;

    private void Start()
    {
        _originalPos = transform.position;

        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!GameManager.instance.paused)
        {
            if (mainChar.wallDetect.stopped)
            {
                MoveUp();
            }
            else
            {
                _rb.bodyType = RigidbodyType2D.Dynamic;
                _rb.velocity = areasMan.spawnedAreas[0].GetComponent<Rigidbody2D>().velocity;
            }

            if(_rb.transform.position.y <= _originalPos.y)
            {
                _rb.transform.position = _originalPos;
                _rb.bodyType = RigidbodyType2D.Kinematic;
            }
        }
        else
        {
            _rb.transform.position = _originalPos;
            _rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    void MoveUp()
    {
        _rb.bodyType = RigidbodyType2D.Kinematic;
        _rb.velocity = Vector2.zero;
        _rb.transform.position += _rb.transform.up * riseSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == K.LAYER_MAINCHAR)
        {
            mainChar.InstantDeath();
        }
    }

    public void Reset()
    {
        transform.position = _originalPos;
    }
}
