using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	int scientistSpawnTimer = 5;
	int flyingEnemySpawnTimer = 5;
	int turretSpawnTimer = 15;
	// Use this for initialization

	public int getScientistSpawnTimer(){

		return scientistSpawnTimer;

	}

	public int getFlyingEnemySpawnTimer(){

		return flyingEnemySpawnTimer;

	}

	public int getTurretSpawnTimer(){

		return turretSpawnTimer;

	}

	void Start () {

		GameObject[] scientistSpawns = GameObject.FindGameObjectsWithTag("ScientistSpawn");
		GameObject[] flyingEnemySpawns = GameObject.FindGameObjectsWithTag("FlyingEnemySpawn");
		GameObject[] turretSpawns = GameObject.FindGameObjectsWithTag("TurretSpawn");

		Transform scientistSpawnPoint, flyingEnemySpawnPoint, turretSpawnPoint = null;

		if (scientistSpawns.Length != 0) {

			for (int i = 0; i < scientistSpawns.Length; i++) {

				scientistSpawnPoint = scientistSpawns [i].transform;
				scientistSpawns [i].transform.position = scientistSpawnPoint.position;

			}
		
		}

		if (flyingEnemySpawns.Length != 0) {

			for (int i = 0; i < flyingEnemySpawns.Length; i++) {

				flyingEnemySpawnPoint = flyingEnemySpawns [i].transform;
				flyingEnemySpawns [i].transform.position = flyingEnemySpawnPoint.position;

			}

		}

		if (turretSpawns.Length != 0) {

			for (int i = 0; i < turretSpawns.Length; i++) {

				turretSpawnPoint = turretSpawns [i].transform;
				turretSpawns [i].transform.position = turretSpawnPoint.position;

			}

		}
		/*
		if (ItemScript.spawnlocation == 0) {
			startpoint = GameObject.Find ("startpoint0").transform;
		}
		if (ItemScript.spawnlocation == 1) {
			Debug.Log ("1");
			startpoint = GameObject.Find ("startpoint1").transform;
		}
		else if (ItemScript.spawnlocation == 2) {
			Debug.Log ("2");
			startpoint = GameObject.Find ("startpoint2").transform;
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
