using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startPoint : MonoBehaviour {

    public static startPoint start = null;

    public static int destination = 1;

    // Use this for initialization
    void Awake () {
        if (start == null)
                start = this;
        else if (start != this)
            Destroy(this.gameObject);

        //Use if you don't want to destroy between scenes.
        DontDestroyOnLoad(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
