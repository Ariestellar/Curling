﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    [SerializeField] private GameSessionCurrentLevel _gameSessionCurrentLevel;
    [SerializeField] private GameObject _lifePanel;    
    [SerializeField] private ResultPanel _resultPanel;     
    [SerializeField] private TouchHandler _touchHandler;
    [SerializeField] private GameObject _brifing;
    [SerializeField] private GameObject _buttonMainMenu;
    [SerializeField] private GameObject _tutor;

    private Image[] _lifeImages; 

    private void Awake()
    {
        _lifeImages = _lifePanel.GetComponentsInChildren<Image>();             
    }

    public void SetColorLifePanel(int countLife)//Отрефакторить решение в лоб
    {
        for (int i = 1; i < _lifeImages.Length; i++)
        {
            if (countLife >= i)
            {
                _lifeImages[i].color = Color.red;
            }
            else 
            {
                _lifeImages[i].color = Color.white;
            }
        }
    }
    public void ShowResultPanel(StateGame stateGame)
    {
        _resultPanel.Show(stateGame);
        _resultPanel.gameObject.SetActive(true);
    }

    public void ShowBrifing()
    {
        _brifing.SetActive(true);
    }

    public void ShowLifePanel()
    {
        _lifePanel.SetActive(true);
    }

    public void HideResultPanel()
    {
        _resultPanel.gameObject.SetActive(false);
    }

    public void HideButtonMainMenu()
    {
        _buttonMainMenu.GetComponent<Animator>().enabled = true;
        _tutor.SetActive(false);
    }

    public void ButtonContinueLevel()
    {
        _gameSessionCurrentLevel.ContinueLevel();
    }

    public void ButtonResetLevel()
    {
        _gameSessionCurrentLevel.ResetLevel();
    }

    public TouchHandler GetTouchHandler()
    {
        return _touchHandler;
    }
}
