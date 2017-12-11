using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour {

    public LevelManager levelManager;
    private BoxCollider2D box;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
        box = GetComponent<BoxCollider2D>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            levelManager.spawn = gameObject;
            box.enabled = false;
        }
    }
}
