using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Attack : PlayerPlatformerController {

    public bool attacking = false;
    public bool secondAttack = false;
    public Collider2D attackTriggerRight;
    public Collider2D attackTriggerLeft;

    private float attacks = 0f;
    private float attackCooldown = .4f;
    private bool sprite;
    private Animator attackanimator;
    
    void Awake()
    {
        attackanimator = GetComponent<Animator>();
        attackTriggerRight.enabled = false;
        attackTriggerLeft.enabled = false;
        
    }
    void FixedUpdate()
    {
        GameObject.Find("charAttTrigger").GetComponent<Transform>().position = GameObject.Find("char").GetComponent<Transform>().position;
        
    }
    void Update()
    {
        if (!attacking)
        {
            attackTriggerRight.enabled = false;
            attackTriggerLeft.enabled = false;
        }
        if (attacks > 0f)
        {
            attacks -= Time.deltaTime;
            Debug.Log(attacks);
            if (Input.GetKeyDown(KeyCode.C) && !secondAttack)
            {
                secondAttack = true;
            }

        }
        else
        {
            secondAttack = false;
        }
        sprite = GameObject.Find("char").GetComponent<SpriteRenderer>().flipX;
        attackanimator.SetBool("attacking", attacking);
        attackanimator.SetBool("secondattack", secondAttack);
        if (Input.GetKeyDown(KeyCode.C) && !attacking && !secondAttack)
        {
            attacks = attackCooldown;
            attacking = true;
            if(sprite)
            {
                attackTriggerLeft.enabled = true;
            }
            else
            {
                attackTriggerRight.enabled = true;
            }
            
        }
        
        
    }
    void Attacking()
    {
        if (!secondAttack)
        {
            attacking = false;
        }
        attackTriggerRight.enabled = false;
        attackTriggerLeft.enabled = false;
        
    }
    void SecondAttack()
    {
       
            attacks = 0f;
            if (sprite)
            {
                attackTriggerLeft.enabled = true;
            }
            else
            {
                attackTriggerRight.enabled = true;
            }
 
        secondAttack = false;
    }
    
}
