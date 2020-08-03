using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private UIPanel _uiPanel;

    private int _numberProjectilePulling;
    private int _numberProjectileAtTarget;

    public int NumberProjectilePulling => _numberProjectilePulling;

    private CameraMovement _mainCameraMovement;

    private void Awake()
    {
        _mainCameraMovement = _mainCamera.GetComponent<CameraMovement>();
    }

    public void IncreaseNumberProjectilePulling()
    {
        _numberProjectilePulling += 1;
        _uiPanel.SetColorLifePanel(_numberProjectilePulling);
    }

    public void IncreaseNumberProjectileAtTarget()
    {
        _numberProjectileAtTarget += 1;
        _uiPanel.SetColorRatingPanel(_numberProjectileAtTarget);
        if (_numberProjectileAtTarget == 2)
        {
            Victory();
        }
    }

    public void ReduceNumberProjectileAtTarget()
    {
        _numberProjectileAtTarget -= 1;
        _uiPanel.SetColorRatingPanel(_numberProjectileAtTarget);
    }

    public CameraMovement GetCameraMovement()
    {
        return _mainCameraMovement;
    }

    public Camera GetMainCamera()
    {
        return _mainCamera;
    }

    public void Defeat()
    {
        _uiPanel.ShowResultPanel("Defeat");
    }

    public void Victory()
    {
        _uiPanel.ShowResultPanel("Victory");
    }

    public void ResetData()
    {
        _numberProjectilePulling = 0;
        _numberProjectileAtTarget = 0;
        _uiPanel.SetColorLifePanel(_numberProjectilePulling);
        _uiPanel.SetColorRatingPanel(_numberProjectileAtTarget);
        _uiPanel.HideResultPanel();
    }
}
