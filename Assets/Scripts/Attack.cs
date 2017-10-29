using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Attack : PhysicsObject {

    public bool attacking = false;

    private float attack = 0f;
    private float attackCooldown = 0.3f;

    public Collider2D attackTriggerRight;

    void Awake()
    {
        attackTriggerRight.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !attacking)
        {
            print(SceneManager.sceneCount);
            attacking = true;
            attack = attackCooldown;

            attackTriggerRight.enabled = true;
        }
        if(attacking)
        {
            if(attack > 0)
            {
                attack -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTriggerRight.enabled = false;
            }
        }
    }
}
