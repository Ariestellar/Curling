using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private UIPanel _uiPanel;
    private int numberProjectilePulling;

    public int NumberProjectilePulling => numberProjectilePulling;

    private CameraMovement _mainCameraMovement;

    private void Awake()
    {
        _mainCameraMovement = _mainCamera.GetComponent<CameraMovement>();
    }

    public void IncreaseNumberProjectilePulling()
    {
        numberProjectilePulling += 1;
        _uiPanel.SetColorLifePanel(numberProjectilePulling);
    }

    public CameraMovement GetCameraMovement()
    {
        return _mainCameraMovement;
    }

    public Camera GetMainCamera()
    {
        return _mainCamera;
    }
}
