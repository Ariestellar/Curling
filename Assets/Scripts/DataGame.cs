using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataGame
{
    public static int currentLevel;
    public static bool isMainMenu = true;

    public static void LevelUp()
    {
        currentLevel += 1;
        SaveGame(currentLevel);
    }

    public static void SaveGame(int currentLevel)
    {
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
    }

    public static int LoadGame()
    {
        return PlayerPrefs.GetInt("CurrentLevel", 1);
    }
}
