using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	GameObject player;
	private string levelName = "";
	public GameObject spawn;
	public GameObject deathParticle;
	public float respawnDelay;
    private Vector3 spawnLocation;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
        setSpawn();
	}


	public void LoadLevel(string name)
    {
        levelName = name;
        StartCoroutine("Load");
        
        
    }
    IEnumerator Load()
    {
        yield return new WaitForSeconds(.4f);
        Debug.Log("Load");
        

        float fadeTime = GetComponent<Fade>().BeginFade(1);

        yield return new WaitForSeconds(.4f);



        SceneManager.LoadScene(levelName);
    }
    public void QuitRequest()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

	public void RespawnPlayer(){
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo(){

		Instantiate (deathParticle, player.transform.position, player.transform.rotation);
		AudioManager.instance.soundfx (8, 0.9f);
		player.SetActive (false);
		player.GetComponent<Renderer> ().enabled = false;
		yield return new WaitForSeconds (respawnDelay);
        player.transform.position = spawn.transform.position;
		player.SetActive (true);
        player.GetComponent<Health>().currentHealth = player.GetComponent<Health>().maxHealth;
        player.GetComponent<Health> ().dead = false;
        player.GetComponent<BoxCollider2D>().size = new Vector2(7.78f, 13.17f);
        Debug.Log(player.GetComponent<BoxCollider2D>().size);
        turnOnHealth();


	}

    public void turnOnHealth()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject healthbar = GameObject.FindGameObjectWithTag("health" + i);
            healthbar.GetComponent<healthIcon>().TurnOn();
        }
    }

    public void setNewSpawn(Vector3 spawnPosition)
    {
        spawnLocation = spawnPosition;   
    }

    public void setSpawn()
    {
        spawnLocation = spawn.transform.position;
    }
    
}
