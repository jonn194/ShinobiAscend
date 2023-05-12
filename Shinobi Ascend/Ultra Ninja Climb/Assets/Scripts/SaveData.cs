using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int highScore;
    public int coins;
    public bool musicMute;
    public bool sfxMute;


    public int currentNinja;
    public List<bool> ninjasOwned = new List<bool>();

    public SaveData(GameManager gameMan)
    {
        highScore = gameMan.highScore;
        coins = gameMan.coins;

        musicMute = gameMan.musicMute;
        sfxMute = gameMan.sfxMute;

        currentNinja = gameMan.currentNinja;
        ninjasOwned = gameMan.ninjasOwned;
    }
}
