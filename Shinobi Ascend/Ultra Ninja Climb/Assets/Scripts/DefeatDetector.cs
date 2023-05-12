using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatDetector : MonoBehaviour
{
    GUIManager _guiMan;
    AreasManager _areasMan;
    ScoreCount _scoreC;
    DificultyManager _dificultyMan;
    BackgroundManager _backgroundMan;

    MainCharacter _mainChar;
    SlingshotCtrl _slingshot;
    AudioExecution _aExecution;

    DefeatGUI _defeatGUI;

    bool _displayed;

    public RampantDeath rDeath;
    public AudioClip deathAudio;

    private void Start()
    {
        _guiMan = GetComponent<GUIManager>();
        _areasMan = GetComponent<AreasManager>();
        _scoreC = GetComponent<ScoreCount>();
        _dificultyMan = GetComponent<DificultyManager>();
        _backgroundMan = GetComponent<BackgroundManager>();

        _mainChar = _areasMan.mainChar;
        _slingshot = _areasMan.mainChar.gameObject.GetComponent<SlingshotCtrl>();
        _aExecution = _mainChar.gameObject.GetComponent<AudioExecution>();

        _defeatGUI = _guiMan.defeat.GetComponent<DefeatGUI>();
    }

    void FixedUpdate()
    {
        if(GameManager.instance.currentHP <= 0 && !_displayed)
        {
            GameManager.instance.PauseControl(true);
            _guiMan.ChangeGUI("defeat");
            _defeatGUI.ShowFinalScore();
            _aExecution.PlayAudio(deathAudio);
            GameManager.instance.ResetValues();
            GameManager.instance.SaveGame();
            _displayed = true;
        }
    }


    public void BackToMenu()
    {
        rDeath.Reset();
        _mainChar.ResetCharacter();
        _mainChar.gameObject.GetComponent<NinjasPowers>().starterGranted = false;
        _slingshot.ResetSlingshot();
        _areasMan.ResetLevel();
        _guiMan.ChangeGUI("mainMenu");
        _scoreC.ResetCounter();
        _dificultyMan.ResetDificulty();
        _backgroundMan.ResetBack();
        _displayed = false;
    }
}
