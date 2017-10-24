using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : PhysicsObject
{

    public DashState dashState;
    public float dashTimer;
    public float maxDash = 20f;
    public Vector2 savedVelocity;

    private Transform transformRenderer;
    private SpriteRenderer spriteRenderer;
    protected override void DashAbilityCheck()
    {
        gravityModifier = 0f;
        spriteRenderer = GetComponent<SpriteRenderer>();
        switch (dashState)
        {
            case DashState.Ready:
                var isDashKeyDown = Input.GetKeyDown(KeyCode.LeftShift);
                if (isDashKeyDown)
                {
                    
                    rb2d = GetComponent<Rigidbody2D>();
                    
                    if (spriteRenderer.flipX)
                    {
                        rb2d.velocity = new Vector2(rb2d.velocity.x - 30f, 0);
                    }
                    else
                    {
                        rb2d.velocity = new Vector2(rb2d.velocity.x + 30f, 0);
                    }
                    
                    dashState = DashState.Dashing;
                }
                break;
            case DashState.Dashing:
                transformRenderer = GetComponent<Transform>();
                transformRenderer.rotation = Quaternion.Euler(0, 0, 0);
                dashTimer += Time.deltaTime * 200;
                if (dashTimer >= maxDash)
                {
                    dashTimer = maxDash;
                    rb2d.velocity = new Vector2(0, 0);
                    dashState = DashState.Cooldown;
                }
                break;
            case DashState.Cooldown:
                dashTimer -= Time.deltaTime * 10;
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
