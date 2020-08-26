using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestPanel : MonoBehaviour
{
    [SerializeField] private Dropdown _listLevel;

    private void Start()
    {
        //_listLevel.captionText.text = Convert.ToString(DataGame.currentLevel);
        Debug.Log(DataGame.currentLevel);
    }

    public void ChangedLevel()
    {
        DataGame.currentLevel = _listLevel.value + 1;
        SceneManager.LoadScene("Level" + DataGame.currentLevel);
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        DataGame.currentLevel = 1;
        SceneManager.LoadScene(0);
    }
}
