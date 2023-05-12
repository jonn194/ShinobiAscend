using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjasPowers : MonoBehaviour
{
    public float itemsRadius;
    public float hazardRadius;

    public LayerMask itemsMask;
    public LayerMask hazardsMask;

    public AreasManager areaMan;

    public float magnetSpeed;

    public bool starterGranted;

    List<GameObject> checkedObjects = new List<GameObject>();

    void Update()
    {
        if(!GameManager.instance.paused)
        {
            switch (GameManager.instance.currentNinja)
            {
                case 1:
                    ExtraLife();
                    areaMan.extraCoins = false;
                    break;
                case 2:
                    ItemsMagnet();
                    areaMan.extraCoins = false;
                    break;
                case 3:
                    SpawnCoins();
                    break;
                case 4:
                    BreakTraps();
                    areaMan.extraCoins = false;
                    break;
                case 5:
                    if(!starterGranted)
                    {
                        ItemsGift();
                        starterGranted = true;
                    }
                    areaMan.extraCoins = false;
                    break;
            }
        }
        
    }

    void ExtraLife()//DONE
    {
        GameManager.instance.extraLife = true;

        if(!starterGranted)
        {
            GameManager.instance.hasExtraLife = true;
            starterGranted = true;
        }
        
    }

    void ItemsMagnet()//DONE
    {
       Collider2D[] detected = Physics2D.OverlapCircleAll(transform.position, itemsRadius, itemsMask);

        foreach(Collider2D i in detected)
        {
            i.gameObject.transform.position = Vector3.MoveTowards(i.gameObject.transform.position, transform.position, magnetSpeed * Time.deltaTime);
        }
    }

    void SpawnCoins()//DONE
    {
        areaMan.extraCoins = true;
    }

    void BreakTraps()//DONE
    {
        Collider2D[] detected = Physics2D.OverlapCircleAll(transform.position, hazardRadius, hazardsMask);

        foreach (Collider2D h in detected)
        {
            if(!checkedObjects.Contains(h.gameObject))
            {
                int randomAux = Random.Range(0, 100);

                if (randomAux > 85)
                {
                    h.gameObject.GetComponent<Hazard>().Destruction();
                }

                checkedObjects.Add(h.gameObject);
            }
        }

        for(int i = checkedObjects.Count-1; i >= 0; i--)
        {
            if(checkedObjects[i] == null)
            {
                checkedObjects.Remove(checkedObjects[i]);
            }
        }
    }

    void ItemsGift()//DONE
    {
        GameManager.instance.hasShield = true;
        GameManager.instance.currentKunais = 1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, itemsRadius);

        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, hazardRadius);
    }
}
