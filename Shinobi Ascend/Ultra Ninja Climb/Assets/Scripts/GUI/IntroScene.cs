using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScene : MonoBehaviour
{
    public GameObject logoCanvas;
    public GameObject splashCanvas;
    public GameObject moonLogo;

    public float timeToSplash;
    public float timeToChange;
    public int sceneCode;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        ChangeScene();
    }


    void ChangeScene()
    {
        timeToSplash -= Time.deltaTime;



        if (timeToSplash <= 0)
        {
            logoCanvas.SetActive(false);
            splashCanvas.SetActive(true);

            timeToChange -= Time.deltaTime;
        }
        if (timeToChange <= 0)
        {
            GetComponent<SceneMan>().ChangeScene(sceneCode);
        }
    }
}
