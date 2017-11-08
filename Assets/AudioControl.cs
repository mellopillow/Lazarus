using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void playSfx1()
    {
        AudioManager.instance.playSFX1();
    }

    public void playSfx2()
    {
        AudioManager.instance.playSFX2();
    }
}
