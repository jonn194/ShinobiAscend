using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    public List<GameObject> backgroundObjs = new List<GameObject>();
    public List<Vector3> originalPositions = new List<Vector3>();
    public List<float> speeds = new List<float>();

    public float baseSpeed;

    public float speedOffset;

    public bool move;

    public MainCharacter mC;

    SpriteRenderer[] _spriteRenders;

    public float per;

    private void Start()
    {
        _spriteRenders = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < backgroundObjs.Count; i++)
        {
            float currentTargetSpeed = baseSpeed + (speedOffset * i);
            speeds.Add(currentTargetSpeed);

            originalPositions.Add(backgroundObjs[i].transform.position);
        }
    }

    private void Update()
    {
        if(!GameManager.instance.paused && move)
        {
            MoveBack();

            Recolor();
        }

        if(mC.onWall)
        {
            move = false;
        }
        else
        {
            move = true;
        }
    }

    void MoveBack()
    {
        for (int i = 0; i < backgroundObjs.Count; i++)
        {
            backgroundObjs[i].transform.position += 
                backgroundObjs[i].transform.right * (speeds[i] * mC.movementSpeed.x) * Time.deltaTime; 
        }
    }

    void Recolor()
    {
        Vector3 targetValues = new Vector3(0,0,0);
        int lastScore = 0;
        int nextScore = 0;

        for (int i = 1; i < K.scoreListing.Length; i++)
        {
            if (GameManager.instance.currentScore < K.scoreListing[i])
            {
                targetValues = K.recolors[i];
                lastScore = K.scoreListing[i - 1];
                nextScore = K.scoreListing[i];
                break;
            }
        }

        /*
         highscore-------100
         currentScore-----???
         */

        per = ((GameManager.instance.currentScore - lastScore) * 100) / nextScore;

        float hueAux = Mathf.Lerp(_spriteRenders[0].material.GetFloat("_Hue"), targetValues.x, per/100);

        foreach (SpriteRenderer s in _spriteRenders)
        {
            s.material.SetFloat("_Hue", hueAux);
        }
    }
}
