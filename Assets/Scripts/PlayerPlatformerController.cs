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
    
    private Health health;
    private Attack attackz;

    // Use this for initialization
    void Awake () {
        attackz = GetComponent<Attack>();
        health = GetComponent<Health>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isPlayerAttacking = GetComponent<Attack>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        animator = GetComponent<Animator>();
        
    }

   
    // Update is called once per frame
    protected override void ComputeVelocity()
    {
        if (!spriteFlip)
        {
            
            trailOne.GetComponent<TrailRenderer>().enabled = false;
            trailTwo.GetComponent<TrailRenderer>().enabled = true;
            trailThree.GetComponent<TrailRenderer>().enabled = false;
            trailFour.GetComponent<TrailRenderer>().enabled = true;

        }
        else
        {
            trailOne.GetComponent<TrailRenderer>().enabled = true;
            trailTwo.GetComponent<TrailRenderer>().enabled = false;
            trailThree.GetComponent<TrailRenderer>().enabled = true;
            trailFour.GetComponent<TrailRenderer>().enabled = false;
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
                spriteRenderer.flipX = !spriteRenderer.flipX;
                spriteFlip = !spriteFlip;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(leftMovement))
        {
            movementKeyDown = true;
            if(spriteFlip && !attackz.attacking)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
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
        print("on enter");
        if (collision.gameObject.tag == "Damageable" || collision.gameObject.tag == "Enemy")
        {
            print(collision.gameObject.tag);
            if (!tookDamage)
            {
                try
                {
                health.takeDamage(collision.gameObject.GetComponent<Damage>().damage);
                GameObject healthbar = GameObject.FindGameObjectWithTag("health" + health.currentHealth);
                healthbar.GetComponent<healthIcon>().playAnimation();
                invulnerability = damageTimer;
                tookDamage = true;
                }
                catch
                {
                    print("i dont know man this is weird");
                }


            }
        }  
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        print("on stay");
        if (collision.gameObject.tag == "Damageable" || collision.gameObject.tag == "Enemy")
        {
            if (!tookDamage)
            {
                try
                {
                    health.takeDamage(collision.gameObject.GetComponent<Damage>().damage);
                    GameObject healthbar = GameObject.FindGameObjectWithTag("health" + health.currentHealth);
                    healthbar.GetComponent<healthIcon>().playAnimation();
                }
                catch
                {
                    Debug.Log("No object");
                }
                invulnerability = damageTimer;
                tookDamage = true;


            }
        }
    }

}
