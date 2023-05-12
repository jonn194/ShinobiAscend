using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMan : MonoBehaviour
{
    GUIManager _guiMan;

    bool _loading;

    public void ChangeScene(int sceneCode)
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            _guiMan = GetComponent<GUIManager>();
        }


        if (!_loading)
        {
            StartCoroutine(LoadLevelAsync(sceneCode));

            _loading = true;
        }

        if (sceneCode == 1 && SceneManager.GetActiveScene().buildIndex != 0)
        {
            GameManager.instance.paused = true;
        }
    }

    IEnumerator LoadLevelAsync(int sceneCode)
    {
        AsyncOperation loadLevel = SceneManager.LoadSceneAsync(sceneCode, LoadSceneMode.Single);

        while (!loadLevel.isDone)
        {
            yield return null;
        }

    }

    public int GetCurrentScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
