using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestPanel : MonoBehaviour
{
    [SerializeField] private Dropdown _listLevel;     

    public void ChangedLevel()
    {
        DataGame.currentLevel = _listLevel.value;
        SceneManager.LoadScene("Level" + DataGame.currentLevel);
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        DataGame.currentLevel = 1;
        SceneManager.LoadScene(0);
    }
}
