using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileAnimation : MonoBehaviour
{
    public Vector2 minMaxInRow;

    public Vector2 currentTile;

    public float changeTime;
    float _currentTime;


    public enum spriteType
    {
        sprite,
        line,
        particle
    }

    public spriteType spriteT;

    Material _mat;

    void Start()
    {
        _currentTime = changeTime;

        if(spriteT == spriteType.sprite)
        {
            _mat = GetComponent<SpriteRenderer>().materials[0];
        }
        else if (spriteT == spriteType.line)
        {
            _mat = GetComponent<LineRenderer>().materials[0];
        }
        else if (spriteT == spriteType.line)
        {
            _mat = GetComponent<LineRenderer>().materials[0];
        }
    }

    
    void Update()
    {
        _currentTime -= Time.deltaTime;

        if(_currentTime <= 0)
        {
            _currentTime = changeTime;

            if(currentTile.y < minMaxInRow.y)
            {
                currentTile.y += 1;
            }
            else
            {
                currentTile.y = minMaxInRow.x;
            }
        }

        _mat.SetVector("_Position", new Vector4(currentTile.x,currentTile.y,0,0));
    }
}
