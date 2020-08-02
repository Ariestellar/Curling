using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    [SerializeField] private GameObject _prefabProjectile;
    [SerializeField] private GameManager _gameManager;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        CreateProjectile();
    }

    public void CreateProjectile()
    {
        GameObject projectile =  Instantiate(_prefabProjectile);
        projectile.transform.position = transform.position;
        projectile.GetComponent<Projectile>().Init(_camera, _gameManager);
    }
}
