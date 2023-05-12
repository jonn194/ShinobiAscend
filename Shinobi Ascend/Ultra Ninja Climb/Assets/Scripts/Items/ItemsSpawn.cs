using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawn : MonoBehaviour
{
    public List<GameObject> allItems = new List<GameObject>();

    public Transform spawnPoint;
    public Transform extraSpawnPoint;

    public bool extraCoins;

    void Start()
    {
        if(spawnPoint != null)
        {
            int aux = Random.Range(0, 100);


            if (aux > 10 && aux < 50)
            {
                //COIN
                Instantiate(allItems[0], spawnPoint.position, spawnPoint.rotation, spawnPoint);
            }
            else if (aux >= 50 && aux < 75)
            {
                //KUNAI
                Instantiate(allItems[1], spawnPoint.position, spawnPoint.rotation, spawnPoint);
            }
            else if (aux >= 75 && aux < 90)
            {
                //SHIELD
                Instantiate(allItems[2], spawnPoint.position, spawnPoint.rotation, spawnPoint);
            }
            else if (aux >= 90 && aux <= 100)
            {
                //POTION
                Instantiate(allItems[3], spawnPoint.position, spawnPoint.rotation, spawnPoint);
            }
        }


        if(extraCoins)
        {
            int randomAux = Random.Range(0,100);

            if(randomAux > 50)
            {
                Instantiate(allItems[0], extraSpawnPoint.position, extraSpawnPoint.rotation, extraSpawnPoint);
            }
        }
    }
}
