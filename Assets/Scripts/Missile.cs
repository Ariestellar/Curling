using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Missile : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] private GameObject _directionArrow;
    [SerializeField] private GameObject _forceArrow;
    [SerializeField] private int _pullingForce;
    [SerializeField] private Vector3 _startPositionMouse;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _missle;
    [SerializeField] private CameraMovement _cameraMovement;
    [SerializeField] private SpriteRenderer[] _forceArrows;
    [SerializeField] private bool _isMissileflight;

    private void Awake()
    {
        _forceArrows = _forceArrow.GetComponentsInChildren<SpriteRenderer>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Включаем "стрелки вокруг снаряда"
        _directionArrow.SetActive(true);
        _forceArrow.SetActive(true);
        //Записываем начальное положение снаряда
        _startPositionMouse = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 10));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //выключаем "стрелки вокруг снаряда"
        _directionArrow.SetActive(false);
        _forceArrow.SetActive(false);
        //если сила запуска не равна нулю тогда применяем ее к снаряду умножая на 500 
        if (_pullingForce != 0)
        {
            _rigidbody.AddForce(_missle.forward * _pullingForce * 500);
            //Снаряд запущенн, состояние для проверки окончания его полета
            _isMissileflight = true;
            //включаем скрипт слежения камеры что бы проследила за снарядом во время полета
            _cameraMovement.enabled = true;
        }      
    }

    public void OnDrag(PointerEventData eventData)
    {        
        //Создаем объект из позиции снаряда 
        Vector3 endPositionMouse = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 10));
        _pullingForce = (int)Vector3.Distance(_startPositionMouse, endPositionMouse);
        for (int i = 0; i < _forceArrows.Length; i++)
        {
            if (_pullingForce >= i)
            {
                _forceArrows[i].color = Color.red;
            }
            else
            {
                _forceArrows[i].color = Color.white;
            }            
        }
        
        Vector3 heading = new Vector3(transform.position.x, transform.position.y, transform.position.z) - new Vector3(endPositionMouse.x, transform.position.y, endPositionMouse.z);
        var distance = heading.magnitude;        
        var _direction = heading / distance;
        transform.forward = _direction;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Снаряд попал");
    }
}
