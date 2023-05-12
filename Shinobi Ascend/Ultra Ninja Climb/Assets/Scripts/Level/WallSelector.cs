using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSelector : MonoBehaviour
{
    public List<Sprite> allSprites = new List<Sprite>();

    SpriteRenderer[] _spriteRenders;

    void Start()
    {
        _spriteRenders = GetComponentsInChildren<SpriteRenderer>();

        foreach(SpriteRenderer s in _spriteRenders)
        {
            int auxIndex = Random.Range(0, allSprites.Count);

            s.sprite = allSprites[auxIndex];
        }

        DificultyRecolor();
    }

    void DificultyRecolor()
    {
        HazardSpawner hazardS = GetComponentInParent<HazardSpawner>();

        if(hazardS != null && hazardS.maxSpawned > 0)
        {
            Recolor(K.recolors[hazardS.maxSpawned - 1]);
        }
    }

    void Recolor(Vector3 values)
    {
        foreach (SpriteRenderer s in _spriteRenders)
        {
            s.material.SetFloat("_Hue", values.x);
            s.material.SetFloat("_Saturation", values.y);
            s.material.SetFloat("_Value", values.z);
        }
    }
}
