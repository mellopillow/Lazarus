using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthIcon : MonoBehaviour {
    private Transform transformRenderer;
    private string tagname;
    private Animation anim;
    //private Health health;
    
	// Use this for initialization
	void Start () {
        transformRenderer = GetComponent<Transform>();
        tagname = transformRenderer.tag;
        Debug.Log(tagname);
        anim = GetComponent<Animation>();
        //health = GetComponent<Health>();
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TurnOff()
    {
        //tagname = "health" + (health.currentHealth);
        //Debug.Log(tagname);
        //GameObject icon = GameObject.FindGameObjectWithTag(tagname);
        transformRenderer.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void playAnimation()
    {
        anim.Play();
    }

    public void TurnOn()
    {
        Debug.Log("Im TURNING ON");
        transformRenderer.GetComponent<SpriteRenderer>().enabled = true;
        transformRenderer.GetComponent<SpriteRenderer>().color = Color.white;
        anim.Play("turnOn");
        //transformRenderer.GetComponent<SpriteRenderer>().enabled = true;
    }
}
