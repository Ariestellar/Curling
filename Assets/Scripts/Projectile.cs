using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] private Indicators _indicators;    
    
    private Vector3 _startPositionMouse;
    private CameraMovement _cameraMovement;
    private Camera _camera;
    private Rigidbody _rigidbody;
    private bool _isMissileflight;
    private int _pullingForce;
    private float _previousPosition;
    private GameManager _gameManager;

    private void Awake()
    {        
        _rigidbody = GetComponent<Rigidbody>();        
    }

    private void FixedUpdate()
    {
        //Проверям остановку снаряда после запуска
        if (_isMissileflight)
        {   
            if (transform.position.z == _previousPosition)
            {                
                _isMissileflight = false;
                _cameraMovement.ReturnPosition();//возвращаем камеру на место
                this.enabled = false;//выключаем этот класс за ненадобностью 
                _gameManager.IncreaseNumberProjectilePulling();
            }
            _previousPosition = transform.position.z;
        }
    }

    public void Init(Camera camera, GameManager gameManager)
    {
        _gameManager = gameManager;
        //Кешируем ссылку на камеру и класс ее движения для снаряда
        _camera = camera;
        _cameraMovement = _camera.GetComponent<CameraMovement>();
        //Устанавливаем ссылку на снаряд для дальнейшего использования позже        
        _cameraMovement.SetTarget(transform);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Включаем "стрелки вокруг снаряда"
        _indicators.Show();
        
        //Записываем начальное положение снаряда
        _startPositionMouse = _camera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 10));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //выключаем "стрелки вокруг снаряда"
        _indicators.Hide();
        //если сила запуска не равна нулю тогда применяем ее к снаряду умножая на 500 
        if (_pullingForce != 0)
        {
            _rigidbody.AddForce(transform.forward * _pullingForce * 500);
            //Снаряд запущенн, состояние для проверки окончания его полета
            _isMissileflight = true;
            //включаем скрипт слежения камеры что бы проследила за снарядом во время полета
            _cameraMovement.ForProjectile();
        }      
    }

    public void OnDrag(PointerEventData eventData)
    {        
        //Создаем объект из позиции снаряда 
        Vector3 endPositionMouse = _camera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 10));
        _pullingForce = (int)Vector3.Distance(_startPositionMouse, endPositionMouse);

        _indicators.ForceIndicator.SetColorArrow(_pullingForce);

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
