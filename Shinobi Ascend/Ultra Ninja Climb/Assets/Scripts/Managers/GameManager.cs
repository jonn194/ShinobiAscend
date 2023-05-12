using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int coins;
    public int currentCoin;

    public int maxHP;
    public int currentHP;

    public int highScore;
    public int currentScore;

    public int currentNinja;
    public List<bool> ninjasOwned = new List<bool>();

    public int currentKunais;
    public bool hasShield;
    public bool hasExtraLife;
    public bool extraLife;


    public bool paused = true;

    public bool musicMute;
    public bool sfxMute;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        ResetValues();

        if (PlayerPrefs.HasKey("gManagerDat") && PlayerPrefs.GetString("gManagerDat") != string.Empty)
            LoadGame();
    }

    public void ResetValues()
    {
        currentHP = maxHP;
        coins += currentCoin;

        if(currentScore > highScore)
        {
            highScore = currentScore;
        }

        currentScore = 0;
        currentCoin = 0;
        currentKunais = 0;
    }

    public void PauseControl(bool value)
    {
        paused = value;
    }

    public void SaveGame()
    {
        SaveManager.Save(this);
    }

    public void LoadGame()
    {
        SaveData data = SaveManager.Load();

        highScore = data.highScore;
        coins = data.coins;

        musicMute = data.musicMute;
        sfxMute = data.sfxMute;

        currentNinja = data.currentNinja;
        ninjasOwned = data.ninjasOwned;
    }
}
