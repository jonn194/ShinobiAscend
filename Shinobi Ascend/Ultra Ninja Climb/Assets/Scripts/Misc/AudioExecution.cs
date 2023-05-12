using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioExecution : MonoBehaviour
{
    public AudioSource aSource;

    public bool autoExecute;
    public float time;

    bool _executed;

    private void Update()
    {
        if(!GameManager.instance.paused && autoExecute && !_executed)
        {
            aSource.Play();
            _executed = true;
        }
        else if(GameManager.instance.paused && autoExecute)
        {
            aSource.Stop();
            _executed = false;
        }
    }

    public void PlayAudio(AudioClip aClip)
    {
        aSource.clip = aClip;
        aSource.Play();
    }

    public void PlayAudio()
    {
        aSource.Play();
    }

    public void PlayAudioLooped(AudioClip aClip)
    {
        aSource.clip = aClip;
        aSource.loop = true;

        aSource.Play();
    }

    public void StopAudio()
    {
        aSource.loop = false;
        aSource.Stop();
    }
}
