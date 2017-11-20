using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : PhysicsObject
{

    public DashState dashState;
    public float dashTimer;
    public float maxDash = 20f;
    public float dashCooldown = 5f;

    private bool dashing;
    private float timeStorage;
    private Transform transformRenderer;
    private SpriteRenderer spriteRenderer;
    private PlayerPlatformerController cont;
    private Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    protected override void DashAbilityCheck()
    {
        cont = GetComponent<PlayerPlatformerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator.SetBool("dashing", dashing);
        switch (dashState)
        {
            case DashState.Ready:
                var isDashKeyDown = Input.GetKeyDown(KeyCode.LeftShift);
                if (isDashKeyDown)
                {
                    cont.gravityController = 0f;
                    rb2d = GetComponent<Rigidbody2D>();
                   
                    gravityController = 0;
                    if (spriteRenderer.flipX)
                    {
                        rb2d.velocity = new Vector2(rb2d.velocity.x - 30f, 0);
                    }
                    else
                    {
                        rb2d.velocity = new Vector2(rb2d.velocity.x + 30f, 0);
                    }
                    
                    dashState = DashState.Dashing;
                    dashing = true;
                }
                
                break;
            case DashState.Dashing:
                transformRenderer = GetComponent<Transform>();
                transformRenderer.rotation = Quaternion.Euler(0, 0, 0);
                dashTimer += Time.deltaTime * 200;
                
                if (dashTimer >= maxDash)
                {
                    timeStorage = Time.time - timeStorage;
                    dashTimer = dashCooldown;
                    rb2d.velocity = new Vector2(0, 0);
                    dashState = DashState.Cooldown;
                    dashing = false;
                }
                break;
            case DashState.Cooldown:

                if(cont.gravityController == 0f)
                {
                    cont.gravityController = .4f;
                }
                else if(cont.gravityController <= 1f)
                {
                    if(cont.gravityController * 1.2f >= 1f)
                    {
                        cont.gravityController = 1f;
                    }
                    else
                    {
                        cont.gravityController = cont.gravityController * 1.02f;
                    }
                    
                    
                }
                
                dashTimer -= Time.deltaTime;
                if (dashTimer <= 0)
                {
                    dashTimer = 0;
                    dashState = DashState.Ready;
                    
                }
                break;
        }
    }
}

public enum DashState
{
    Ready,
    Dashing,
    Cooldown
}
