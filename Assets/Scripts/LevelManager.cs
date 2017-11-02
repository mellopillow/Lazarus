using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    private string levelName = "";
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
    
}
