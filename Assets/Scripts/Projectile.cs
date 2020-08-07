using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ProjectileFlight))]
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] private Indicators _indicators;
    [SerializeField] private int _pullingForce;

    private Vector3 _startPositionMouse;
    private CameraMovement _cameraMovement;
    private Camera _camera;
    private Rigidbody _rigidbody;       
    private ProjectileFlight _projectileMovement;

    private void Awake()
    {        
        _rigidbody = GetComponent<Rigidbody>();
        _projectileMovement = GetComponent<ProjectileFlight>();
    }

    public void Init(GameSessionCurrentLevel gameSessionCurrentLevel)
    {             
        _camera = gameSessionCurrentLevel.GetMainCamera();
        _cameraMovement = gameSessionCurrentLevel.GetCameraMovement();
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
            _rigidbody.AddForce(transform.forward * _pullingForce * 300);
            //Снаряд запущенн, состояние для проверки окончания его полета
            _projectileMovement.SetStateFlight(true);
            //включаем скрипт слежения камеры что бы проследила за снарядом во время полета
            _cameraMovement.ForProjectile();
            //Выключаем этот скрипт тк больше не нужен
            this.enabled = false;
        }      
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Создаем объект из позиции снаряда         
        Vector3 endPositionMouse = _camera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 10));

        _pullingForce = Mathf.Clamp((int)Vector3.Distance(_startPositionMouse, endPositionMouse), 0, 8);
        _indicators.ForceIndicator.SetColorArrow(_pullingForce);

        Vector3 heading = new Vector3(transform.position.x, transform.position.y, transform.position.z) - new Vector3(endPositionMouse.x, transform.position.y, endPositionMouse.z);
        var distance = heading.magnitude;        
        var _direction = heading / distance;
        transform.forward = _direction;
    }
}
