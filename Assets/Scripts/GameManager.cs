using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateGame
{
    Victory,
    Defeat
}

public class GameManager: MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private UIPanel _uiPanel;

    private StateGame _stateGame;    
    private int _numberProjectilePulling;
    private int _numberProjectileAtTarget;
    private CameraMovement _mainCameraMovement;

    public StateGame StateLevel => _stateGame;
    public int NumberProjectilePulling => _numberProjectilePulling;    

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
        _stateGame = StateGame.Defeat;
        _uiPanel.ShowResultPanel("Defeat");
    }

    public void Victory()
    {
        _stateGame = StateGame.Victory;
        _uiPanel.ShowResultPanel("Victory");
    }

    public void  CheckVictory()
    {
        if (_numberProjectileAtTarget == 2)
        {
            Victory();
        }
    }

    public void ResetData(int currentLevel)
    {        
        _numberProjectilePulling = 0;
        _numberProjectileAtTarget = 0;
        _uiPanel.SetColorLifePanel(_numberProjectilePulling);
        _uiPanel.SetColorRatingPanel(_numberProjectileAtTarget);
        _uiPanel.UpdateTextLevel(currentLevel);
        _uiPanel.HideResultPanel();
    }
}
