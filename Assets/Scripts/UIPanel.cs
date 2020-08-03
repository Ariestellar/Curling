using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    [SerializeField] private GameObject _lifePanel;
    [SerializeField] private GameObject _ratingPanel;
    [SerializeField] private GameObject _resultPanel; 
    [SerializeField] private Text _levelText; 

    private Text _resultText;
    private Image[] _lifeImages;
    private Image[] _ratingImages;

    private void Awake()
    {
        _lifeImages = _lifePanel.GetComponentsInChildren<Image>();
        _ratingImages = _ratingPanel.GetComponentsInChildren<Image>();
        _resultText = _resultPanel.GetComponentInChildren<Text>();
    }

    public void SetColorLifePanel(int countLife)//Отрефакторить решение в лоб
    {
        for (int i = 1; i < _lifeImages.Length; i++)
        {
            if (countLife >= i)
            {
                _lifeImages[i].color = Color.white;
            }
            else 
            {
                _lifeImages[i].color = Color.red;
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

    public void ShowResultPanel(string result)
    {
        _resultText.text = result;
        _resultPanel.SetActive(true);
    }

    public void HideResultPanel()
    {
        _resultPanel.SetActive(false);
    }

    public void UpdateTextLevel(int currentLevel)
    {
        _levelText.text = currentLevel + " level";
    }
}
