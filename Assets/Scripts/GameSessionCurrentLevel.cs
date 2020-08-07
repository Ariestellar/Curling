using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum StateGame
{
    Victory,
    Defeat,
    EndDemo
}
[RequireComponent(typeof(Spawner))]
public class GameSessionCurrentLevel: MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private UIPanel _uiPanel;

    private StateGame _stateGame;    
    private CanvasScaler _canvasScaler;    
    private int _numberProjectilePulling;
    private int _numberProjectileAtTarget;
    private CameraMovement _mainCameraMovement;
    private Spawner _spawner;
    private Projectile[] _currentProjectile;

    public StateGame StateLevel => _stateGame;
    public int NumberProjectilePulling => _numberProjectilePulling;    

    private void Awake()
    {
        _canvasScaler = _uiPanel.GetComponent<CanvasScaler>();
        _mainCameraMovement = _mainCamera.GetComponent<CameraMovement>();
        _spawner = GetComponent<Spawner>();
    }

    void Start()
    {
        if (Screen.width <= 480)
        {
            _canvasScaler.scaleFactor = 1;
        } 
        else if (Screen.width <= 750)
        {
            _canvasScaler.scaleFactor = 2;
        }
        else if (Screen.width <= 1080)
        {
            _canvasScaler.scaleFactor = 3;
        }
        ResetLevel();
    }

    public void ResetLevel()
    {
        ResetData(DataGame.currentLevel);
        _currentProjectile = GetComponentsInChildren<Projectile>();
        if (_currentProjectile != null)
        {
            foreach (var projectile in _currentProjectile)
            {
                Destroy(projectile.gameObject);
            }
        }
        
        _spawner.CreateProjectile(this);
    }

    public void ContinueLevel()
    {
        if (StateLevel == StateGame.Victory && SceneManager.sceneCountInBuildSettings > DataGame.currentLevel)
        {
            DataGame.LevelUp();
            SceneManager.LoadScene("Level_" + DataGame.currentLevel);            
        }
        else
        {
            ResetLevel();
        }
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

    private void Defeat()
    {
        _stateGame = StateGame.Defeat;
        _uiPanel.ShowResultPanel(_stateGame);
    }

    private void Victory()
    {
        _stateGame = StateGame.Victory;
        _uiPanel.ShowResultPanel(_stateGame);
    }

    public void  CheckVictory()
    {
        if (_numberProjectileAtTarget >= 2)
        {           
            Victory();
        }
        else if(_numberProjectilePulling == 4)
        {            
            Defeat();
        }
        else
        {
            _mainCameraMovement.ReturnPosition();
            _spawner.CreateProjectile(this);            
        }
    }    

    public void ResetData(int currentLevel)
    {
        _mainCameraMovement.ReturnPosition();
        _numberProjectilePulling = 0;
        _numberProjectileAtTarget = 0;
        _uiPanel.SetColorLifePanel(_numberProjectilePulling);
        _uiPanel.SetColorRatingPanel(_numberProjectileAtTarget);
        _uiPanel.UpdateTextLevel(currentLevel);
        _uiPanel.HideResultPanel();
    }
}
