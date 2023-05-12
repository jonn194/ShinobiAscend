using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    public bool onWall;
    public Vector2 movementSpeed;

    Rigidbody2D _rb;

    MainCharAnimatorCtrl _animCtrl;
    AudioExecution _aExecution;

    public WallDetector wallDetect;

    bool _stopped;
    public bool damaged;

    Vector3 _originalPos;
    Vector3 _originalRot;

    Shield _shield;
    Kunais _kunais;

    public AudioClip jumpAudio;
    public AudioClip damagedAudio;
    public AudioClip shieldDestoyAudio;
    public AudioClip shootKunaiAudio;

    AreasManager _areasMan;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animCtrl = GetComponent<MainCharAnimatorCtrl>();
        _aExecution = GetComponent<AudioExecution>();

        _originalPos = transform.position;
        _originalRot = transform.rotation.eulerAngles;

        _shield = GetComponent<Shield>();
        _kunais = GetComponent<Kunais>();

        _areasMan = GetComponent<LocatorFinder>().locator.GetComponent<AreasManager>();
    }

    private void Update()
    {
        CheckWalls();

        if(GameManager.instance.currentHP == 0)
        {
            StopCharacter();
        }
    }

    public void MoveCharacter(Vector2 movement)
    {
        movementSpeed = movement;
        _rb.gravityScale = 1;
        _rb.AddForce(new Vector2(movement.x, 0), ForceMode2D.Impulse);
        _animCtrl.Jumping(true);

        _areasMan.MoveAllAreas(movement);

        _aExecution.PlayAudio(jumpAudio);

        if(GameManager.instance.currentKunais > 0)
        {
            _kunais.ShootKunai(movement, _aExecution);
        }
    }

    public void StopCharacter()
    {
        _rb.gravityScale = 0;
        _rb.velocity = Vector2.zero;

        _areasMan.StopAllWalls();
    }

    public void CharacterFlip()
    {
        transform.Rotate(0, 180, 0);
    }

    public void TakeDamage(float hazardY, Vector2 backstep, bool wallHazard)
    {
        damaged = true;
        StartCoroutine(ClearDamage());

        if(!_stopped)
        {
            StopCharacter();
            _stopped = true;
        }
        

        if(wallHazard)
        {
            onWall = false;

            if(transform.rotation.y != hazardY)
            {
                CharacterFlip();
            }
            
        }
        else 
        {
            if(transform.rotation.y != hazardY || !onWall)
            {
                CharacterFlip();
                onWall = false;
            }
        }

        MoveCharacter(transform.right * backstep);


        if(!GameManager.instance.hasShield)
        {
            if(GameManager.instance.hasExtraLife)
            {
                GameManager.instance.hasExtraLife = false;
            }
            else
            {
                GameManager.instance.currentHP--;
            }

            _aExecution.PlayAudio(damagedAudio);

            _animCtrl.Damaged(true);
        }
        else
        {
            GameManager.instance.hasShield = false;
            _shield.DestroyShield();
            _aExecution.PlayAudio(shieldDestoyAudio);
        }
        
    }

    IEnumerator ClearDamage()
    {
        yield return new WaitForSeconds(0.3f);
        damaged = false;
    }

    public void InstantDeath()
    {
        if (GameManager.instance.hasShield)
        {
            GameManager.instance.hasShield = false;
            _shield.DestroyShield();
        }

        GameManager.instance.currentHP = 0;
    }


    private void CheckWalls()
    {
        if(!damaged)
        {
            onWall = wallDetect.stopped;
        }
        
        

        if (onWall && !_stopped)
        {
            StopCharacter();

            if (!wallDetect.wall)
            {
                _animCtrl.OnFloor(true);
                _animCtrl.OnWall(false);
                _animCtrl.Jumping(false);
                _animCtrl.Damaged(false);
            }
            else
            {
                _animCtrl.OnWall(true);
                _animCtrl.OnFloor(false);
                _animCtrl.Jumping(false);
                _animCtrl.Damaged(false);
            }
            _stopped = true;
        }
        else
        {
            //_animCtrl.OnFloor(false);
            _stopped = false;
        }
    }

    public void ResetCharacter()
    {
        transform.position = _originalPos;
        transform.rotation = Quaternion.Euler(_originalRot);
        _animCtrl.OnWall(false);
        _animCtrl.Damaged(false);
        _animCtrl.OnFloor(true);
    }
}
