using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public GameManager GM;
    
    GameObject SceneText;
    GameObject GameText;


	// Use this for initialization
	void Start () {
        

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
