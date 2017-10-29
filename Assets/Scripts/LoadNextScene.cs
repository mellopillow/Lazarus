using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextScene : MonoBehaviour {
    public string levelToEnter = "";

    private LevelManager levelManager;
    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        print("Trigger");
        levelManager.LoadLevel(levelToEnter);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Colision");
    }
}
