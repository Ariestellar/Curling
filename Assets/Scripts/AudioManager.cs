using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _nya;
    [SerializeField] private AudioSource _clashWall;
    [SerializeField] private AudioSource _failed;
    [SerializeField] private AudioSource _victory;
    [SerializeField] private AudioSource _pulling;
    
    public void PlayNya()
    {
        _nya.Play();
    }

    public void PlayPulling()
    {
        _pulling.Play();
    }

    public void PlayVictory()
    {
        _victory.Play();
    }

    public void PlayFailed()
    {
        _failed.Play();
    }

    public void PlayClashWall()
    {
        _clashWall.Play();
    }
}
