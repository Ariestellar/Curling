using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTrigger : MonoBehaviour
{
    [SerializeField] private GameSessionCurrentLevel _gameManager;
    private void OnTriggerEnter(Collider other)
    {
        _gameManager.IncreaseNumberProjectileAtTarget();
        if (other.gameObject.GetComponent<CheckHitting>())
        {
            other.gameObject.GetComponent<CheckHitting>().SetHittingZone(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _gameManager.ReduceNumberProjectileAtTarget();
        if (other.gameObject.GetComponent<CheckHitting>())
        {
            other.gameObject.GetComponent<CheckHitting>().SetHittingZone(false);
        }
    }
}
