using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HazardSpawner : MonoBehaviour
{
    public int currentMaxTrap;
    public int maxSpawned;

    public List<GameObject> allTraps = new List<GameObject>();

    public Transform spawnPointsParent;
    List<Transform> availeablePoints = new List<Transform>();

    void Start()
    {
        availeablePoints = spawnPointsParent.GetComponentsInChildren<Transform>().ToList();
        availeablePoints.Remove(availeablePoints[0]);

        if(currentMaxTrap >= allTraps.Count)//HAGO UN CAP DE LAS TRAMPAS, POR SI LA DIFICULTAD ME DA UN VALOR SUPERIOR A LA CANTIDAD DE TRAMPAS
        {
            currentMaxTrap = allTraps.Count - 1;
        }

        if(maxSpawned >= availeablePoints.Count)//HAGO UN CAP DE LA CANTIDAD, POR SI LA DIFICULTAD ME DA UN VALOR SUPERIOR A LA CANTIDAD DE SPAWNERS
        {
            maxSpawned = availeablePoints.Count - 1;
        }

        for(int i = 0; i < maxSpawned; i++)
        {
            PickTrap();
        }
    }

    Transform PickPoint()
    {
        Transform auxTransform;
        int randomAux = Random.Range(0, availeablePoints.Count);

        auxTransform = availeablePoints[randomAux];

        availeablePoints.Remove(availeablePoints[randomAux]);

        return auxTransform;
    }

    void PickTrap()
    {
        int randomAux = Random.Range(0, currentMaxTrap);

        Transform point = PickPoint();

        GameObject spawned = Instantiate(allTraps[randomAux], point.position, point.rotation, point);
    }
}
