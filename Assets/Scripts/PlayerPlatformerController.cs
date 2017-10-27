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

    private bool spriteFlip = true; //true is facing right, false is facing left
    private SpriteRenderer spriteRenderer;
    private Animator animator;
	// Use this for initialization
	void Awake () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    protected override void ComputeVelocity()
    {
        
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

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

        //animator.SetBool("grounded", grounded);
        //animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
       
    }
}
