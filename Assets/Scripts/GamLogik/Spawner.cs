using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(GameSessionCurrentLevel))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabProjectile;    
    [SerializeField] private Transform _positionStartProjectile;    
    [SerializeField] private Material[] _materialsCats;    
    [SerializeField] private int _numberCat = 0;    
    
    public void CreateProjectile(GameSessionCurrentLevel _gameSessionSurrentLevel)
    {
        GameObject projectile = Instantiate(_prefabProjectile, this.transform);
        projectile.transform.position = _positionStartProjectile.position;

        _gameSessionSurrentLevel.GetCameraMovement().SetTarget(projectile.transform);//При создании снаряда подменям таргет слежения у камеры
        _gameSessionSurrentLevel.TouchHandler.SetProjectile(projectile.GetComponent<Projectile>());
        projectile.GetComponent<Projectile>().Init(_gameSessionSurrentLevel);
        projectile.GetComponent<ChekClash>().Init(_gameSessionSurrentLevel.GetAudioManager());
        projectile.GetComponent<ColoringForCats>().SetMaterialSkin(_materialsCats[_numberCat]);
        _numberCat += 1;

        ProjectileFlight projectileFlight = projectile.GetComponent<ProjectileFlight>();

        projectileFlight.FinishFlight += _gameSessionSurrentLevel.IncreaseNumberProjectilePulling;
        projectileFlight.FinishFlight += _gameSessionSurrentLevel.CheckVictory;
    }
}
