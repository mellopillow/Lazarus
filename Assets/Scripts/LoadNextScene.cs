using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextScene : MonoBehaviour {
    public string levelToEnter = "";
    public int newLocation;

    private LevelManager levelManager;
    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        print("Trigger");
        startPoint.destination = newLocation;
        levelManager.LoadLevel(levelToEnter);
        
        
    }

    

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }
}
