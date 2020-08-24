using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileFlight : MonoBehaviour
{
    private Action _finishFlight;    
    private bool _isFlight;
    private float _previousPosition;

    public bool IsFlight => _isFlight;

    public Action FinishFlight { get => _finishFlight; set => _finishFlight = value; }

    private void FixedUpdate()
    {
        //Проверям остановку снаряда после запуска
        if (_isFlight)
        {
            if (transform.position.z == _previousPosition)
            {
                FinishFlight?.Invoke();

                _isFlight = false;
                
                this.enabled = false;//выключаем этот класс за ненадобностью 

            }
            _previousPosition = transform.position.z;
        }
    }

    public void SetStateFlight(bool isFlight)
    {
        _isFlight = isFlight;
    }   

    private void OnDisable()
    {
        _finishFlight = null;
    }    
}
