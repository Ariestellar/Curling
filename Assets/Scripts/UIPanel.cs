using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    [SerializeField] private GameObject _lifePanel;
    [SerializeField] private Image[] _lifeImages;

    private void Awake()
    {
        _lifeImages = _lifePanel.GetComponentsInChildren<Image>();
    }

    public void SetColorLifePanel(int countLife)
    {
        for (int i = 0; i < _lifeImages.Length; i++)
        {
            if (countLife >= i)
            {
                _lifeImages[i].color = Color.white;
            }
        }
    }
}
