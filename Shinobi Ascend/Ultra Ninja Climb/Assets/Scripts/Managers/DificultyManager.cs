using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DificultyManager : MonoBehaviour
{
    AreasManager _areasMan;

    int _lastSavedScore;
    int _offset = 1000;
    int _savedOffset;

    void Start()
    {
        _areasMan = GetComponent<AreasManager>();
        _savedOffset = _offset;
    }

    
    void Update()
    {
        if(GameManager.instance.currentScore == _lastSavedScore + _offset)
        {
            _lastSavedScore = GameManager.instance.currentScore;
            _offset += _offset/4;

            if(_areasMan.currentMaxArea < _areasMan.allAreas.Count-1)
            {
                _areasMan.currentMaxArea++;
            }

            _areasMan.currentMaxTraps++;
            _areasMan.trapsAmount++;
        }
    }

    public void ResetDificulty()
    {
        _lastSavedScore = 0;
        _offset = _savedOffset;
    }
}
