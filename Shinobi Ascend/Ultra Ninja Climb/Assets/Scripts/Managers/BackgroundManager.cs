using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public MainCharacter mainChar;
    AreasManager _areasMan;

    public GameObject orginalBackground;

    Transform _generationPos;
    Transform _destructionPos;

    public List<GameObject> possibleBackgrounds;
    public List<GameObject> spawnedBackgrounds;

    Vector3 _originalPos;

    void Start()
    {
        _areasMan = GetComponent<AreasManager>();
        _generationPos = _areasMan.generationPos;
        _destructionPos = _areasMan.destructionPos;

        _originalPos = spawnedBackgrounds[0].transform.position;
    }

    void Update()
    {
        if (!GameManager.instance.paused)
        {
            MoveBack();

            if (spawnedBackgrounds[0].transform.position.y <= _destructionPos.position.y/3)
            {
                GenerateBackground();
                DestroyBackground();
            }
        }
    }

    void MoveBack()
    {
        float refSpeed = _areasMan.spawnedAreas[0].GetComponent<Rigidbody2D>().velocity.y;

        foreach (GameObject b in spawnedBackgrounds)
        {
            b.transform.position += new Vector3(0, refSpeed / 400, 0);
        }
    }

    void GenerateBackground()
    {
        int randomIndex = Random.Range(0, possibleBackgrounds.Count);

        GameObject newBack = Instantiate(possibleBackgrounds[randomIndex], _generationPos.position/2, Quaternion.identity);
        newBack.GetComponent<BackgroundParallax>().mC = mainChar;
        spawnedBackgrounds.Add(newBack);
    }

    void DestroyBackground()
    {
        GameObject oldBack = spawnedBackgrounds[0];

        spawnedBackgrounds.Remove(spawnedBackgrounds[0]);
        Destroy(oldBack.gameObject);
    }


    public void ResetBack()
    {
        foreach (GameObject b in spawnedBackgrounds)
        {
            Destroy(b.gameObject);
        }

        spawnedBackgrounds.Clear();

        GameObject newBack = Instantiate(orginalBackground, _originalPos, Quaternion.identity);
        newBack.GetComponent<BackgroundParallax>().mC = mainChar;
        spawnedBackgrounds.Add(newBack);
    }
}
