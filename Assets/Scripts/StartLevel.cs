using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    [SerializeField] private GameObject _prefabProjectile;
    [SerializeField] private GameManager _gameManager;
       
    private void Start()
    {
        CreateProjectile();
    }

    public void CreateProjectile()
    {
        GameObject projectile =  Instantiate(_prefabProjectile);
        projectile.transform.position = transform.position;

        _gameManager.GetCameraMovement().SetTarget(projectile.transform);//При создании снаряда подменям таргет слежения у камеры
        projectile.GetComponent<Projectile>().Init(_gameManager);
        ProjectileFlight projectileFlight = projectile.GetComponent<ProjectileFlight>();

        projectileFlight.FinishFlight += _gameManager.IncreaseNumberProjectilePulling;
        projectileFlight.FinishFlight += _gameManager.GetCameraMovement().ReturnPosition;        
        projectileFlight.FinishFlight += CreateProjectile;
    }
}
