using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public itemType itemT;

    public GameObject pickFX;

    public enum itemType
    {
        coin,
        kunai,
        shield,
        potion
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == K.LAYER_MAINCHAR)
        {
            if(itemT == itemType.coin)
            {
                GameManager.instance.currentCoin++;
                DestroyItem();
            }
            else if (itemT == itemType.kunai)
            {
                if(GameManager.instance.currentKunais < 3)
                {
                    GameManager.instance.currentKunais++;
                    DestroyItem();
                }
            }
            else if (itemT == itemType.shield)
            {
                GameManager.instance.hasShield = true;
                DestroyItem();
            }
            else if (itemT == itemType.potion)
            {
                if(GameManager.instance.currentHP < GameManager.instance.maxHP)
                {
                    GameManager.instance.currentHP++;
                }
                else if(GameManager.instance.extraLife)
                {
                    GameManager.instance.hasExtraLife = true;
                }
                DestroyItem();
            }
        }
    }

    public void DestroyItem()
    {
        Instantiate(pickFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
