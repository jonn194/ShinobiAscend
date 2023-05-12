using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayGUI : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;

    public List<Image> hearts = new List<Image>();
    public List<Image> kunais = new List<Image>();

    public Image extraHeart;

    public void FixedUpdate()
    {
        scoreTxt.text = GameManager.instance.currentScore.ToString();

        for (int i = 0; i < hearts.Count; i++)
        {
            if (i > GameManager.instance.currentHP - 1)
            {
                hearts[i].gameObject.SetActive(false);
            }
            else
            {
                hearts[i].gameObject.SetActive(true);
            }
        }

        for (int i = 0; i < kunais.Count; i++)
        {
            if (i > GameManager.instance.currentKunais - 1)
            {
                kunais[i].gameObject.SetActive(false);
            }
            else
            {
                kunais[i].gameObject.SetActive(true);
            }
        }

        if(GameManager.instance.hasExtraLife)
        {
            extraHeart.gameObject.SetActive(true);
        }
        else
        {
            extraHeart.gameObject.SetActive(false);
        }
    }
}
