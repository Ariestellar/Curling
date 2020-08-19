using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] private Image _imageResultPanel;
    [SerializeField] private Sprite _imageDefeat;
    [SerializeField] private Sprite _imageVictory;
    [SerializeField] private Text _resultText;

    public void Show(StateGame stateGame)
    {
        if (SceneManager.sceneCountInBuildSettings > DataGame.currentLevel)
        {
            if (stateGame == StateGame.Victory)
            {
                _imageResultPanel.sprite = _imageVictory;
                _resultText.text = "Victory";
            }
            else if (stateGame == StateGame.Defeat)
            {
                _imageResultPanel.sprite = _imageDefeat;
                _resultText.text = "Defeat";
            }
        }
        else
        {
            _resultText.text = "End demo :(";
        }
    }
}
