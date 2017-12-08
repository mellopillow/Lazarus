using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCheckpoint : MonoBehaviour {

	public LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
		levelManager.spawn = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
