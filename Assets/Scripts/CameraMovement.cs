using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _idlePosition;
    [SerializeField] private bool _isReturnToStartPosition;
    [SerializeField] private bool _isMovementForProjectile;

    private float _smooth = 5.0f;
    private Vector3 _offset = new Vector3(0, 15, -10);

    private void FixedUpdate()
    {
        if (_isMovementForProjectile && _target != null)
        {
            transform.position = Vector3.Lerp(transform.position, _target.position + _offset, Time.deltaTime * _smooth);
        }

        if (_isReturnToStartPosition)
        {
            transform.position = Vector3.Lerp(transform.position, _startPosition.position, Time.deltaTime * _smooth);
            transform.rotation = _startPosition.rotation;
            if (Vector3.Distance(transform.position, _startPosition.position) <= 0.1)
            {
                _isReturnToStartPosition = false;                
            }
        }
    }

    public void SetTarget(Transform targetPosition)
    {
        _target = targetPosition;        
    }

    public void DeleteTarget()
    {
        _target = null;
    }

    public void ReturnPosition()
    {                           
        _isMovementForProjectile = false;
        _isReturnToStartPosition = true;        
    }

    public void ForProjectile()
    {
        _isMovementForProjectile = true;
    }
}