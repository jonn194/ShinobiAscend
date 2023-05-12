using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSpawner : MonoBehaviour
{
    public GameObject originalObj;
    public Transform transformation;

    public bool timed;

    public float spawnTime;
    float _currentTime;

    public Transform target;

    AudioExecution _aExecution;

    void Start()
    {
        _currentTime = spawnTime;

        _aExecution = GetComponent<AudioExecution>();
    }

    
    void Update()
    {
        if(!GameManager.instance.paused)
        {
            if(timed)
            {
                _currentTime -= Time.deltaTime;

                if (_currentTime <= 0)
                {
                    _currentTime = spawnTime;

                    Spawn();
                }
            }
            
        }
    }

    public GameObject Spawn()
    {
        GameObject newObj = Instantiate(originalObj, transformation.position, transform.rotation, transformation);
       

        if(transformation != null)
        {
            newObj.transform.position = transformation.position;
            newObj.transform.rotation = transformation.rotation;
        }

        if(_aExecution != null)
        {
            _aExecution.PlayAudio();
        }

        return newObj;
    }
}
