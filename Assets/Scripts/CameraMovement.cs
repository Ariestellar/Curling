using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private float _smooth = 5.0f;
    private Vector3 _offset = new Vector3(0, 15, -10);

    private void FixedUpdate()
    {
        if (_target != null)
        {
            transform.position = Vector3.Lerp(transform.position, _target.position + _offset, Time.deltaTime * _smooth);
        }
    }
}