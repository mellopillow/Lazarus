using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer music = null;

    void Awake()
    {
        Debug.Log("Music player awake " + GetInstanceID());
        if (music != null)
        {
            Destroy(gameObject);
        }
        else
        {
            music = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start() {
        Debug.Log("Music player start " + GetInstanceID());
        
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
