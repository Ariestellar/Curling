using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DropDownLevel : MonoBehaviour
{

    private Dropdown _listLevel;

    private void Awake()
    {
        _listLevel = GetComponent<Dropdown>();
    }
    public void Changed()
    {
        SceneManager.LoadScene("Level" + _listLevel.value);
    }
}
