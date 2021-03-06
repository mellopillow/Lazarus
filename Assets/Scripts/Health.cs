﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;
    public bool dead;

	void Start(){
		currentHealth = maxHealth;
		dead = false;
        currentHealth = maxHealth;
	}

	public void takeDamage(int damageDone)
	{
		if (!dead)
		{
			
			print("taking damage: " + damageDone);
			currentHealth -= damageDone;
			if (currentHealth <= 0)
			{
				currentHealth = 0;
				dead = true;
                if(maxHealth == 10)
                {
                    LevelManager level = GameObject.FindObjectOfType<LevelManager>();
                    level.LoadLevel("EndScreen");
                    
                }
			}
		}
		else
		{	
			print("Cant take Damage, this entity has no health");
		}
	}

	public void healDamage(int healingDone)
	{

		currentHealth += healingDone;
		if (currentHealth >= maxHealth)
		{
			currentHealth = maxHealth;
		}
	}
}
