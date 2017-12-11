using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {
    public float maxSpeed = 9;
    public float jumpTakeOffSpeed = 9;
    public bool movementKeyDown = false;
    public KeyCode rightMovement = KeyCode.D;
    public KeyCode leftMovement = KeyCode.A;

    protected int jumpCount = 0;
    
    protected bool spriteFlip = true; //true is facing right, false is facing left
    private bool tookDamage = false;
    private float damageTimer = 1f;
    private float invulnerability = 0f;
    public TrailRenderer trailOne;
    public TrailRenderer trailTwo;
    public TrailRenderer trailThree;
    public TrailRenderer trailFour;

    private LevelManager levelManager;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Attack isPlayerAttacking;
    private Transform trans;
    
    public Health health;
    private Attack attackz;


    // Use this for initialization
    void Awake () {
        attackz = GetComponent<Attack>();
        health = GetComponent<Health>();

		if (health != null) {
			print ("health is not null");
		}
        spriteRenderer = GetComponent<SpriteRenderer>();
        isPlayerAttacking = GetComponent<Attack>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        animator = GetComponent<Animator>();
        trans = GetComponent<Transform>();
        
    }



    // Update is called once per frame
    protected override void ComputeVelocity()
    {
		if (health.dead) {
			levelManager.RespawnPlayer ();
		}
        //Debug.Log(spriteFlip);
        //Debug.Log(trailOne.GetComponent<TrailRenderer>().enabled);
        if (tookDamage)
        {
            if(invulnerability > 0f)
            {
                invulnerability -= Time.deltaTime;
                if (spriteRenderer.enabled)
                {
                    spriteRenderer.enabled = false;
                }
                else
                {
                    spriteRenderer.enabled = true;
                }
            }
            else {
                tookDamage = false;
            }
        }
        if(!tookDamage && !spriteRenderer.enabled)
        {
            spriteRenderer.enabled = true;
        }
        Vector2 move = Vector2.zero;
        if (isPlayerAttacking.attacking && grounded)
        {
            move.x = 0;
        }
        else
        {
            move.x = Input.GetAxis("Horizontal");
        }
        
        

        if((velocity.y == 0 || (velocity.y > -0.00001 && velocity.y < 0.00001)) && grounded)
        {
            
            jumpCount = 0;
            velocity.y = 0;
        }


        if (Input.GetButtonDown("Jump") && jumpCount < 2)
        {
            gravityController = 1f;
            if(jumpCount == 1)
            {
                animator.Play("DoubleJumpAnimation");
            }
            jumpCount++;
            velocity.y = jumpTakeOffSpeed;
            
        }
        else if (Input.GetButtonUp("Jump"))
        {
            grounded = false;
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * .5f;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(rightMovement))
        {
            movementKeyDown = true;
            if (!spriteFlip && !(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(leftMovement)) && !attackz.attacking)
            {
                //spriteRenderer.flipX = !spriteRenderer.flipX;
                Vector3 theScale = trans.localScale;
                theScale.x *= -1;
                trans.localScale = theScale;

                spriteFlip = !spriteFlip;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(leftMovement))
        {
            movementKeyDown = true;
            if(spriteFlip && !attackz.attacking)
            {
                //spriteRenderer.flipX = !spriteRenderer.flipX;
                Vector3 theScale = trans.localScale;
                theScale.x *= -1;
                trans.localScale = theScale;
                spriteFlip = !spriteFlip;
            }
        }
        else
        {
            movementKeyDown = false;
        }
        
        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
        animator.SetBool("movementkeydown", movementKeyDown);
        targetVelocity = move * maxSpeed;
       
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Damageable" || collision.gameObject.tag == "Enemy")
        {
            print(collision.gameObject.tag);
            if (!tookDamage)
            {
                try
                {
                    Debug.Log("Current health is: " + Health.currentHealth);
                health.takeDamage(collision.gameObject.GetComponent<Damage>().damage);
                invulnerability = damageTimer;
                tookDamage = true;

                    for (int i = 5; i >= Health.currentHealth; --i)
                    {
                        GameObject healthbar = GameObject.FindGameObjectWithTag("health" + Health.currentHealth);
                        healthbar.GetComponent<healthIcon>().playAnimation();
                    }
                }
                catch
                {
                    
                    //print("i dont know man this is weird");
                }


            }
        }  
		/*
		if (health.dead) {
			levelManager.RespawnPlayer ();
		}
		*/
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //print("on stay");
        if (collision.gameObject.tag == "Damageable" || collision.gameObject.tag == "Enemy")
        {
            if (!tookDamage)
            {
                try
                {
                    Debug.Log("Current health is: " + Health.currentHealth);
                    health.takeDamage(collision.gameObject.GetComponent<Damage>().damage);
                    invulnerability = damageTimer;
                    tookDamage = true;
                    for (int i = 5; i >= Health.currentHealth; --i)
                    {
                        GameObject healthbar = GameObject.FindGameObjectWithTag("health" + Health.currentHealth);
                        healthbar.GetComponent<healthIcon>().playAnimation();
                    }
                }
                catch
                {
                    Debug.Log("No object");
                }
                


            }
        }
		/*
		if (health.dead) {
			levelManager.RespawnPlayer ();
		}
		*/
    }

}
