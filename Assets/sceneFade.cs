using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class sceneFade : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Animation>().Play("sceneText");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
