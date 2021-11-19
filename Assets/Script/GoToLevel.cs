using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToLevel : MonoBehaviour
{
    public Button LevelButton;
    public int IndexScene;
    public float time;
    public Fader fader;
    

    private void Start()
    {
        Fader fader = FindObjectOfType<Fader>();
        LevelButton.onClick.AddListener(StartLevel);
    }

    private void StartLevel()
    {
        fader.StartTransition(IndexScene,time);
    }




}
