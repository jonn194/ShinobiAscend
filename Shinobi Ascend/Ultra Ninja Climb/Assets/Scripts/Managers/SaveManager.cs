using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveManager
{
    public static void Save(GameManager gameMan)
    {
        string saveFile;

        SaveData data = new SaveData(gameMan);

        saveFile = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("gManagerDat", saveFile);
    }

    public static SaveData Load()
    {
        if(PlayerPrefs.HasKey("gManagerDat"))
        {
            string loadedFile;

            loadedFile = PlayerPrefs.GetString("gManagerDat");
            return JsonUtility.FromJson<SaveData>(loadedFile);
        }
        else
        {
            return null;
        }
    }
}
