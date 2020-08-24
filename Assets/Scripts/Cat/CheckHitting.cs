using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHitting : MonoBehaviour
{
    [SerializeField] private bool _hittingZone;
    public bool HittingZone => _hittingZone;

    public void SetHittingZone(bool value)
    {
        _hittingZone = value;
    }
}
