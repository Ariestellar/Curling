using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceIndicator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _arrowSprites;

    private void Awake()
    {
        _arrowSprites = GetComponentsInChildren<SpriteRenderer>();
    }

    public void ShowArrow()
    {
        this.gameObject.SetActive(true);
    }

    public void HideArrow()
    {
        this.gameObject.SetActive(false);
    }

    public void SetColorArrow(int pullingForce)
    {
        for (int i = 0; i < _arrowSprites.Length; i++)
        {
            if (pullingForce >= i)
            {
                _arrowSprites[i].color = Color.red;
            }
            else
            {
                _arrowSprites[i].color = Color.white;
            }
        }
    }
}
