﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataGame
{
    public static int currentLevel = 1;
    public static bool isMainMenu = true;

    public static void LevelUp()
    {
        currentLevel += 1;
    }
}
