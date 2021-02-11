using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameObject _colonRight;
    [SerializeField] private Transform _rightColTop;
    [SerializeField] private GameObject _colonLeft;
    [SerializeField] private Transform _leftColTop;
    [SerializeField] private GameObject _girder;
    [SerializeField] GameObject _gapCol;
    [SerializeField] [Range(0.1f, 10)] float _duration = 1;
    [SerializeField] Vector3 _destination;

    private float _height = 1; // obstacle height 



    private void Start()
    {
        _height = UnityEngine.Random.Range(1f, 5f);
        SetObstacleHeight();
        Move();
    }
    private void Update()
    {
        #region old code

        // // raise colons
        // Vector3 _colonScale = _colonLeft.transform.localScale;
        // _colonScale.y = _height;
        // _colonLeft.transform.localScale = _colonScale;
        // _colonRight.transform.localScale = _colonScale;

        // // raise girder
        // Vector3 _girderPos = new Vector3((_rightColTop.transform.position.x + _leftColTop.transform.position.x) / 2, _rightColTop.transform.position.y, _rightColTop.transform.position.z);
        // _girder.transform.position = _girderPos;

        // // scale girder
        // float xScale = _rightColTop.transform.position.x - _leftColTop.transform.position.x;
        // _girder.transform.localScale = new Vector3(xScale, _girder.transform.localScale.y, _girder.transform.localScale.z);


        // float _colonPos = _colonRight.transform.position.x;
        // _colonPos = 1.5f + 3 / _height;
        // _colonRight.transform.position = new Vector3(_colonPos, _colonRight.transform.position.y, _colonRight.transform.position.z);
        // _colonLeft.transform.position = new Vector3(-_colonPos, _colonRight.transform.position.y, _colonRight.transform.position.z);

        #endregion
    }


    private void Move()
    {
        transform.DOMove(_destination, _duration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("End Trigger"))
        {
            ObstacleSpawnManager.PushObstacleToPool(this);
        }
        
        else if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("game is over");
        }
    }

    

    private void SetObstacleHeight()
    {
        RaiseColons();
        RaiseGirder();
        ExtendColons();
        ScaleGirder();
        ScaleGap();
    }

    private void RaiseColons()
    {
        Vector3 _colonScale = _colonLeft.transform.localScale;
        _colonScale.y = _height;
        _colonLeft.transform.localScale = _colonScale;
        _colonRight.transform.localScale = _colonScale;
    }

    private void RaiseGirder()
    {
        Vector3 _girderPos = new Vector3((_rightColTop.transform.position.x + _leftColTop.transform.position.x) / 2, _rightColTop.transform.position.y, _rightColTop.transform.position.z);
        _girder.transform.position = _girderPos;
    }

    private void ScaleGirder()
    {
        float xScale = _rightColTop.transform.position.x - _leftColTop.transform.position.x;
        _girder.transform.localScale = new Vector3(xScale, _girder.transform.localScale.y, _girder.transform.localScale.z);
    }

    private void ScaleGap()
    {
        float xScale = _rightColTop.transform.position.x - _leftColTop.transform.position.x;
        _gapCol.transform.localScale = new Vector3(xScale, _gapCol.transform.localScale.y, _gapCol.transform.localScale.z);
    }

    private void ExtendColons()
    {
        float _colonPos;
        _colonPos = (5 / _height) / 2 + 0.25f;
        _colonRight.transform.position = new Vector3(_colonPos, _colonRight.transform.position.y, _colonRight.transform.position.z);
        _colonLeft.transform.position = new Vector3(-_colonPos, _colonRight.transform.position.y, _colonRight.transform.position.z);
    }
}
