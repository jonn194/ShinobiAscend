using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuGUI : MonoBehaviour
{
    public GUIManager guiMan;

    public TextMeshProUGUI highScoreTxt;
    public TextMeshProUGUI coinsTxt;

    bool _optionsState;

    public Animator optionsAnim;

    public Button playButton;
    public Button buyButton;
    public TextMeshProUGUI priceTxt;
    public TextMeshProUGUI description;

    private void Start()
    {
        if (GameManager.instance != null)
        {
            UpdateValues();
        }
    }

    private void OnEnable()
    {
        if(GameManager.instance != null)
        {
            UpdateValues();
        }
    }

    public void UpdateValues()
    {
        highScoreTxt.text = GameManager.instance.highScore.ToString();
        coinsTxt.text = GameManager.instance.coins.ToString();
    }

    public void ToggleOptions()
    {
        if (_optionsState)
        {
            _optionsState = false;

            optionsAnim.SetBool("open", _optionsState);
            GameManager.instance.SaveGame();
        }
        else
        {
            _optionsState = true;
            optionsAnim.SetBool("open", _optionsState);
        }
    }
}
