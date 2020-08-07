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

    public void OnBeginDrag(PointerEventData eventData)
    {
        _startTouch = eventData.position;
        _currentArrow = Instantiate(_arrowPrefab, _startTouch, Quaternion.identity, transform);
        _currentArrowImage = _currentArrow.GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        _endTouch = eventData.position;        
        Vector2 heading = _startTouch -_endTouch;
        _distance = heading.magnitude;
        if (_distance != 0)
        {
            var _direction = heading / _distance;
            _currentArrow.transform.right = _direction;
        }
        _currentArrowImage.fillAmount = _distance / 1000;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        Destroy(_currentArrow);
    }
}
