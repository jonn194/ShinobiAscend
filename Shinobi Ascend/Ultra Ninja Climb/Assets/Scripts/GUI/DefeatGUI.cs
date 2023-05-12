using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefeatGUI : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI coinsTxt;

   
    public void ShowFinalScore()
    {
        scoreTxt.text = GameManager.instance.currentScore.ToString();
        coinsTxt.text = GameManager.instance.currentCoin.ToString();
    }
 }
