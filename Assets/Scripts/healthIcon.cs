using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthIcon : MonoBehaviour {
    private Transform transformRenderer;
    private string tagname;
    private Health health;
    
	// Use this for initialization
	void Start () {
        transformRenderer = GetComponent<Transform>();
        tagname = transformRenderer.tag;
        Debug.Log(tagname);
        health = GetComponent<Health>();
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TurnOff()
    {
        tagname = "health" + (health.currentHealth);
        Debug.Log(tagname);
        GameObject icon = GameObject.FindGameObjectWithTag(tagname);
        icon.gameObject.SetActive(false);
    }
}
