using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTrigger : MonoBehaviour
{
    [SerializeField] private GameSessionCurrentLevel _gameManager;
    private void OnTriggerEnter(Collider other)
    {
        _gameManager.IncreaseNumberProjectileAtTarget();               
    }

    private void OnTriggerExit(Collider other)
    {
        _gameManager.ReduceNumberProjectileAtTarget();
    }
}
