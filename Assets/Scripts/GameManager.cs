using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //public UIManager UI;
    public GameObject PauseMenu;
    public GameObject InGameMenu;
    private bool paused;
    
    

    void Start()
    {
        Debug.Log("Start");
        Time.timeScale = 1;
        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "Main_Menu")
        {
            AudioManager.instance.StopMusic();
            AudioManager.instance.PlayMusicSource();
        }
    }
    // Use this for initialization
    
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene().name != "Emil")
        {
            ScanForKeyStroke();
        }
	}

    

    public void TogglePauseMenu()
    {
        if (paused)
        {
            paused = false;
            Pause();
        }
        else
        {
            paused = true;
            Unpause();
        }
    }

    public void Pause()
    {
        Debug.Log("paused");
        Time.timeScale = 0;

        PauseMenu.SetActive(true);
        InGameMenu.SetActive(false);
        Debug.Log("set active");
    }

    public void Unpause()
    {
        Debug.Log("unpaused");
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        InGameMenu.SetActive(true);
    }

    void ScanForKeyStroke()
    {
    if (Input.GetKeyDown("escape")){
        TogglePauseMenu();
       }
    }
}
