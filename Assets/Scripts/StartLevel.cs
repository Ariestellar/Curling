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
        _gameManager.GetCameraMovement().SetTarget(projectile.transform);
        projectile.GetComponent<Projectile>().Init(_gameManager);
        projectile.GetComponent<ProjectileFlight>().FinishFlight += _gameManager.IncreaseNumberProjectilePulling;
        projectile.GetComponent<ProjectileFlight>().FinishFlight += _gameManager.GetCameraMovement().ReturnPosition;
    }
}
