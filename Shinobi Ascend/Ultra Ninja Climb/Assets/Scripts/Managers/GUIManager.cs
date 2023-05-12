using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public List<Image> hearts = new List<Image>();

    public GameObject mainMenu;
    public GameObject defeat;
    public GameObject gameplay;
    
    
    public void ChangeGUI(string targetGUI)
    {
        if (targetGUI == "mainMenu")
        {
            mainMenu.SetActive(true);
            defeat.SetActive(false);
            gameplay.SetActive(false);
            GameManager.instance.PauseControl(true);
        }
        else if (targetGUI == "defeat")
        {
            mainMenu.SetActive(false);
            defeat.SetActive(true);
            gameplay.SetActive(false);
            GameManager.instance.PauseControl(true);
        }
        else if (targetGUI == "gameplay")
        {
            mainMenu.SetActive(false);
            defeat.SetActive(false);
            gameplay.SetActive(true);
            GameManager.instance.PauseControl(false);
            GameManager.instance.SaveGame();
        }
    }
}
