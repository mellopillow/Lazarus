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
    private float attackCooldown = .26f;
    private float secondAttacks = 0f;
    private float secondAttackCooldown = .5f;
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
        if (attacks > 0f)
        {
            attacks -= Time.deltaTime;
            //Debug.Log(attacks);
            

        }
        if(secondAttacks > 0f)
        {
            secondAttacks -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (secondAttacks > 0f && !secondAttack && attacks <= .20f)
            {

                secondAttack = true;
                secondAttacks = 0f;
                attackanimator.Play("SecondAttack");
                Debug.Log("Second attack");
                //Debug.Log(attacks);
            }
            else if(!attacking)
            {
                Debug.Log("First attack");
                attacks = attackCooldown;
                secondAttacks = secondAttackCooldown;
                attacking = true;
                attackanimator.Play("AttackAnimation");
            }
            
            if (sprite)
            {
                attackTriggerLeft.enabled = true;
            }
            else
            {
                attackTriggerRight.enabled = true;
            }

        }
        if(attacks <= 0f)
        {
            
            if (!secondAttack)
            {
                attacking = false;
                attackTriggerRight.enabled = false;
                attackTriggerLeft.enabled = false;
            }
            

        }
        if(secondAttacks <= 0f)
        {
            secondAttack = false;
            attacking = false;
            attackTriggerRight.enabled = false;
            attackTriggerLeft.enabled = false;
        }
        sprite = GameObject.Find("char").GetComponent<SpriteRenderer>().flipX;
        attackanimator.SetBool("attacking", attacking);
        attackanimator.SetBool("secondattack", secondAttack);
        
        
        
    }
    void Attacking()
    {
        /*
        if (!secondAttack)
        {
            attacking = false;
        }
        attackTriggerRight.enabled = false;
        attackTriggerLeft.enabled = false;*/
        
    }
    void SecondAttack()
    {/*
            if (sprite)
            {
                attackTriggerLeft.enabled = true;
            }
            else
            {
                attackTriggerRight.enabled = true;
            }
 
        secondAttack = false;*/
    }
    
}
