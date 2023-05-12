using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotCtrl : MonoBehaviour
{
    public GameObject marker;
    public GameObject tinyMarker;
    SpriteRenderer _markerSprite;
    SpriteRenderer _tinyMarkerSprite;
    LineRenderer _lineRenderer;

    MainCharacter _mainChar;

    public float impulseForce;

    Vector2 _clickedPos;
    Vector2 _draggedPos;
    Vector2 _direction;

    float _slingDistance;

    public AreasManager _areasMan;

    void Start()
    {
        _mainChar = GetComponent<MainCharacter>();

        _markerSprite = marker.GetComponent<SpriteRenderer>();
        _lineRenderer = marker.GetComponent<LineRenderer>();
        _lineRenderer.enabled = false;
        _tinyMarkerSprite = tinyMarker.GetComponent<SpriteRenderer>();

        _markerSprite.color = new Color(_markerSprite.color.r, _markerSprite.color.g, _markerSprite.color.b, 0);
        _tinyMarkerSprite.color = new Color(_tinyMarkerSprite.color.r, _tinyMarkerSprite.color.g, _tinyMarkerSprite.color.b, 0);
    }


    void Update()
    {
        if(!GameManager.instance.paused)
        {
            SlingshotDetection();
        }
    }

    void SlingshotDetection()
    {
        if(_mainChar.onWall)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _lineRenderer.enabled = true;
                _clickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _draggedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                marker.transform.position = _clickedPos;
                _markerSprite.color = new Color(_markerSprite.color.r, _markerSprite.color.g, _markerSprite.color.b, 1);
            }

            if (Input.GetMouseButton(0) && !_mainChar.damaged)
            {
                _draggedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                tinyMarker.transform.position = _draggedPos;
                _tinyMarkerSprite.color = new Color(_tinyMarkerSprite.color.r, _tinyMarkerSprite.color.g, _tinyMarkerSprite.color.b, 1);
                _lineRenderer.SetPosition(0, _clickedPos);
                _lineRenderer.SetPosition(1, _draggedPos);
            }

            if (Input.GetMouseButtonUp(0) && _clickedPos != _draggedPos)
            {
                CharacterJump();
                _clickedPos = Vector2.zero;
                _draggedPos = Vector2.zero;
                _markerSprite.color = new Color(_markerSprite.color.r, _markerSprite.color.g, _markerSprite.color.b, 0);
                _tinyMarkerSprite.color = new Color(_tinyMarkerSprite.color.r, _tinyMarkerSprite.color.g, _tinyMarkerSprite.color.b, 0);
                _lineRenderer.SetPosition(0, _clickedPos);
                _lineRenderer.SetPosition(1, _draggedPos);
                _lineRenderer.enabled = false;
            }
        }
        
    }

    void CharacterJump()
    {
        _slingDistance = Vector2.Distance(_clickedPos, _draggedPos);
        _direction = (_clickedPos - _draggedPos).normalized;

        float rotY = _mainChar.transform.rotation.eulerAngles.y;


        if ((rotY < 90 && _direction.x > 0) || (rotY > 90 && _direction.x < 0))
        {
            if(_mainChar.wallDetect.wall)
            {
                return;
            }
        }

        if (!_mainChar.wallDetect.wall && _direction.y < 0)
        {
            return;
        }


        if ((_direction.x > 0 && _mainChar.transform.right.x < 0) ||
            (_direction.x < 0 && _mainChar.transform.right.x > 0))
        {
            _mainChar.CharacterFlip();
        }
               
        Vector2 movement = _direction * impulseForce * _slingDistance;

        _mainChar.MoveCharacter(movement);
        _mainChar.wallDetect.stopped = false;
    }


    public void ResetSlingshot()
    {
        _slingDistance = 0;
        _clickedPos = Vector2.zero;
        _draggedPos = Vector2.zero;
        _markerSprite.color = new Color(_markerSprite.color.r, _markerSprite.color.g, _markerSprite.color.b, 0);
        _tinyMarkerSprite.color = new Color(_tinyMarkerSprite.color.r, _tinyMarkerSprite.color.g, _tinyMarkerSprite.color.b, 0);
        _lineRenderer.SetPosition(0, _clickedPos);
        _lineRenderer.SetPosition(1, _draggedPos);
    }
}
