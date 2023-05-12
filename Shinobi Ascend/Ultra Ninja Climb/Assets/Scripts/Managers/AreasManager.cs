using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreasManager : MonoBehaviour
{
    public MainCharacter mainChar;

    public Transform generationPos;
    public Transform destructionPos;

    public int currentMaxArea;

    public int currentMaxTraps;
    public int trapsAmount;

    public List<GameObject> allAreas = new List<GameObject>();
    public List<LevelArea> spawnedAreas = new List<LevelArea>();

    public GameObject initialSetup;

    ScoreCount _scoreC;

    public bool extraCoins;

    public void Start()
    {
        _scoreC = GetComponent<ScoreCount>();
        StopAllWalls();
    }


    private void Update()
    {
        if(!GameManager.instance.paused)
        {
            if(spawnedAreas[0].transform.position.y <= destructionPos.position.y)
            {
                GenerateNewArea();
                DestroyArea();
            }


            for (int i = 1; i < spawnedAreas.Count; i++)
            {
                Rigidbody2D firstRb = spawnedAreas[i - 1].GetComponent<Rigidbody2D>();
                Rigidbody2D secondRb = spawnedAreas[i].GetComponent<Rigidbody2D>();
                secondRb.transform.position = new Vector3(0, firstRb.transform.position.y + 15, 0);
            }
        }
        else
        {
            StopAllWalls();
        }
    }

    void GenerateNewArea()
    {
        int randomIndex = Random.Range(0, currentMaxArea);


        GameObject newArea = Instantiate(allAreas[randomIndex], generationPos.position, Quaternion.identity);
        newArea.GetComponent<LevelArea>().areasMan = this;
        newArea.GetComponent<ItemsSpawn>().extraCoins = extraCoins;

        //newArea.GetComponent<DistanceJoint2D>().connectedBody = spawnedAreas[spawnedAreas.Count - 1].GetComponent<Rigidbody2D>();

        HazardSpawner newHazardSpawn = newArea.GetComponent<HazardSpawner>();

        newHazardSpawn.currentMaxTrap = currentMaxTraps;
        newHazardSpawn.maxSpawned = trapsAmount;

        spawnedAreas.Add(newArea.GetComponent<LevelArea>());
    }

    void DestroyArea()
    {
        LevelArea oldArea = spawnedAreas[0];

        spawnedAreas.Remove(spawnedAreas[0]);
        Destroy(oldArea.gameObject);

        //spawnedAreas[0].GetComponent<DistanceJoint2D>().enabled = false;
    }


    public void MoveAllAreas(Vector2 movementForce)//TELEPORT AREAS
    {
        foreach(LevelArea l in spawnedAreas)
        {
            Rigidbody2D rb = l.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.AddForce(new Vector2(0, -movementForce.y), ForceMode2D.Impulse);
        }
        
    }

    public void StopAllWalls()
    {
        foreach (LevelArea l in spawnedAreas)
        {
            Rigidbody2D rb = l.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.velocity = Vector2.zero;
        }
    }

    public void ResetLevel()
    {
        GameObject newSetup = Instantiate(initialSetup, Vector3.zero, Quaternion.Euler(Vector3.zero));

        trapsAmount = 2;
        currentMaxTraps = 2;
        currentMaxArea = 1;

        foreach (LevelArea l in spawnedAreas)
        {
            Destroy(l.gameObject);
        }

        spawnedAreas.Clear();

        foreach(LevelArea l in newSetup.GetComponentsInChildren<LevelArea>())
        {
            spawnedAreas.Add(l);
            l.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
    }
}
