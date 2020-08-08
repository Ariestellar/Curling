using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Vector2 _startTouch;
    [SerializeField] private Vector2 _endTouch;
    [SerializeField] private float _distance;
    [SerializeField] private GameObject _arrowPrefab;

    private GameObject _currentArrow;
    private Image _currentArrowImage;
    private int _pullingForce;
    private Projectile _currentProjectile;

    public void SetProjectile(Projectile currentProjectile)
    {
        _currentProjectile = currentProjectile;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_currentProjectile != null)
        {
            _currentProjectile.PreparationForLaunch();
            _startTouch = eventData.position;
            _currentArrow = Instantiate(_arrowPrefab, _startTouch, Quaternion.identity, transform);
            _currentArrowImage = _currentArrow.GetComponent<Image>();
        }        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_currentProjectile != null)
        {
            _endTouch = eventData.position;
            Vector2 target = _startTouch -_endTouch;
            
            float angleBetween = Vector2.SignedAngle(target.normalized, Vector2.up);
            Debug.Log(angleBetween);

            _distance = target.magnitude;
            if (_distance != 0)
            {
                var _direction = target / _distance;
                _currentArrow.transform.right = _direction;

                _currentProjectile.RotateForwardDirection(angleBetween);//сравнить угол и врaщать по Y оси                
            }
            _currentArrowImage.fillAmount = _distance / 1000;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        if (_currentProjectile != null)
        {
            _pullingForce = (int)(_currentArrowImage.fillAmount * 10);
            if (_pullingForce != 0)
            {
                _currentProjectile.Launch(_pullingForce);
                _currentProjectile = null;
            }
            Destroy(_currentArrow);
        }        
    }
}
