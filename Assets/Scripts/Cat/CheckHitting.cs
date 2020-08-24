using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHitting : MonoBehaviour
{
    [SerializeField] private bool _hittingZone;
    [SerializeField] private ColorTarget _colorTarget;

    public ColorTarget ColorTarget => _colorTarget;
    public bool HittingZone => _hittingZone;

    public void Init(int colorTarget)
    {
        _colorTarget = (ColorTarget)colorTarget;
    }

    public void SetHittingZone(bool value)
    {
        _hittingZone = value;
    }
}
