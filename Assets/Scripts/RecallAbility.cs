using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecallAbility : PhysicsObject
{

    public RecallState recallState;
    public float recallCooldownTimer;
    public float recallCooldown = 10f;

    public Vector2 lastLocation;
    public int lastHeath;
    private bool recalling;
    private Transform transformRenderer;
    private SpriteRenderer spriteRenderer;
    private PlayerPlatformerController cont;
    private Animator animator;

    private GameObject recallOutline;

    void Awake()
    {
        animator = GetComponent<Animator>();
        recallOutline = GameObject.Find("RecallOutline");

        InvokeRepeating("UpdateLast", 0.0f, 3f);
    }

    protected override void RecallAbilityCheck()
    {
        cont = GetComponent<PlayerPlatformerController>();
        transformRenderer = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        switch (recallState)
        {
            case RecallState.Ready:
                var isRecallKeyDown = Input.GetKeyDown(KeyCode.E);
                if (isRecallKeyDown)
                {
                    print("Recalling!");
                    transformRenderer.position = lastLocation;
                    cont.currentHealth = lastHeath;
                    recallState = RecallState.Cooldown;
                    recallCooldownTimer = recallCooldown;
                    recallOutline.GetComponent<SpriteRenderer>().enabled = false;
                }
                break;

            case RecallState.Cooldown:

                recallCooldownTimer -= Time.deltaTime;
                if (recallCooldownTimer <= 0)
                {
                    recallCooldownTimer = 0;
                    recallState = RecallState.Ready;
                    recallOutline.GetComponent<SpriteRenderer>().enabled = true;
                }
                break;
        }
    }

    public void UpdateLast()
    {
        transformRenderer = GetComponent<Transform>();
        cont = GetComponent<PlayerPlatformerController>();

        print("Updateing last location and health");
        lastLocation = transformRenderer.position;
        lastHeath = cont.currentHealth;
        recallOutline.GetComponent<Transform>().position = lastLocation;
    }

}

public enum RecallState
{
    Ready,
    Cooldown
}
