using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
	public int damage;

	public void Awake(){
		damage = 1;	
	}	
    public void setDamage(int amount)
    {
    	damage = amount;
    }
}
