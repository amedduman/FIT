using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Vector3 _offset;
    [SerializeField] PlayerController _player;
    void LateUpdate()
    {
        transform.localPosition = _player.transform.localPosition + _offset;
    }
}
