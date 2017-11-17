using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {
    public float maxSpeed = 9;
    public float jumpTakeOffSpeed = 9;

    public KeyCode rightMovement = KeyCode.D;
    public KeyCode leftMovement = KeyCode.A;

    protected int jumpCount = 0;
    
    private bool spriteFlip = true; //true is facing right, false is facing left
    
    private float damageTimer = 1f;
    private float invulnerability = 0f;

    private LevelManager levelManager;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Attack isPlayerAttacking;
    private GameObject trailOne;
    private GameObject trailTwo;
    private GameObject trailThree;
    private GameObject trailFour;
    private Health health;

    // Use this for initialization
    void Awake () {
        health = GetComponent<Health>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isPlayerAttacking = GetComponent<Attack>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        animator = GetComponent<Animator>();
        trailOne = GameObject.Find("Trail1");
        trailThree = GameObject.Find("Trail2");
        trailTwo = GameObject.Find("TrailFlip1");
        trailFour = GameObject.Find("TrailFlip2");
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
        
        Vector2 move = Vector2.zero;
        if (isPlayerAttacking.attacking)
        {
            move.x = 0;
        }
        else
        {
            move.x = Input.GetAxis("Horizontal");
        }
        
        

        if(velocity.y == 0 || (velocity.y > -0.00001 && velocity.y < 0.00001))
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
            if (!spriteFlip && !(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(leftMovement)))
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
                spriteFlip = !spriteFlip;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(leftMovement))
        {
            if(spriteFlip)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
                spriteFlip = !spriteFlip;
            }
        }
        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
        
        targetVelocity = move * maxSpeed;
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Damageable" || collision.gameObject.tag == "Enemy")
        {
            health.takeDamage(collision.gameObject.GetComponent<Damage>().damage);

            if (invulnerability > 0f)
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

            if(!spriteRenderer.enabled)
            {
                spriteRenderer.enabled = true;
            }
        }    
    }
}
