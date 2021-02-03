using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Transform _target;
    [SerializeField] private float _translateSpeed;
    [SerializeField] private float _rotationSpeed;

    void FixedUpdate()
    {
        HandleTranslation();
        HandleRotation();
    }
   
    public void HandleTranslation()
    {
        var _targetPosition = _target.TransformPoint(_offset);
        transform.position = Vector3.Lerp(transform.position, _targetPosition, _translateSpeed * Time.deltaTime);
    }
    public void HandleRotation()
    {
        var direction = _target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
    }
}