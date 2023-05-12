using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mixer;

    float musicDefault = 0;
    float sfxDefault = -10;

    public Image musicButtonImg;
    public Image sfxButtonImg;

    public Color onColor;
    public Color muteColor;

    private void Start()
    {
        if(GameManager.instance.musicMute)
        {
            mixer.SetFloat("MusicVolume", -80);
            musicButtonImg.color = muteColor;
        }

        if (GameManager.instance.sfxMute)
        {
            mixer.SetFloat("SFXVolume", -80);
            sfxButtonImg.color = muteColor;
        }
    }

    public void MuteToggle(string type)
    {
        switch(type)
        {
            case "Music":
                if(GameManager.instance.musicMute)
                {
                    mixer.SetFloat("MusicVolume", musicDefault);
                    GameManager.instance.musicMute = false;
                    musicButtonImg.color = onColor;
                }
                else
                {
                    mixer.SetFloat("MusicVolume", -80);
                    GameManager.instance.musicMute = true;
                    musicButtonImg.color = muteColor;
                }
                break;
            case "SFX":
                if (GameManager.instance.sfxMute)
                {
                    mixer.SetFloat("SFXVolume", sfxDefault);
                    GameManager.instance.sfxMute = false;
                    sfxButtonImg.color = onColor;
                }
                else
                {
                    mixer.SetFloat("SFXVolume", -80);
                    GameManager.instance.sfxMute = true;
                    sfxButtonImg.color = muteColor;
                }
                break;
        }
    }
}
