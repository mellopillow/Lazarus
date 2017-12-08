using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecallAbility : PhysicsObject
{

    public RecallState recallState;
    public float recallCooldownTimer;
    public float recallCooldown = 10f;
	public Transform lastLocation; //changed it from vector3 to Transform
    public Vector3 startLocation;

    private bool recalling;
    private Transform transformRenderer;
    private Transform prepPosition;
    private SpriteRenderer spriteRenderer;
    private PlayerPlatformerController cont;
    private Animator animator;
    private float timer = 3f;
    private GameObject recallOutline;
    //private Queue recallList = new Queue();


    void Awake()
    {
        transformRenderer = GetComponent<Transform>();
        cont = GetComponent<PlayerPlatformerController>();
        animator = GetComponent<Animator>();
        recallOutline = GameObject.Find("RecallOutline");
        startLocation = transformRenderer.position;
        //recallOutline.GetComponent<SpriteRenderer>().enabled = false; // turn off the outline
    }

    protected override void RecallAbilityCheck()
    {
        cont = GetComponent<PlayerPlatformerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
		var isRecallKeyDown = Input.GetKeyDown(KeyCode.X); // this was inside the switch
        switch (recallState)
        {
            
            case RecallState.Ready:
                if (isRecallKeyDown)
                {
                    print("Recall prepped");
					prepPosition = lastLocation;
                    recallState = RecallState.Prepped;
                    //recallOutline.GetComponent<SpriteRenderer>().enabled = false;
                }
                break;

            case RecallState.Prepped:
                if (isRecallKeyDown)
                {
                    print("Recalling!");
                    transformRenderer = prepPosition;
                    recallState = RecallState.Cooldown;
                }
                break;

            case RecallState.Cooldown:

                recallCooldownTimer -= Time.deltaTime;
                if (recallCooldownTimer <= 0)
                {
                    recallCooldownTimer = 0;
                    recallState = RecallState.Ready;
                    //recallOutline.GetComponent<SpriteRenderer>().enabled = true;
                }
                break;
        }
    }

    void Update()
    {
        if(Time.timeSinceLevelLoad < timer)
        {
            
            //recallList.Enqueue(transformRenderer.position);

}
        else
        {
            //recallList.Enqueue(transformRenderer.position);

            lastLocation = transformRenderer;
        }
        RecallAbilityCheck();
        
        //print(lastLocation);

        //print("Updateing last location and health");
        
        //recallOutline.GetComponent<Transform>().position = lastLocation;
    }

}

public enum RecallState
{
    Ready,
    Cooldown,
    Prepped
}
