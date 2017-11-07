using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public GameManager GM;
    public static UIManager instance = null;
    
    GameObject SceneText;
    GameObject GameText;


	// Use this for initialization
	void Awake () {
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
        ScanForKeyStroke();
	}

    void ScanForKeyStroke()
    {
        if (Input.GetKeyDown("escape"))
        {
            GM.TogglePauseMenu();
        }
    }
}
