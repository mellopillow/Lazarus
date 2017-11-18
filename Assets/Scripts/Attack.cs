using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Attack : PlayerPlatformerController {

    public bool attacking = false;

    private float attack = 0f;
    private float attackCooldown = .5f;
    private bool sprite;

    public Collider2D attackTriggerRight;
    public Collider2D attackTriggerLeft;

    void Awake()
    {
        attackTriggerRight.enabled = false;
        attackTriggerLeft.enabled = false;
        
    }
    void FixedUpdate()
    {
        GameObject.Find("charAttTrigger").GetComponent<Transform>().position = GameObject.Find("char").GetComponent<Transform>().position;
    }
    void Update()
    {
        sprite = GameObject.Find("char").GetComponent<SpriteRenderer>().flipX;
        print(sprite);
        if (Input.GetKeyDown(KeyCode.C) && !attacking && !sprite)
        {
            
            attacking = true;
            attack = attackCooldown;

            attackTriggerRight.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.C) && !attacking && sprite)
        {
            
            attacking = true;
            attack = attackCooldown;

            attackTriggerLeft.enabled = true;
        }
        if (attacking)
        {
            if(attack > 0)
            {
                attack -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTriggerRight.enabled = false;
                attackTriggerLeft.enabled = false;
            }
        }
    }
}
