using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazorScript : MonoBehaviour {

    public LazorState lazorState;

	public float beamDelayMax= 4f;
	public float beamDelay;

	public float beamOffing = .25f;
	public float beamOff;
	public bool beamFiring;

	public Sprite lazor;
	public Sprite warning;

    public SpriteRenderer sprite;
    public Collider2D lazerRange;
    public Damage damage;

	// Use this for initialization
	void Start () 
	{
		sprite = GetComponent<SpriteRenderer>();
		lazerRange = GetComponent<Collider2D>();
		damage = GetComponent<Damage>();
		lazorState = LazorState.Dormant;
	}

	public void fireBeam()
	{
	    switch (lazorState)
	    {
	        case LazorState.Ready:
	        	sprite.sprite = warning;
	        	lazerRange.enabled = false;
	            lazorState = LazorState.Firing;
	            beamFiring = true;
	            beamDelay = beamDelayMax;
	            break;

	        case LazorState.Firing:
	            beamDelay -= Time.deltaTime;
	        	sprite.enabled = true;
	        	
	            if (beamDelay <= 0)
	            {

	              	lazerRange.enabled = true;
	                beamDelay = 0;

	                lazorState = LazorState.Off;
	                beamFiring = false;
	                beamOff = beamOffing;
	            }
	            break;

	        case LazorState.Off:
	        	beamOff -= Time.deltaTime;
	        	sprite.sprite = lazor;
	        	if (beamOff <= 0)
	        	{
	              	sprite.enabled = false;
	        		lazerRange.enabled = false;
	        		lazorState = LazorState.Dormant;
	        	}
	        	break;
		}
    }
}

public enum LazorState
{
    Ready,
    Firing,
    Dormant,
    Off
}