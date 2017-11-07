using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {
    public float maxSpeed = 9;
    public float jumpTakeOffSpeed = 9;
    
    public int maxHealth = 5;
    public int currentHealth = 5;

    public KeyCode rightMovement = KeyCode.D;
    public KeyCode leftMovement = KeyCode.A;

    protected int jumpCount = 0;
    
    private float damageTimer = 1f;
    private float invulnerability = 0f;
    private bool tookDamage = false;
    private bool spriteFlip = true; //true is facing right, false is facing left
    private LevelManager levelManager;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Attack isPlayerAttacking;
	// Use this for initialization
	void Awake () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        isPlayerAttacking = GetComponent<Attack>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        animator = GetComponent<Animator>();
    }

   
    // Update is called once per frame
    protected override void ComputeVelocity()
    {
        if (tookDamage)
        {
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
            else
            {
                tookDamage = false;
            }
        }
        if(!tookDamage && !spriteRenderer.enabled)
        {
            spriteRenderer.enabled = true;
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
            if (!spriteFlip)
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
        if(collision.gameObject.layer == 12)
        {
            if(tookDamage == false)
            {
                currentHealth--;
                invulnerability = damageTimer;
                tookDamage = true;
            }
            
            if(currentHealth == 0)
            {
                levelManager.LoadLevel("Main");
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            if (tookDamage == false)
            {
                currentHealth--;
                invulnerability = damageTimer;
                tookDamage = true;
            }

            if (currentHealth == 0)
            {
                levelManager.LoadLevel("Main");
            }
        }
    }
}
