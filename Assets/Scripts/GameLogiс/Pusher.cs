using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum DirectionForce
{
    left,
    right,
    forward,
    back,
    diag
}

public class Pusher : MonoBehaviour
{
    [SerializeField] private int _forceLaunch;
    [SerializeField] private bool _isLaunch;    
    [SerializeField] private DirectionForce _directionMove;    
    [SerializeField] private Vector3 _directionForce;    
    [SerializeField] private bool _isGo;    
    [Range(0,1)][SerializeField] private float _speedRevert;    
    
    private Rigidbody _rigidbody;    
    private Transform _transform;    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();

        if (_directionMove == DirectionForce.right)
        {
            _directionForce = Vector3.right;//не фризить позицию по x
        }
        else if (_directionMove == DirectionForce.left)
        {
            _directionForce = Vector3.left;//не фризить позицию по x
        }
        else if (_directionMove == DirectionForce.back)
        {
            _directionForce = Vector3.back;//не фризить позицию по z
        }
        else if (_directionMove == DirectionForce.forward)
        {
            _directionForce = Vector3.forward;//не фризить позицию по z
        }
        else if (_directionMove == DirectionForce.diag)
        {
            _directionForce = Vector3.forward + Vector3.left;//не фризить позицию по z
        }
    }

    private void FixedUpdate()
    {
        if (_isGo)
        {
            Launch();
            _isGo = false;
        }

        if (_isLaunch)
        {            
            if (transform.localPosition.x > 6)
            {                
                _rigidbody.velocity = Vector3.zero;
                ReverseMovement();
                _isLaunch = false;
            }
            
        }
    }

    public void Launch()
    {        
        _rigidbody.AddForce(_directionForce * _forceLaunch);
        _isLaunch = true;
    }

    private void ReverseMovement()
    {
        //transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, _speedRevert);
        transform.localPosition = Vector3.zero;
    }
}
