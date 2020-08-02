using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    [SerializeField] private StartLevel _startLevel;
    [SerializeField] private int numberProjectilePulling;

    public void IncreaseNumberProjectilePulling()
    {
        numberProjectilePulling += 1;
        _startLevel.CreateProjectile();
    }
}
