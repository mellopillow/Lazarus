using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazorScript : MonoBehaviour {

    public LazorState lazorState;

	public float beamDelayMax= 3f;
	public float beamDelay;
	public float beamDamage;

	public bool playerInRange;
	public bool beamFiring;

	// Use this for initialization
	void Start () 
	{
		beamFiring = false;
		playerInRange = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		fireBeam();
	}

	void fireBeam()
	{
		if (playerInRange)
		{
	        switch (lazorState)
	        {
		        case LazorState.Ready:
		            print("firing!");
		            lazorState = LazorState.Firing;
		            beamFiring = true;
		            beamDelay = beamDelayMax;
		            break;

		        case LazorState.Firing:

		            beamDelay -= Time.deltaTime;
		            if (beamDelay <= 0)
		            {
		              	print("Dealing damage to everything in my range!");
		                beamDelay = 0;
		                lazorState = LazorState.Ready;
		                
		                playerInRange = false;
		                beamFiring = false;
		            }
		            break;
		    }
        }
	}
}

public enum LazorState
{
    Ready,
    Firing
}