using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour {

    

    GameObject SceneText;
    GameObject GameText;


    // Use this for initialization
   
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

    public void audio()
    {

        AudioManager.instance.playGameTheme();

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
