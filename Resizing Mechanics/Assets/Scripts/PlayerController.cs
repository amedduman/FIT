using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _minVerticalScale = 1;
    [SerializeField] float _maxVerticalScale = 3;
    [SerializeField] float _minHorizontalScale = 1;
    [SerializeField] float _maxHorizontalScale = 3;
    [SerializeField] [Range(0.1f, 1)] float _scaleSpeed = 1;


    private void Start()
    {
        GameManager.ChangeTimeScale(0);
    }


    void Update()
    {
        if (Input.GetMouseButton(0) && GameManager.IsPlaying)
        {
            ScalingProccess();
        }
    }


   


    private void ScalingProccess()
    {
        float y = Input.GetAxis("Mouse Y") * _scaleSpeed;
        
        Vector3 scale = transform.localScale;

        if (scale.y + y > _minVerticalScale && scale.y + y < _maxVerticalScale)
        {
            transform.localScale = new Vector3(scale.x, scale.y + y, scale.z);
            scale.y = scale.y + y; // update scale 
        }

        scale.x = _maxHorizontalScale / (scale.y + y);
        if (scale.x > _minHorizontalScale && scale.x < _maxHorizontalScale)
        {
            transform.localScale = new Vector3(scale.x, transform.localScale.y, scale.z);
        }
    }
}
