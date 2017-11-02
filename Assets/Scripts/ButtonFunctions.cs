﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour {

    //public GameObject GameManager;

    // Start button
    public void Continue()
    {
        
        SceneManager.LoadScene(1);
    }

    // goes back to main menu
    public void Exit()
    {
        SceneManager.LoadScene(0);
        
    }

    // For eventual pause button
    public void Resume()
    {
        
    }
    public void LoadByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
}
