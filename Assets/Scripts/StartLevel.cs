﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(GameManager))]
public class StartLevel : MonoBehaviour
{
    [SerializeField] private GameObject _prefabProjectile;    
    [SerializeField] private Transform _positionStartProjectile;
        
    private int _currentLevel;
    private GameManager _gameManager;
    private Projectile[] _currentProjectile;

    private void Awake()
    {
        _gameManager = GetComponent<GameManager>();
    }

    private void Start()
    {
        _currentLevel = 1;
        CreateProjectile();
    }

    public void CreateProjectile()
    {
        if (_gameManager.NumberProjectilePulling != 4)
        {
            GameObject projectile = Instantiate(_prefabProjectile, this.transform);
            projectile.transform.position = _positionStartProjectile.position;

            _gameManager.GetCameraMovement().SetTarget(projectile.transform);//При создании снаряда подменям таргет слежения у камеры
            projectile.GetComponent<Projectile>().Init(_gameManager);
            ProjectileFlight projectileFlight = projectile.GetComponent<ProjectileFlight>();

            projectileFlight.FinishFlight += _gameManager.IncreaseNumberProjectilePulling;
            projectileFlight.FinishFlight += _gameManager.GetCameraMovement().ReturnPosition;
            projectileFlight.FinishFlight += _gameManager.CheckVictory;
            projectileFlight.FinishFlight += CreateProjectile;
        }
        else
        {
            _gameManager.Defeat();
        }        
    }

    public void ResetLevel()
    {
        _gameManager.ResetData(_currentLevel);
        _currentProjectile = GetComponentsInChildren<Projectile>();
        foreach (var projectile in _currentProjectile)
        {
            Destroy(projectile.gameObject);
        }
        CreateProjectile();
    }

    public void ContinueLevel()
    {
        if (_gameManager.StateLevel == StateGame.Victory)
        {
            _currentLevel += 1;
            ResetLevel();
        }
        else
        {
            ResetLevel();
        }
    }
}
