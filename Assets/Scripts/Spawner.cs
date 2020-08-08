using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(GameSessionCurrentLevel))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabProjectile;    
    [SerializeField] private Transform _positionStartProjectile;    
    
    public void CreateProjectile(GameSessionCurrentLevel _gameSessionSurrentLevel)
    {
        GameObject projectile = Instantiate(_prefabProjectile, this.transform);
        projectile.transform.position = _positionStartProjectile.position;

        _gameSessionSurrentLevel.GetCameraMovement().SetTarget(projectile.transform);//При создании снаряда подменям таргет слежения у камеры
        _gameSessionSurrentLevel.TouchHandler.SetProjectile(projectile.GetComponent<Projectile>());
        projectile.GetComponent<Projectile>().Init(_gameSessionSurrentLevel);

        ProjectileFlight projectileFlight = projectile.GetComponent<ProjectileFlight>();

        projectileFlight.FinishFlight += _gameSessionSurrentLevel.IncreaseNumberProjectilePulling;
        projectileFlight.FinishFlight += _gameSessionSurrentLevel.CheckVictory;             
    }
}
