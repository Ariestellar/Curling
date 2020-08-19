﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLauncher : MonoBehaviour
{    
    private void Start()
    {
        DataGame.currentLevel = DataGame.LoadGame();
        SceneManager.LoadScene("Level" + DataGame.currentLevel);
    }
}
