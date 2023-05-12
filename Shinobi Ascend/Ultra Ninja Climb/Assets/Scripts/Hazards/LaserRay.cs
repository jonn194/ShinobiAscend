using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRay : MonoBehaviour
{
    public float lerpSpeed;

    public LineRenderer lineR;
    public GameObject hitter;
    public GameObject particles;

    public Transform startPos;
    public Transform endPos;

    public float offTime;
    public float prewarmTime;
    public float shootTime;

    float _currentOffTime;
    float _currentPrewarmTime;
    float _currentShootTime;

    bool _off = true;
    bool _prewarming;
    bool _shooting;

    float _originalWidth;

    public AudioClip shootAudio;
    public AudioClip heldAudio;

    AudioExecution _aExecution;

    void Start()
    {
        _currentOffTime = offTime;
        _currentPrewarmTime = prewarmTime;
        _currentShootTime = shootTime;

        _originalWidth = lineR.startWidth;

        _aExecution = GetComponent<AudioExecution>();
    }

    
    void Update()
    {
        if (!GameManager.instance.paused)
        {
            if (_off)
            {
                _currentOffTime -= Time.deltaTime;
                lineR.gameObject.SetActive(false);
                hitter.SetActive(false);
                particles.SetActive(false);
                lineR.SetPosition(0, startPos.position);
                lineR.SetPosition(1, startPos.position);
            }
            else if (_prewarming)
            {
                _currentPrewarmTime -= Time.deltaTime;
                lineR.gameObject.SetActive(true);
                lineR.SetPosition(0, startPos.position);
                //lineR.SetPosition(1, Vector3.Lerp(lineR.GetPosition(1), endPos.position, lerpSpeed * Time.deltaTime));

                lineR.SetPosition(1, endPos.position);

                /*if (Vector3.Distance(lineR.GetPosition(1), endPos.position) < 0.1f)
                {
                    lineR.SetPosition(1, endPos.position);
                }*/
            }
            else if (_shooting)
            {
                _currentShootTime -= Time.deltaTime;
                particles.SetActive(true);
                hitter.SetActive(true);
                lineR.SetPosition(0, startPos.position);
                lineR.SetPosition(1, endPos.position);
                lineR.startWidth = Mathf.Lerp(lineR.startWidth, _originalWidth, lerpSpeed * Time.deltaTime);
            }

            if (_currentOffTime <= 0)
            {
                _off = false;
                _prewarming = true;
                _currentOffTime = offTime;
                lineR.startWidth = lineR.startWidth / 5;
                _aExecution.PlayAudio(shootAudio);
            }
            else if (_currentPrewarmTime <= 0)
            {
                _prewarming = false;
                _shooting = true;
                _currentPrewarmTime = prewarmTime;
                _aExecution.PlayAudioLooped(heldAudio);
            }
            else if (_currentShootTime <= 0)
            {
                _shooting = false;
                _off = true;
                _currentShootTime = shootTime;
                _aExecution.StopAudio();
            }
        }

        
    }
}
