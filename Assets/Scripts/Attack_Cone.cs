﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Cone : MonoBehaviour {

    public TurretAI turretAI;

    public bool isLeft = false;

    // Use this for initialization
    private void Awake()
    {
        turretAI = gameObject.GetComponentInParent<TurretAI>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {

            if (isLeft)
            {

                turretAI.Attack(false);

            }
            else
            {

                turretAI.Attack(true);

            }

        }

    }
}
