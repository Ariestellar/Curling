using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    [SerializeField] private GameSessionCurrentLevel _gameSessionCurrentLevel;
    [SerializeField] private GameObject _lifePanel;
    [SerializeField] private GameObject _ratingPanel;
    [SerializeField] private ResultPanel _resultPanel; 
    [SerializeField] private Text _levelText;
    [SerializeField] private TouchHandler _touchHandler;

    private Image[] _lifeImages;
    private Image[] _ratingImages;
    

    private void Awake()
    {
        _lifeImages = _lifePanel.GetComponentsInChildren<Image>();
        _ratingImages = _ratingPanel.GetComponentsInChildren<Image>();        
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

    public void SetColorRatingPanel(int countRating)//Отрефакторить решение в лоб
    {
        for (int i = 1; i < _ratingImages.Length; i++)
        {
            if (countRating >= i)
            {
                _ratingImages[i].color = Color.white;
            }
            else
            {
                _ratingImages[i].color = Color.black;
            }
        }
    }

    public void ShowResultPanel(StateGame stateGame)
    {
        _resultPanel.Show(stateGame);
        _resultPanel.gameObject.SetActive(true);
    }

    public void HideResultPanel()
    {
        _resultPanel.gameObject.SetActive(false);
    }

    public void UpdateTextLevel(int currentLevel)
    {
        _levelText.text = currentLevel + " level";
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
