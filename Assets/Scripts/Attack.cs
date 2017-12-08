using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Attack : PlayerPlatformerController {

    public bool attacking = false;
    public bool secondAttack = false;
    //public Collider2D AttackTriggerRight;
    //public Collider2D AttackTriggerLeft;

    private float attacks = 0f;
    private float attackCooldown = .26f;
    private float secondAttacks = 0f;
    private float secondAttackCooldown = .5f;
    private bool sprite;
    private Animator attackanimator;
    
    void Awake()
    {
        attackanimator = GetComponent<Animator>();
        //AttackTriggerRight.enabled = false;
        //AttackTriggerLeft.enabled = false;
        
    }
    void FixedUpdate()
    {
        //GameObject.Find("charAttTrigger").GetComponent<Transform>().position = GameObject.Find("char").GetComponent<Transform>().position;
        
    }
    void Update()
    {
        if (attacks > 0f)
        
            //sprite = GameObject.Find("char").GetComponent<SpriteRenderer>().flipX;
            //if (!attacking && !sprite)
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
            if (secondAttacks > 0f && !secondAttack && attacks <= .15f)
            {
                secondAttack = true;
                secondAttacks = .25f;
                attackanimator.Play("SecondAttack");
                if (sprite)
                {
                    //AttackTriggerLeft.enabled = true;
                }
                else
                {
                    //AttackTriggerRight.enabled = true;
                }
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
                //AttackTriggerLeft.enabled = true;
            }
            else
            {
                //AttackTriggerRight.enabled = true;
            }

        }
        if(attacks <= 0f)
        {
            
            if (!secondAttack)
            {
                attacking = false;
                //AttackTriggerRight.enabled = false;
                //AttackTriggerLeft.enabled = false;
            }
            

        }
        if(secondAttacks <= 0f)
        {
            secondAttack = false;
            //AttackTriggerRight.enabled = false;
            //AttackTriggerLeft.enabled = false;
        }
		sprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().flipX;
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
