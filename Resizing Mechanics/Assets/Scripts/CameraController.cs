using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    [FormerlySerializedAs("_offset")] [SerializeField] private Vector3 offset;
    [SerializeField] private Transform cameraTarget;
    void LateUpdate()
    {
        // transform.localPosition = cameraTarget.transform.position + offset; 
    }
}
