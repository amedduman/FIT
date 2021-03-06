﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    
    [SerializeField] Vector3 _destination;
    [SerializeField] [Tooltip("higher is slower")] [Range(1, 10)] private int speed = 1;

    

    [SerializeField] private float maxHeight = 5;
    [SerializeField] private float minHeight = 1;
    [SerializeField] private float minColonGap = 0.5f;
    private float _height = 1; // obstacle height 

    private Vector3 _startPos;
    private float _lerpFactor = 0;
    private readonly Color _failObstacleColor = Color.red;

   
    public void StartMoving()
    {
        _height = UnityEngine.Random.Range(minHeight, maxHeight);
        SetObstacleHeight();
        _lerpFactor = 0;
        _startPos = transform.position;
        
    }

    private void Update()
    {
        _lerpFactor += Time.deltaTime / speed;
        transform.position = Vector3.Lerp(_startPos, _destination, _lerpFactor);
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("End Trigger"))
        {
            ObstacleSpawnManager.PushObstacleToPool(this);
        }
        
        else if (other.gameObject.CompareTag("Player"))
        {
            FailProcess();
        }
    }

    private void FailProcess()
    {
        GameManager.EndGame();
        SetFailedObstacleColor();
    }

    private void SetFailedObstacleColor()
    {
        _girder.GetComponentInChildren<Renderer>().material.color = _failObstacleColor;
        _colonRight.GetComponentInChildren<Renderer>().material.color = _failObstacleColor;
        _colonLeft.GetComponentInChildren<Renderer>().material.color = _failObstacleColor;
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
        _colonPos = ((maxHeight / _height) / 2) + minColonGap; // we divide by two because this value is distance of every colon to the center of obstacle
        _colonRight.transform.position = new Vector3(_colonPos, _colonRight.transform.position.y, _colonRight.transform.position.z);
        _colonLeft.transform.position = new Vector3(-_colonPos, _colonRight.transform.position.y, _colonRight.transform.position.z);
    }
}
