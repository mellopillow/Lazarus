using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public UIManager UI;
    public GameObject PauseMenu;
    private bool paused;
    public static GameManager instance = null;



    // Use this for initialization
    void Start () {
        //PauseMenu.gameObject.SetActive(false);

        Debug.Log("Start");
        //Check for AudioManager
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        //Use if you don't want to destroy between scenes.
        DontDestroyOnLoad(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
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
        Debug.Log("set active");
    }

    public void Unpause()
    {
        Debug.Log("paused");
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
    }
}
